import { BrowserRouter as Router } from 'react-router-dom';
import HomePage from './pages/HomePage';
import { Container } from '@mui/material';
import Header from './components/header';
import AppRoutes from './routes';
// import { LayoutRouteProps } from 'react-router-dom';


const App = () => {
    return (
        <Router>
        <Header />
        <Container sx={{ mt: 4 }}>
          <AppRoutes />
        </Container>
      </Router>

    );
};

export default App;
