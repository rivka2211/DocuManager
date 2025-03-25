import { BrowserRouter as Router } from 'react-router-dom';
import { Container, CssBaseline, ThemeProvider } from '@mui/material';
import AppRoutes from './routes';
import Header from './components/Header';
import theme from './theme';


const App = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        <Header />
        <Container sx={{ mt: 4 }}>
          <AppRoutes />
        </Container>
      </Router>
    </ThemeProvider>
  );
};

export default App;
