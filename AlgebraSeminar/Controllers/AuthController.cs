﻿using AlgebraSeminar.DTOs;
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
                if (_zaposlenici.PrijavaUspjela(zaposlenik))
                {
                    string token = TokenManager.GenerateToken(zaposlenik.KorisnickoIme);
                    System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie("auth_token")
                    {
                        Value = token,
                        HttpOnly = true
                    });

                    return View("LoginUspjesan");
                }
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