using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class ReviewController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public void Create(Review review)
        {
            _reviewService.Create(review);
        }

        public void Update(Review review)
        {
            _reviewService.Update(review);
        }

        public void Delete(long reviewId)
        {
            _reviewService.Delete(reviewId);
        }

        public Review Get(long reviewId)
        {
            return _reviewService.Get(reviewId);
        }

        public List<Review> GetAll()
        {
            return _reviewService.GetAll();
        }

        public List<Review> GetAllByPatientId(long patientId)
        {
            return _reviewService.GetAllByPatientId(patientId);
        }

        public Review GetAllByClinicId(long clinicId)
        {
            return _reviewService.GetAllByClinicId(clinicId);
        }


    }
}