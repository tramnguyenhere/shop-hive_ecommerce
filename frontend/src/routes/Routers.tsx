import React from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';

import Home from '../pages/Home';
import Products from '../pages/Products';
import ProductDetail from '../pages/ProductDetail';
import Cart from '../pages/Cart';
import Registration from '../pages/Registration';
import Checkout from '../pages/Checkout';
import Login from '../pages/Login';
import useAppSelector from '../hooks/useAppSelector';
import UserProfile from '../pages/UserProfile';
import Dashboard from '../pages/Admin/Dashboard';
import EditProductForm from '../components/Form/EditProductForm';
import CategoryManagement from '../pages/Admin/CategoryManagement';
import EditPasswordForm from '../components/Form/EditPasswordForm';

const Routers = () => {
  const currentUser = useAppSelector((state) => state.users.currentUser);
  return (
    <Routes>
      <Route path='/' element={<Navigate to='/home' />} />
      <Route path='/home' element={<Home />} />
      <Route path='/products' element={<Products />} />
      <Route path='/products/:id' element={<ProductDetail />} />
      <Route path='/cart' element={<Cart />} />
      <Route path='/register' element={<Registration />} />
      <Route
        path='/user'
        element={currentUser ? <UserProfile /> : <Navigate to='/login' />}
      />
      <Route path='user/:userId/edit_password' element={<EditPasswordForm />} />

      <Route
        path='/login'
        element={currentUser ? <Navigate to='/user' /> : <Login />}
      />
      <Route
        path='/dashboard'
        element={
          currentUser?.role === 'Admin' ? (
            <Dashboard />
          ) : (
            <Navigate to='/login' />
          )
        }
      />
      <Route
        path='/dashboard/product-management'
        element={
          currentUser?.role === 'Admin' ? (
            <Products />
          ) : (
            <Navigate to='/login' />
          )
        }
      />

      <Route
        path='/dashboard/category-management'
        element={
          currentUser?.role === 'Admin' ? (
            <CategoryManagement />
          ) : (
            <Navigate to='/login' />
          )
        }
      />
      <Route
        path='/dashboard/product-management/:id'
        element={
          currentUser?.role === 'Admin' ? (
            <EditProductForm />
          ) : (
            <Navigate to='/login' />
          )
        }
      />
    </Routes>
  );
};

export default Routers;
