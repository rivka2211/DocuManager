
import { AppBar, Toolbar, Tabs, Tab } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import { Link, useLocation } from "react-router-dom";
import { userStore } from "../hooks/store/UserStore";
import { observer } from "mobx-react";

const Header = observer(() => { 
  const theme = useTheme();
  const location = useLocation();
  const categories = userStore.user?.categories ?? []; 

  const categoryPaths = categories.map(category => ({
    ...category,
    path: `/category/${encodeURIComponent(category.name)}`,
  }));

  categoryPaths.unshift({
    name: "פרופיל", path: "/profile",
    id: 0,
    files: []
  });

  const tabValue = categoryPaths.find(category => category.path === location.pathname)?.path || "/profile";


  const getTabStyle = ( isActive: boolean) => ({
    backgroundColor: isActive ? theme.palette.secondary.main : theme.palette.primary.main,
    color: "white",
    fontSize: "clamp(0.8rem, 2.5vw, 1.5rem)", 
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

  return (
    <AppBar position="fixed" sx={{ backgroundColor: "transparent", boxShadow: "none", top: 0, width: "100%" }}>
      <Toolbar sx={{ justifyContent: "center", padding: 0 }}>
        <Tabs
          value={tabValue}
          textColor="primary"
          sx={{ width: "100%", minHeight: "auto", margin: 0, padding: 0 ,
            "& .MuiTabs-indicator": { display: "none" }, 
          }}
        >
          {categoryPaths.map((category) => (
            <Tab
              key={category.path}
              label={category.name}
              value={category.path}
              component={Link}
              to={category.path}
              sx={getTabStyle(location.pathname === category.path)}
            />
          ))}
        </Tabs>
      </Toolbar>
    </AppBar>
  );
});

export default Header;
