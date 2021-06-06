using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Controller
{
    public class BedController : IEntityController<Bed>
    {
        private IBedService _bedService;

        public BedController(IBedService bedService)
        {
            _bedService = bedService;
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

        public List<Bed> GetGetAllWithRoomId(long roomId)
        {
            return _bedService.GetAllWithRoomId(roomId);
        }

        public void OccupyBed(long bedId)
        {
            _bedService.OccupyBed(bedId);
        }
    }
}
