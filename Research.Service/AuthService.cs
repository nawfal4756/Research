using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Research.Data.Model;
using Research.Data.Repository.Interface;
using Research.Utilities;
using Research.Utilities.HashPassword;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Research.Utilities.Enums;

namespace Research.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly IUserRepository userRepository;
        private readonly IHashPassword hashPassword;

        public AuthService(IConfiguration configuration, IUserRepository userRepository, IHashPassword hashPassword)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
            this.hashPassword = hashPassword;
        }

        public async Task<Response<LoginResponse>> Login(string email, string password)
        {
            try
            {
                var hashedPassword = hashPassword.Hash(password);
                Users user = await userRepository.Login(email, hashedPassword) ?? throw new Exception("Invalid credentials");
                LoginResponse response = new LoginResponse();
                response.AccessToken = GenerateToken(user, false);
                response.RefreshToken = GenerateToken(user, true);

                return new Response<LoginResponse>()
                {
                    Success = true,
                    Message = "Login successful",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                return new Response<LoginResponse>()
                {
                    Success = false,
                    Message = $"Login failed due to [{ex.Message}]",
                    Error = new Error()
                    {
                        Code = ErrorCodes.UNKNOWN_ERROR,
                        Cause = ex.Message
                    }
                };
            }
        }

        public async Task<Response<LoginResponse>> RefreshToken(string accessToken, string refreshToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var SecretKey = configuration.GetValue<string>("JwtSettings:SecretKey");
                var key = Encoding.ASCII.GetBytes(SecretKey);

                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedAccessToken);

                tokenHandler.ValidateToken(refreshToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedRefreshToken);

                var jwtAccessToken = (JwtSecurityToken)validatedAccessToken;
                var jwtRefreshToken = (JwtSecurityToken)validatedRefreshToken;
                
                if (jwtRefreshToken.Claims.FirstOrDefault(x => x.Type == CustomClaimType.RefreshToken.ToString())?.Value != "True")
                {
                    throw new Exception("Invalid token");
                }

                if (!jwtAccessToken.Claims.FirstOrDefault(x => x.Type == CustomClaimType.UserName.ToString()).Value.Equals(jwtRefreshToken.Claims.FirstOrDefault(x => x.Type == CustomClaimType.UserName.ToString()).Value) || !jwtAccessToken.Claims.FirstOrDefault(x => x.Type == CustomClaimType.UserId.ToString()).Value.Equals(jwtRefreshToken.Claims.FirstOrDefault(x => x.Type == CustomClaimType.UserId.ToString()).Value))
                {
                    throw new Exception("Invalid token");
                }

                var userId = int.Parse(jwtRefreshToken.Claims.FirstOrDefault(x => x.Type == CustomClaimType.UserId.ToString()).Value);
                Users users = await userRepository.GetById(userId) ?? throw new Exception("User not found");
                LoginResponse response = new LoginResponse();
                response.AccessToken = GenerateToken(users, false);
                response.RefreshToken = GenerateToken(users, true);

                return new Response<LoginResponse>()
                {
                    Success = true,
                    Message = "Token refreshed successfully",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                return new Response<LoginResponse>()
                {
                    Success = false,
                    Message = $"Token refresh failed due to [{ex.Message}]",
                    Error = new Error()
                    {
                        Code = ErrorCodes.UNKNOWN_ERROR,
                        Cause = ex.Message
                    }
                };
            }
        }

        private string GenerateToken(Users user, bool refreshToken)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JwtSettings:SecretKey"));
            var securityKey = new SymmetricSecurityKey(key);
            DateTime tokenExpiry = refreshToken ? DateTime.UtcNow.AddDays(configuration.GetValue<int>("JwtSettings:RefreshTokenExpiryInDays")) : DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("JwtSettings:TokenExpiryInMinutes"));
            List<Claim> claims = new List<Claim>
            {
                new(CustomClaimType.UserName.ToString(), user.User_Name),
                new(CustomClaimType.UserId.ToString(), user.User_ID.ToString())
            };

            if (refreshToken)
            {
                claims.Add(new Claim(CustomClaimType.RefreshToken.ToString(), true.ToString()));
            }

            if (!refreshToken && user.User_Security_Groups.Count > 0)
            {
                foreach (var group in user.User_Security_Groups)
                {
                    foreach (var permission in group.Security_Group.Security_Group_Feature_Permissions)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, permission.Feature_Permissions.Feature_Permission_Key));
                    }
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiry,
                Issuer = configuration["JwtSettings:Issuer"],
                Audience = configuration["JwtSettings:Issuer"],
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
