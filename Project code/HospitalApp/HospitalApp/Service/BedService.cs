using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public class BedService : IBedService
    {
        private readonly IBedRepository _bedRepository;

        public BedService(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

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
            throw new NotImplementedException();
        }

        public List<Bed> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Bed> GetAllWithRoomId(long roomId)
        {
            return _bedRepository.GetAllWithRoomId(roomId);
        }

        public void OccupyBed(long bedId)
        {
            _bedRepository.OccupyBed(bedId);
        }
    }
}
