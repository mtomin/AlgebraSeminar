using AlgebraSeminar.DTOs;
using AlgebraSeminar.Models;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSeminar.Controllers
{
    public class LoginController : Controller
    {
        private readonly IZaposlenikRepository _zaposlenici;

        public LoginController(IZaposlenikRepository zaposlenici)
        {
            _zaposlenici = zaposlenici;
        }

        [HttpGet]
        public ActionResult Prijava()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prijava(ZaposlenikZaLogin zaposlenik)
        {
            if (ModelState.IsValid)
            {
                zaposlenik.KorisnickoIme = zaposlenik.KorisnickoIme.ToLower();
                if (_zaposlenici.PrijavaUspjela(zaposlenik))
                {
                    string token = TokenManager.GenerateToken(zaposlenik.KorisnickoIme);
                    System.Web.HttpContext.Current.Response.Cookies.Add(new System.Web.HttpCookie("auth_token")
                    {
                        Value = token,
                        HttpOnly = true
                    });

                    return View("LoginUspjesan");
                }
            }
            return View();
        }
    }
}