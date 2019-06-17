using AlgebraSeminar.DTOs;
using AlgebraSeminar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlgebraSeminar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISeminarRepository _seminari;
        private readonly IPredbiljezbaRepository _predbiljezbe;
        private readonly IZaposlenikRepository _zaposlenici;

        public HomeController(ISeminarRepository seminari, IPredbiljezbaRepository predbiljezbe, IZaposlenikRepository zaposlenici)
        {
            _seminari = seminari;
            _predbiljezbe = predbiljezbe;
            _zaposlenici = zaposlenici;
        }

        [HttpGet]
        public ActionResult Predbiljezba(string query = null)
        {
            List<Seminar> model = _seminari.GetUnfilledSeminars(query);
            return View(model);
        }

        [HttpGet]
        public ActionResult NovaPredbiljezba(int seminarId)
        {
            Session["OdabraniSeminar"] = _seminari.GetSeminar(seminarId);

            Predbiljezba model = new Predbiljezba
            {
                Datum = DateTime.Now,
                SeminarId = seminarId,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult NovaPredbiljezba(Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {

                _predbiljezbe.UpisiPredbiljezbu(predbiljezba);
                Session["OdabraniSeminar"] = null;
                return View("PredbiljezbaSuccess");
            }
            return View(predbiljezba);
        }
        [AuthorizeJWT]
        [HttpGet]
        public ActionResult Predbiljezbe()
        {
            List<Predbiljezba> model = _predbiljezbe.GetPredbiljezbe();
            return View(model);
        }

        [AuthorizeJWT]
        [HttpPost]
        public ActionResult Predbiljezbe(string query, string tippretrage)
        {
            //Overly elaborate way to filter predbiljezbe by Prezime or Seminar.Naziv
            List<Predbiljezba> model = (tippretrage == "Pretraži po prezimenu") ?
                _predbiljezbe.GetPredbiljezbe().Where(p => p.Prezime.ToLower().Contains(query.ToLower())).ToList()
                : _predbiljezbe.GetPredbiljezbe().Where(p => p.Seminar.Naziv.ToLower().Contains(query.ToLower())).ToList();

            return View(model);
        }
        [AuthorizeJWT]
        [HttpGet]
        public ActionResult UrediPredbiljezbu(int IdPredbiljezba)
        {
            PredbiljezbaZaEdit model = new PredbiljezbaZaEdit
            {
                Predbiljezba = _predbiljezbe.GetPredbiljezba(IdPredbiljezba),
                Seminari = _seminari.GetAllSeminars()
            };
            return View(model);
        }

        [AuthorizeJWT]
        [HttpPost]
        public ActionResult UrediPredbiljezbu(Predbiljezba predbiljezba)
        {
            _predbiljezbe.UrediPredbiljezbu(predbiljezba, out bool uredbaSuccessful);
            if (uredbaSuccessful)
            {
                return RedirectToAction("Predbiljezbe");
            }
            else
            {
                PredbiljezbaZaEdit model = new PredbiljezbaZaEdit
                {
                    Predbiljezba = predbiljezba,
                    Message = "Seminar je pun!",
                    Seminari = _seminari.GetAllSeminars()
                };
                model.Predbiljezba.Seminar = model.Seminari.First(s => s.SeminarId == model.Predbiljezba.SeminarId);
                return View(model);
            }

        }

        [AuthorizeJWT]
        [HttpGet]
        public ActionResult DodajNovogZaposlenika()
        {
            return View();
        }
        [AuthorizeJWT]
        [HttpPost]
        public ActionResult DodajNovogZaposlenika(Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                zaposlenik.KorisnickoIme = zaposlenik.KorisnickoIme.ToLower();
                _zaposlenici.KreirajZaposlenika(zaposlenik);
            }

            return View();
        }

        [AuthorizeJWT]
        [HttpGet]
        public ActionResult DodajSeminar()
        {
            return View();
        }

        [AuthorizeJWT]
        [HttpPost]
        public ActionResult DodajSeminar(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                _seminari.DodajSeminar(seminar);
                return RedirectToAction("Predbiljezba");
            }
            return View(seminar);
        }

        [AuthorizeJWT]
        [HttpGet]
        public ActionResult UrediSeminar(int id)
        {
            Seminar model = _seminari.GetSeminar(id);
            return View(model);
        }

        [AuthorizeJWT]
        [HttpPost]
        public ActionResult UrediSeminar(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                _seminari.UrediSeminar(seminar);
                return RedirectToAction("Predbiljezba");
            }
            return View(seminar);
        }

        [AuthorizeJWT]
        public ActionResult ObrisiSeminar(int id)
        {
            _seminari.ObrisiSeminar(id);
            return RedirectToAction("Predbiljezba");
        }
    }
}