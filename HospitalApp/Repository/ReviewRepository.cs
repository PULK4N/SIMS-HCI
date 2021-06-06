using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace HospitalApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        public void Create(Review review)
        {
            try
            {
                HospitalDB.Instance.Reviews.Add(review);
                HospitalDB.Instance.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error while creating a review");
            }
        }

        public void Delete(long reviewId)
        {
            try
            {
                HospitalDB.Instance.Reviews.Remove(Get(reviewId));
                HospitalDB.Instance.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error while deleting a review");
            }
        }

        public Review Get(long reviewId)
        {
            try
            {
                return HospitalDB.Instance.Reviews.Find(reviewId);
            }
            catch
            {
                MessageBox.Show("Error while getting a review");
            }
            return null;
        }

        public Review GetAllByClinic(long clinicId)
        {
            try
            {
                return (from rev in HospitalDB.Instance.Reviews where rev.ReviewType == Enums.ReviewType.CLINIC select rev).FirstOrDefault();
            }
            catch
            {
                MessageBox.Show("Error while getting clinic review");
            }
            return null;
        }

        public List<Review> GetAll()
        {
            try
            {
                return (from rev in HospitalDB.Instance.Reviews
                        select rev).ToList();
            }
            catch
            {

            }
            return null;
        }

        public List<Review> GetAllByPatient(long patientId)
        {
            try
            {
                return (from rev in HospitalDB.Instance.Reviews
                        where rev.Appointment.Patient.PatientId == patientId
                        select rev).Include(rev => rev.Appointment)
                        .ToList();
            }
            catch
            {

            }
            return null;
        }

        public void Update(Review review)
        {
            try
            {//we don't want to change appointment, it's unnecessary and should stay fixed, same applies to ReviewType
                Review updatedReview = HospitalDB.Instance.Reviews.Find(review.ReviewId);
                updatedReview.Score = review.Score;
                updatedReview.Comment = review.Comment;
                //updatedReview.Appointment = review.Appointment;
                HospitalDB.Instance.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error while updating clinic review");
            }
        }
    }
}