import { Button, useTheme } from '@mui/material'
import { userStore } from '../hooks/store/UserStore';

function Logout() {
  const theme = useTheme().palette;

  const btnStyle = {
    backgroundColor: theme.primary.main,
    color: "white",
    padding: "10px 20px",
    fontSize: "1rem",
    fontWeight: "bold",
    "&:hover": { backgroundColor: theme.primary.dark },
  };
  
  return (
    <Button
      variant="contained"
      sx={btnStyle}
      onClick={() => userStore.logout()}
    >
      להתנתקות
    </Button>
  )
}

export default Logout