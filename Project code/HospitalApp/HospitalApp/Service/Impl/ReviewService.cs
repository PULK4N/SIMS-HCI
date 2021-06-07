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
        {//we don't want to change appointment, it's unnecessary and should stay fixed, same applies to ReviewType
            Review oldReviewData = _reviewRepository.Get(review.ReviewId);
            if(oldReviewData != null)
            {
                oldReviewData.Score = review.Score;
                oldReviewData.Comment = review.Comment;
                //updatedReview.Appointment = review.Appointment;
                _reviewRepository.Update(review);
            }
        }
    }
}