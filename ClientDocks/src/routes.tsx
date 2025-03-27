
import { Routes, Route, Navigate, Outlet } from "react-router-dom";
import MainScreen from "./pages/MainScreen";
import HomePage from "./pages/HomePage";
import ProfilePage from "./pages/ProfilePage";
import { observer } from "mobx-react";
import { userStore } from "./hooks/store/UserStore";

export const ProtectedRoute = observer(() => {
  return userStore.user ? <Outlet /> : <Navigate to="/" />;
});
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
