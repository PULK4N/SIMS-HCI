using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public interface IReviewService : IEntityService<Review>
    {
        Review GetAllByClinicId(long clinicId);
        List<Review> GetAllByPatientId(long patientId);
    }
}