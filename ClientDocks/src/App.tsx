import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './components/home_page/HomePage';
import MainPage from './components/main_page/MainPage';
import Login from './components/profile_page/Login';
import ProfilePage from './components/profile_page/ProfilePage';
import Layout from './components/LayOut';
// import { LayoutRouteProps } from 'react-router-dom';


const App = () => {
    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/login" element={<Login />} />
                    <Route path="/main" element={<MainPage />} />
                    <Route path="/profile" element={<ProfilePage />} />
                </Routes>
            </Layout>
        </Router>
    );
};

export default App;
