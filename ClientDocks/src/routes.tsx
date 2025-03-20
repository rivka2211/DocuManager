import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import MainScreen from "./pages/MainScreen";
import HomePage from "./pages/HomePage";


const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/home" element={<HomePage />} />
      <Route path="/category/:categoryName" element={<MainScreen />} />
    </Routes>
  );
};

export default AppRoutes;
