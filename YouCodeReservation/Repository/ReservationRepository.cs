using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouCodeReservation.Contract;
using YouCodeReservation.Data;

namespace YouCodeReservation.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _db;
        public ReservationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Reservation entity)
        {
            _db.Reservations.Add(entity);
            return Save();
        }

        public bool Delete(Reservation entity)
        {
            _db.Reservations.Remove(entity);
            return Save();
        }

        public List<Reservation> GetReservationsByStudent(string id)
        {
            return GetAll()
                .Where(q => q.RequestingStudentId == id).ToList();
                
        }

        public List<Reservation> GetAll()
        {
            var reservations = _db.Reservations.Include(q => q.ReservationType).Include(q => q.RequestingStudent).ToList();
            return reservations;
        }

        public Reservation GetById(int id)
        {
            var reservation = _db.Reservations
               .Include(q => q.RequestingStudent)
               .Include(q => q.ReservationType)
               .FirstOrDefault(q => q.Id == id);


            return reservation;
        }

        public bool IsExist(int id)
        {
            var exists = _db.Reservations.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Reservation entity)
        {
            _db.Reservations.Update(entity);
            return Save();
        }
    }
}
