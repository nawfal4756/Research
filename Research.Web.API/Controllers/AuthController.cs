using Microsoft.AspNetCore.Mvc;
using Research.Data.Model;
using Research.Service;
using Research.Utilities;
using Research.Web.API.DTO.Auth;
using static Research.Utilities.Enums;

namespace Research.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO data)
        {
            try
            {
                var query = await _authService.Login(data.Email, data.Password);
                if (!query.Success)
                {
                    return BadRequest(query);
                }
                
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<LoginResponse>()
                {
                    Success = false,
                    Message = $"Login failed due to [{ex.Message}]",
                    Error = new Error()
                    {
                        Code = ErrorCodes.UNKNOWN_ERROR,
                        Cause = ex.Message
                    }
                });
            }
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshDTO data)
        {
            try
            {
                var tokenBody = HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(tokenBody)) throw new UnauthorizedAccessException("Token not found");
                var token = tokenBody.ToString().Split(" ").Last();
                var query = await _authService.RefreshToken(token, data.refreshToken);
                if (!query.Success)
                {
                    return BadRequest(query);
                }

                return Ok(query);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new Response<LoginResponse>()
                {
                    Success = false,
                    Message = $"Refresh Token failed due to [{ex.Message}]",
                    Error = new Error()
                    {
                        Code = 401,
                        Cause = ex.Message
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<LoginResponse>()
                {
                    Success = false,
                    Message = $"Refresh Token failed due to [{ex.Message}]",
                    Error = new Error()
                    {
                        Code = ErrorCodes.UNKNOWN_ERROR,
                        Cause = ex.Message
                    }
                });
            }
        }

        [Auth(Permissions = "DEL_CUST")]
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var user = HttpContext.Items[CONTEXT_USER] as UserContextData;
            return Ok(user);
        }
    }
}
