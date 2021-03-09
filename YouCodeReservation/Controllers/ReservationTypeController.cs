using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouCodeReservation.Contract;
using YouCodeReservation.Data;
using YouCodeReservation.Models;

namespace YouCodeReservation.Controllers
{
    public class ReservationTypeController : Controller
    {
        private readonly IReservationTypeRepository _repo;
        public ReservationTypeController(IReservationTypeRepository repo)
        {
            _repo = repo;
        }
        // GET: ReservationTypeController
        public ActionResult Index()
        {
            var reservationTypes = _repo.GetAll();
            var model = reservationTypes.Select(a => new ReservationTypeViewModel() { Id = a.Id, Name = a.Name,Number=a.Number}).ToList();
            return View(model);
        }

        // GET: ReservationTypeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var AbsenceType = _repo.GetById(id);
            var model = new ReservationTypeViewModel
            {
                Id = AbsenceType.Id,
                Name = AbsenceType.Name,
                Number = AbsenceType.Number
            };
            return View(model);
            
        }

        // GET: ReservationTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationTypeViewModel reservation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var absencType = new ReservationType
                {
                    Id = reservation.Id,
                    Name = reservation.Name,
                    Number = reservation.Number

                };
                var isSuccess = _repo.Create(absencType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(reservation);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var AbsenceType = _repo.GetById(id);
            var model = new ReservationTypeViewModel
            {
                Id = AbsenceType.Id,
                Name = AbsenceType.Name,
                Number = AbsenceType.Number
            };
            return View(model);
        }

        // POST: ReservationTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReservationTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                var ReservationType = new ReservationType
                {
                    Id = model.Id,
                    Name = model.Name,
                    Number = model.Number
                };
                var isSuccess = _repo.Update(ReservationType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: ReservationTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var reservationType = _repo.GetById(id);
            if (reservationType == null)
            {
                return NotFound();
            }
            var IsSuccess = _repo.Delete(reservationType);
            if (!IsSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
            
        }

        // POST: ReservationTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var reservationType = _repo.GetById(id);
                if (reservationType == null)
                {
                    return NotFound();
                }
                var IsSuccess = _repo.Delete(reservationType);
                if (!IsSuccess)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
