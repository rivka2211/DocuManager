import { BrowserRouter as Router } from 'react-router-dom';
import HomePage from './pages/HomePage';
// import { LayoutRouteProps } from 'react-router-dom';


const App = () => {
    return (
        <Router>
             <HomePage />
        </Router>
    );
};

export default App;
