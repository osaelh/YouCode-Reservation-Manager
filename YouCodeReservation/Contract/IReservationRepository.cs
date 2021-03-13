using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouCodeReservation.Data;

namespace YouCodeReservation.Contract
{
   public interface IReservationRepository : IRepositoryBase<Reservation>
    {
        List<Reservation> GetReservationsByStudent(string id);
    }
}
