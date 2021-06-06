using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Repository
{
    public interface IReminderRepository : IEntityRepository<Reminder>
    {
        List<Reminder> GetAllByPatientId(long patientId);
    }
}
