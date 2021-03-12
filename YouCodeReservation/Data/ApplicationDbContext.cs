using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YouCodeReservation.Models;

namespace YouCodeReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Student> Students { get; set; }
        public DbSet<ReservationType> ReservationTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<YouCodeReservation.Models.ReservationTypeViewModel> ReservationTypeViewModel { get; set; }
        public DbSet<YouCodeReservation.Models.ReservationViewModel> ReservationViewModel { get; set; }
    }
}
