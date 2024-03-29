﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Safari.Services;
using Safari.Entities;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index()
        {
            var proces = new PetService();
            var mascotasList = proces.ObtenerMascotas();

            return View("Index", mascotasList);
        }

        // GET: Pet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            try
            {
                var proces = new PetService();
                proces.CrearNuevaMascota(pet);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Pet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pet pet)
        {
            try
            {
                // TODO: Add update logic here

                var proces = new PetService();
                proces.ModificarMascota(pet);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pet/Delete/5
        public ActionResult Delete(int id)
        {
            var proces = new PetService();
            var pet = proces.ObtenerMascota(id);

            return View(pet);
        }

        // POST: Pet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pet pet)
        {
            try
            {
                var proces = new PetService();
                proces.BorrarMascota(pet);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
