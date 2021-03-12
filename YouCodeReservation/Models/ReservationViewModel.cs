using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YouCodeReservation.Data;

namespace YouCodeReservation.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        public bool? Status { get; set; }
        public Student RequestingStudent { get; set; }
        public string RequestingStudentId { get; set; }
        public ReservationType ReservationType { get; set; }
        public int ReservationTypeId { get; set; }
        public DateTime Date { get; set; }
    }
    public class CreateReservationViewModel
    {
        public List<SelectListItem> ReservationTypes { get; set; }
        [Display(Name = "Reservation Type")]
        public int ReservationTypeId { get; set; }
        public DateTime Date { get; set; }
    }

}
