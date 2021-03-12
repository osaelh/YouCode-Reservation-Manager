﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouCodeReservation.Contract;
using YouCodeReservation.Data;
using YouCodeReservation.Models;

namespace YouCodeReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly IReservationTypeRepository _reservationTypeRepo;
        private readonly UserManager<IdentityUser> _userManager;
        public ReservationController(IReservationRepository Reservationrepo,IReservationTypeRepository ReservationTyperepo,UserManager<IdentityUser> userManager)
        {
            _reservationRepo = Reservationrepo;
            _reservationTypeRepo = ReservationTyperepo;
            _userManager = userManager;
        }
        // GET: ReservationController
        public ActionResult Index()
        {
            var Reservations = _reservationRepo.GetAll();
            var model = Reservations.Select(a => new ReservationViewModel() { Id = a.Id, Date=a.Date,RequestingStudent=a.RequestingStudent,RequestingStudentId=a.RequestingStudentId,ReservationType=a.ReservationType,ReservationTypeId=a.ReservationTypeId,Status=a.Status }).ToList();
            /*  var model = new AdminAbsenceRequestViewModel
              {
                  TotalRequest = AbsenceRequestsModel.Count,
                  ApprouvedRequest = AbsenceRequestsModel.Where(x => x.Approved == true).Count(),
                  RejectedRequest = AbsenceRequestsModel.Where(x => x.Approved == false).Count(),
                  PendingRequest = AbsenceRequestsModel.Count(x => x.Approved == null),
                  AbsenceRequests = AbsenceRequestsModel

              };*/
            return View(model);
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            var reservation = _reservationRepo.GetById(id);
            var model = new ReservationViewModel
            {
                Id = reservation.Id,
                RequestingStudent = reservation.RequestingStudent,
                RequestingStudentId = reservation.RequestingStudentId,
                ReservationType = reservation.ReservationType,
                Date = reservation.Date,
                ReservationTypeId = reservation.ReservationTypeId,
                Status = reservation.Status
            };
            return View(model);
        }

        public ActionResult ApprouveRequest(int id)
        {
            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                var reservation = _reservationRepo.GetById(id);   
                reservation.Status = true;
                reservation.RequestingStudent.Count += 1;
                _reservationRepo.Update(reservation);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

        public ActionResult RejectRequest(int id)
        {
            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                var reservation = _reservationRepo.GetById(id);
                reservation.Status = false;
                _reservationRepo.Update(reservation);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            var reservationTypes = _reservationTypeRepo.GetAll();
            var absenceTypesItems = reservationTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            var model = new CreateReservationViewModel
            {
               ReservationTypes = absenceTypesItems
            };
            return View(model);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReservationViewModel model)
        {
            try
            {
                var Date = Convert.ToDateTime(model.Date);
                
                var reservationTypes = _reservationTypeRepo.GetAll().ToList();
                var reservationTypesItems = reservationTypes.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
                model.ReservationTypes = reservationTypesItems;
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
               
                var student = _userManager.GetUserAsync(User).Result;
               

                var reservationVM = new ReservationViewModel
                {
                    RequestingStudentId = student.Id,
                    Date = Date,
                    Status=null,
                    ReservationTypeId=model.ReservationTypeId

                };
                var reservation = new Reservation
                {
                    Date=reservationVM.Date,
                    RequestingStudentId=reservationVM.RequestingStudentId,
                    ReservationTypeId=reservationVM.ReservationTypeId,
                    Status=reservationVM.Status,
                };
                var isSuccuss = _reservationRepo.Create(reservation);
                if (!isSuccuss)
                {
                    ModelState.AddModelError("", "Something went wrong in the submit action");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}