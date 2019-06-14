using AlgebraSeminar.DTOs;
using AlgebraSeminar.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSeminar.Controllers
{
    public class AuthController : Controller
    {
        private readonly IZaposlenikRepository _zaposlenici;
        public AuthController(IZaposlenikRepository zaposlenici)
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
                Zaposlenik trenutniZaposlenik = _zaposlenici.PrijavljeniZaposlenik(zaposlenik);
                if (trenutniZaposlenik != null)
                {
                    string token = TokenManager.GenerateToken(trenutniZaposlenik);
                    //If expiration date isn't set, cookie disappears when browser is closed
                    HttpCookie cookie = new HttpCookie("auth_token")
                    {
                        Value = token,
                        HttpOnly = true,
                        Expires= DateTime.Now.AddMinutes(30)
                    };
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                    return RedirectToAction("Predbiljezba", "Home");
                }
                ViewBag.ErrorMessage = "Korisničko ime ili lozinka nisu ispravni!";
            }
            return View();
        }

        public ActionResult Odjava()
        {
            HttpCookie authCookie = Request.Cookies["auth_token"];
            authCookie.Expires = DateTime.Now.AddDays(-10);
            authCookie.Value = null;
            Response.SetCookie(authCookie);
            return RedirectToAction("Predbiljezba", "Home");
        }
    }
}