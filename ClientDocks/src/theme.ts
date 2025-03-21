import { createTheme } from "@mui/material/styles";

const theme = createTheme({
    palette: {
        primary: {
              main: "#1E499F", // כחול
            // main: "#0A3D91"
        },
        secondary: {
            main: "#FFCD05", // צהוב
        },
        background: {
            default: "#f5f5f5", // רקע אפור בהיר
        },
    },
});

export default theme;
