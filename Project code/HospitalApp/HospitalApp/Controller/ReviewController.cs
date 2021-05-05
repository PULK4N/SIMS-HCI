using System;
using System.Collections.Generic;

public abstract class ReviewController
{
    private readonly IReviewService _reviewService;

    protected ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    public bool CreateReview(Review review)
    {
        return _reviewService.CreateReview(review);
    }

    public bool UpdateReview(Review review)
    {
        return _reviewService.UpdateReview(review);
    }

    public bool DeleteReview(Review review)
    {
        return _reviewService.DeleteReview(review);
    }

    public Review GetReview(long reviewId)
    {
        return _reviewService.GetReview(reviewId);
    }

    public Review GetReview(Review review)
    {
        return _reviewService.GetReview(review);
    }

    public List<Review> GetReviews()
    {
        return _reviewService.GetReviews();
    }

    public List<Review> GetReviews(Patient patient)
    {
        return _reviewService.GetReviews(patient);
    }


}