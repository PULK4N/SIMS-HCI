using System;
using System.Collections.Generic;

public interface IReviewRepository
{
    bool CreateReview(Review review);

    bool UpdateReview(Review review);

    bool DeleteReview(Review review);

    Review GetReview(long reviewId);

    List<Review> GetReviews();
    Review GetClinicReview();
    List<Review> GetReviews(Patient patient);
    Review GetReview(Review review);
}