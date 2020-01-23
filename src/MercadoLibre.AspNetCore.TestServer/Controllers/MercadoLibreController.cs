using MercadoLibre.AspNetCore.SDK;
using MercadoLibre.AspNetCore.SDK.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLibre.AspNetCore.TestServer.Controllers
{
    [ApiController]
    [Route("ml")]
    public class MercadoLibreController : Controller
    {
        private Dictionary<string, SDK.Models.AuthorizeToken> _Tokens = new Dictionary<string, SDK.Models.AuthorizeToken>();

        private Meli Meli { get; }

        public MercadoLibreController(Meli meli)
        {
            Meli = meli;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return Redirect(Meli.GetAuthUrl(AuthUrls.MLB, "https://localhost:5001/ml/auth"));
        }

        [HttpGet]
        public async Task<IActionResult> Auth(string code)
        {
            try
            {
                await Meli.AuthorizeAsync(code, "https://localhost:5001/ml/auth");

                _Tokens[Meli.AuthorizeToken.UserId] = Meli.AuthorizeToken;

                return View(Meli.AuthorizeToken);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public IActionResult Notifications()
        {
            return Ok();
        }
    }
}
