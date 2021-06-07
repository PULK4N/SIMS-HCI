using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Repository
{
    public class BedRepository : IBedRepository
    {
        public void Create(Bed tObject)
        {
            throw new NotImplementedException();
        }

        public void Update(Bed tObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Bed Get(long id)
        {
            return (from b in HospitalDB.Instance.Bed where b.BedId == id select b).FirstOrDefault();
        }

        public List<Bed> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Bed> GetAllWithRoomId(long roomId)
        {
            return (from b in HospitalDB.Instance.Bed where b.RoomId == roomId select b).ToList();
        }

        public void OccupyBed(long bedId)
        {
            Bed BedToOccupy = Get(bedId);
            BedToOccupy.IsAvailable = false;
            HospitalDB.Instance.SaveChanges();
        }
    }
}
