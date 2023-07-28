import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";

import Home from "../pages/Home";
import Products from "../pages/Products";
import ProductDetail from "../pages/ProductDetail";
import Cart from "../pages/Cart";
import Registration from "../pages/Registration";
import Checkout from "../pages/Checkout";
import Login from "../pages/Login";
import useAppSelector from "../hooks/useAppSelector";
import UserProfile from "../pages/UserProfile";
import Dashboard from "../pages/Admin/Dashboard";
import EditProductForm from "../components/Form/EditProductForm";
import CategoryManagement from "../pages/Admin/CategoryManagement";

const Routers = () => {
  const currentUser = useAppSelector((state) => state.users.currentUser);
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/home" />} />
      <Route path="/home" element={<Home />} />
      <Route path="/products" element={<Products />} />
      <Route path="/products/:id" element={<ProductDetail />} />
      <Route path="/cart" element={<Cart />} />
      <Route path="/register" element={<Registration />} />
      <Route path="/checkout" element={<Checkout />} />
      <Route
        path="/user"
        element={currentUser ? <UserProfile /> : <Navigate to="/login" />}
      />
      <Route
        path="/login"
        element={currentUser ? <Navigate to="/user" /> : <Login />}
      />
      <Route
        path="/dashboard"
        element={
          currentUser?.role === "admin" ? (
            <Dashboard />
          ) : (
            <Navigate to="/login" />
          )
        }
      />
      <Route
        path="/dashboard/product-management"
        element={
          currentUser?.role === "admin" ? (
            <Products />
          ) : (
            <Navigate to="/login" />
          )
        }
      />
      <Route
        path="/dashboard/category-management"
        element={
          currentUser?.role === "admin" ? (
            <CategoryManagement />
          ) : (
            <Navigate to="/login" />
          )
        }
      />
      <Route
        path="/dashboard/product-management/:id"
        element={
          currentUser?.role === "admin" ? (
            <EditProductForm />
          ) : (
            <Navigate to="/login" />
          )
        }
      />
    </Routes>
  );
};

export default Routers;
