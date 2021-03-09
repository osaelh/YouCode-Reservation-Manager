using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YouCodeReservation.Data
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RequestingStudentId")]
        public Student RequestingStudent { get; set; }
        public string RequestingStudentId { get; set; }
        [ForeignKey("ReservationTypeId")]
        public ReservationType ReservationType { get; set; }
        public int ReservationTypeId { get; set; }
        public DateTime Date { get; set; }
    }
}
