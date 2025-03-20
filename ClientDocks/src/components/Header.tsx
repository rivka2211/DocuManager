import React from "react";
import { AppBar, Toolbar, Tabs, Tab } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import { Link, useLocation } from "react-router-dom";

const categories = [
//   { label: "קטגוריה", path: "/category/home" },
  { label: "קטגוריה", path: "/category/about" },
  { label: "service", path: "/category/services" },
  { label: "קטגוריה", path: "/category/contact" },
  { label: "profile", path: "/profile" },
];

const getTabStyle = (theme: any, isActive: boolean) => ({
  backgroundColor: isActive ? theme.palette.secondary.main : theme.palette.primary.main,
  color: "white",
  fontSize: "2rem",
  fontWeight: "bold",
  border: `2px solid ${theme.palette.secondary.main}`,
  borderTop: "none", // Remove the border top
  minHeight: "90px",
  flex: 1, // כל טאב תופס מקום שווה
  padding: "12px 0",
  transition: "0.3s",
  "&:hover": {
    backgroundColor: isActive ? theme.palette.secondary.dark : theme.palette.primary.dark,
  },
});

const Header = () => {
  const theme = useTheme();
  const location = useLocation();
  const tabValue = categories.find(category => category.path === location.pathname)?.path || '/profile';

  return (
    <AppBar position="fixed" sx={{ backgroundColor: "transparent", boxShadow: "none", top: 0, width: "100%" }}>
      <Toolbar sx={{ justifyContent: "center", padding: 0 }}>
        <Tabs
          value={tabValue}
          textColor="primary"
        //   indicatorColor="primary"
          sx={{ width: "100%", minHeight: "auto", margin: 0, padding: 0 ,
            "& .MuiTabs-indicator": { display: "none" }, 
          }}
        >
          {categories.map((category) => (
            <Tab
              key={category.path}
              label={category.label}
              value={category.path}
              component={Link}
              to={category.path}
              sx={getTabStyle(theme, location.pathname === category.path)}
            />
          ))}
        </Tabs>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
