import { BrowserRouter as Router } from 'react-router-dom';
import { Container, CssBaseline, ThemeProvider } from '@mui/material';
import { observer } from "mobx-react";
import AppRoutes from './routes';
import Header from './components/Header';
import theme from './theme';
import { userStore } from './hooks/store/UserStore';

const App = observer(() => { // מוסיפים observer
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        {userStore.user && <Header />} 
        <Container sx={{ mt: 4 }}>
          <AppRoutes />
        </Container>
      </Router>
    </ThemeProvider>
  );
});

export default App;
