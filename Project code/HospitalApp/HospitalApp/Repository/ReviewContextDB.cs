using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

public class ReviewContextDB : IReviewRepository
{
    public bool CreateReview(Review review)
    {
        try
        {
            HospitalDB.Instance.Reviews.Add(review);
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        catch
        {
            MessageBox.Show("Error while creating a review");
        }
        return false;
    }

    public bool DeleteReview(Review review)
    {
        try
        {
            HospitalDB.Instance.Reviews.Remove(review);
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        catch
        {
            MessageBox.Show("Error while deleting a review");
        }
        return false;
    }

    public Review GetReview(long reviewId)
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

    public Review GetReview(Review review)
    {
        try
        {
            return HospitalDB.Instance.Reviews.Find(review.ReviewId);
        }
        catch
        {
            MessageBox.Show("Error while getting a review");
        }
        return null;
    }

    public Review GetClinicReview()
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

    public List<Review> GetReviews()
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

    public List<Review> GetReviews(Patient patient)
    {
        try
        {
            return (from rev in HospitalDB.Instance.Reviews
                    select rev).Include(rev => rev.Appointment)
                    .ToList();
        }
        catch
        {

        }
        return null;
    }

    public bool UpdateReview(Review review)
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
        return true;
    }
}