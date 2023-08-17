import React, { useState, useEffect } from "react";

import SingleReview from "../SingleReview";
import { Review } from "../../types/Review";
import { Product } from "../../types/Product";
import useAppSelector from "../../hooks/useAppSelector";
import ReviewForm from "../Form/ReviewForm";
import useAppDispatch from "../../hooks/useAppDispatch";
import { fetchAllReviews } from "../../redux/reducers/reviewReducer";

const ProductDescription = ({
  selectedProduct,
}: {
  selectedProduct?: Product;
}) => {
  const [tab, setTab] = useState("description");
  const reviews = useAppSelector((state) => state.reviews.reviews).filter(
    (review: Review) => review.productId === selectedProduct?.id
  );

  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchAllReviews());
  }, [dispatch])
  
  console.log(reviews)

  return (
    <section className="product-description">
      <nav className="product-description__tab">
        <h2
          className={`product-description__tab__header ${
            tab === "description" ? "tab__active" : ""
          }`}
          onClick={() => setTab("description")}
        >
          Description
        </h2>
        <h2
          className={`product-description__tab__header ${
            tab === "description" ? "" : "tab__active"
          }`}
          onClick={() => setTab("review")}
        >
          Review
        </h2>
      </nav>
      {tab === "description" ? (
        <div className="product-description__tab__content">
          <p>{selectedProduct?.description}</p>
        </div>
      ) : (
        <div className="product-description__tab__review">
          {reviews.length !== 0 && (
            <div className="reviews">
              {reviews.map((review: Review) => (
                <div key={review.id}>
                  <SingleReview
                    name={review.name}
                    email={review.email}
                    feedback={review.feedback}
                  />
                </div>
              ))}
            </div>
          )}
          <ReviewForm productId={selectedProduct?.id} />
        </div>
      )}
    </section>
  );
};

export default ProductDescription;
