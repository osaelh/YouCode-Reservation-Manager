using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouCodeReservation.Contract;
using YouCodeReservation.Data;

namespace YouCodeReservation.Repository
{
    public class ReservationTypeRepository : IReservationTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public ReservationTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(ReservationType entity)
        {
            var reservationType = _db.ReservationTypes.Add(entity);
            return Save();
        }

        public bool Delete(ReservationType entity)
        {
            var reservationType = _db.ReservationTypes.Remove(entity);
            return Save();
        }

        public List<ReservationType> GetAll()
        {
            var reservationTypes = _db.ReservationTypes.ToList();
            return reservationTypes;
        }

        public ReservationType GetById(int id)
        {
            var reservationType = _db.ReservationTypes.Find(id);
            return reservationType;
        }

        public bool IsExist(int id)
        {
            var exists = _db.ReservationTypes.Any(x => x.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(ReservationType entity)
        {
            var reservationType = _db.ReservationTypes.Update(entity);
            return Save();
        }
    }
}
