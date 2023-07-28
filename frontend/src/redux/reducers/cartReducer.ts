import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { v4 as uuidv4 } from "uuid";

import { CartItem, CartType } from "../../types/Cart";
import { Product } from "../../types/Product";

const initialState: CartType = {
  items: [],
  totalAmount: 0,
  totalQuantity: 0,
  isSideCartVisible: false,
  shippingFee: 0,
  cartId: "",
};

const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {
    addItemToCart: (state, action: PayloadAction<Product>) => {
      const newItem = action.payload;
      const existingItem = state.items.find((item) => item.id === newItem.id);

      if (existingItem) {
        existingItem.quantity += 1;
        existingItem.amount = existingItem.quantity * existingItem.price;
      } else {
        const cartItem: CartItem = {
          ...newItem,
          quantity: 1,
          amount: newItem.price,
          cartId: uuidv4(),
        };
        state.items.push(cartItem);
      }

      state.totalQuantity += 1;
      state.totalAmount += newItem.price;
    },
    removeItemFromCart: (state, action: PayloadAction<string>) => {
      const cartItemId = action.payload;
      const index = state.items.findIndex((item) => item.cartId === cartItemId);
      if (index !== -1) {
        const removedItem = state.items.splice(index, 1)[0];
        state.totalQuantity -= removedItem.quantity;
        state.totalAmount -= removedItem.amount;
      }
    },
    setItemQuantity: (
      state,
      action: PayloadAction<{ cartItemId: string; quantity: number }>
    ) => {
      const cartItemId = action.payload.cartItemId;
      const itemQuantity = action.payload.quantity;
      const item = state.items.find((item) => item.cartId === cartItemId);
      if (item) {
        item.quantity = itemQuantity;
        item.amount = item.quantity * item.price;
        state.totalQuantity += itemQuantity;
        state.totalAmount += itemQuantity * item.price;
      }
    },
    increaseItemQuantity: (state, action: PayloadAction<string>) => {
      const cartItemId = action.payload;
      const item = state.items.find((item) => item.cartId === cartItemId);
      if (item && item.quantity < 99) {
        item.quantity += 1;
        item.amount = item.quantity * item.price;
        state.totalQuantity += 1;
        state.totalAmount += item.price;
      } else {
        alert(
          "Please contact the customer service hotline for wholesale purchase!"
        );
      }
    },
    decreaseItemQuantity: (state, action: PayloadAction<string>) => {
      const cartItemId = action.payload;
      const index = state.items.findIndex((item) => item.cartId === cartItemId);
      const item = state.items.find((item) => item.cartId === cartItemId);
      if (item && item.quantity > 1) {
        item.quantity -= 1;
        item.amount = item.quantity * item.price;
        state.totalQuantity -= 1;
        state.totalAmount -= item.price;
      } else if (item && item.quantity === 1) {
        const removedItem = state.items.splice(index, 1)[0];
        state.totalQuantity -= removedItem.quantity;
        state.totalAmount -= removedItem.amount;
      }
    },
    manageSideCartVisible: (state, action: PayloadAction<boolean>) => {
      state.isSideCartVisible = action.payload;
    },
    checkoutCart: (state) => {
      state = { ...state, cartId: uuidv4() };
    },
  },
});

export const {
  addItemToCart,
  removeItemFromCart,
  setItemQuantity,
  increaseItemQuantity,
  decreaseItemQuantity,
  manageSideCartVisible,
  checkoutCart,
} = cartSlice.actions;

export default cartSlice.reducer;
