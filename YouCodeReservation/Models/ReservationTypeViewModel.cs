using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YouCodeReservation.Models
{
    public class ReservationTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Reservation Type Name")]
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
