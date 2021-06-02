using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void Create(Review review)
        {
            _reviewRepository.Create(review);
        }

        public void Delete(long reviewId)
        {
            _reviewRepository.Delete(reviewId);
        }

        public Review GetAllByClinicId(long clinicId)
        {
            return _reviewRepository.GetAllByClinic(clinicId);
        }

        public Review Get(long reviewId)
        {
            return _reviewRepository.Get(reviewId);
        }

        public List<Review> GetAll()
        {
            return _reviewRepository.GetAll();
        }

        public List<Review> GetAllByPatientId(long patientId)
        {
            return _reviewRepository.GetAllByPatient(patientId);
        }

        public void Update(Review review)
        {
            _reviewRepository.Update(review);
        }
    }
}