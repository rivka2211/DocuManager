import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import MainScreen from "./pages/MainScreen";


const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/category/home" replace />} />
      <Route path="/category/:categoryName" element={<MainScreen />} />
    </Routes>
  );
};

export default AppRoutes;
