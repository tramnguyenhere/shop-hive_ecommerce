import { PayloadAction, createSlice } from "@reduxjs/toolkit";

import { Review } from "../../types/Review";

const initialState: { reviews: Review[] } = {
  reviews: [
    // {
    //   id: "abc1243",
    //   name: "Tram Nguyen",
    //   email: "tram@gmail.com",
    //   feedback: "Very good",
    //   productId: 1,
    // },
    // {
    //   id: "abc456",
    //   name: "John Doe",
    //   email: "johndoe@gmail.com",
    //   feedback: "Good",
    //   productId: 2,
    // },
  ],
};

const reviewSlice = createSlice({
  name: "reviews",
  initialState,
  reducers: {
    appendReview(state, action: PayloadAction<Review>) {
      state.reviews.push(action.payload);
    },
  },
});

const reviewReducer = reviewSlice.reducer;

export const { appendReview } = reviewSlice.actions;
export default reviewReducer;
