import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import MainScreen from "./pages/MainScreen";
import HomePage from "./pages/HomePage";
import ProfilePage from "./pages/ProfilePage";


const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/home" element={<HomePage />} />
      <Route path="/profile" element={<ProfilePage />} />
      <Route path="/category/:categoryName" element={<MainScreen />} />
      <Route path="*" element={<Navigate to="/" />} />
    </Routes>
  );
};

export default AppRoutes;
