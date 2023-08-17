import React from "react";

import { Review } from "../types/Review";
import { hideEmail } from "../utils/hideEmail";

const SingleReview = ({
  name,
  email,
  feedback,
}: Omit<Review, "id" | "productId">) => {
  const hiddenEmail = hideEmail(email ?? "");
  return (
    <div className="single-review">
      <p className="single-review__name">{name}</p>
      <p className="single-review__email">{hiddenEmail}</p>
      <p className="single-review__feedback">"{feedback}"</p>
    </div>
  );
};

export default SingleReview;
