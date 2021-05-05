using System;
using System.Collections.Generic;

public interface IReviewService
{
    bool CreateReview(Review review);

    bool UpdateReview(Review review);

    bool DeleteReview(Review review);

    Review GetReview(long reviewId);

    List<Review> GetReviews();

    List<Review> GetReviews(Patient patient);
    Review GetReview(Review review);
}