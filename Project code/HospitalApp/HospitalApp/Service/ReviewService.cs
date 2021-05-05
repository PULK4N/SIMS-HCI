using System;
using System.Collections.Generic;

public class ReviewService : IReviewService
{
   private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public bool CreateReview(Review review)
    {
        return _reviewRepository.CreateReview(review);
    }

    public bool DeleteReview(Review review)
    {
        return _reviewRepository.DeleteReview(review);
    }

    public Review GetReview(long reviewId)
    {
        return _reviewRepository.GetReview(reviewId);
    }

    public Review GetReview(Review review)
    {
        return _reviewRepository.GetReview(review);
    }

    public List<Review> GetReviews()
    {
        return _reviewRepository.GetReviews();
    }

    public List<Review> GetReviews(Patient patient)
    {
        return _reviewRepository.GetReviews(patient);
    }

    public bool UpdateReview(Review review)
    {
        return _reviewRepository.UpdateReview(review);
    }
}