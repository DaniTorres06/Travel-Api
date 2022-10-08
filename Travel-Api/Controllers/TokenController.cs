using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel_Api.Models.DTO;
using Travel_Api.Security;

namespace Travel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<object> CrearToken([FromBody] AutoresDTO autoresDTO)
        {
            var secret = this._config.GetValue<string>("Secret");
            var jwtHelper = new JWTHelper(secret);
            var token = jwtHelper.createToken(autoresDTO.Nombre);

            return Ok(new
            {
                Ok = true,
                msg = "Token creado con exito",
                token
            });
        }
    }
}
