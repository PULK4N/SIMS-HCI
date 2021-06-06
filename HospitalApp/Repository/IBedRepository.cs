using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Repository
{
    public interface IBedRepository : IEntityRepository<Bed>
    {
        List<Bed> GetAllWithRoomId(long roomId);
        void OccupyBed(long bedId);
    }
}
