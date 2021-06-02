using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IReviewRepository : IEntityRepository<Review>
    {
        Review GetAllByClinic(long clinicId);
        List<Review> GetAllByPatient(long patientId);
    }
}