import { Container, Box, Typography, keyframes } from "@mui/material";
import Image from "../assets/homePage.jpg"; // תמונה מותאמת אישית
import UserAccess from "../components/UserAccess";

const floatUp = keyframes`
  0% { transform: translateY(0px); }
  100% { transform: translateY(-10px); }
`;

const HomePage = () => (
  <Container sx={{ textAlign: 'center', background: 'linear-gradient(90deg, #1E499F 50%, #FFCD05 50%)', color: 'white', minHeight: '100vh', display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', padding: '20px' }}>
    <Typography variant="h2" sx={{ fontSize: { xs: '1.5rem', sm: '2.5rem', md: '3.5rem' }, fontWeight: 'bold', marginBottom: '20px', opacity: 1, transform: 'translateY(0)', transition: 'opacity 1s ease-out, transform 1s ease-out' }}>
      המסמכים שלך, מסודרים ונגישים תמיד –
    </Typography>
    <Typography variant="h1" sx={{ background: 'linear-gradient(90deg, #FFCD05 50%, #1E499F 50%)', WebkitBackgroundClip: 'text', color: 'transparent', fontFamily: 'math', fontSize: { xs: '3rem', sm: '4rem', md: '5rem' }, fontWeight: 'bold', marginBottom: '20px' }}>
      PaperPows
    </Typography>
    <Typography variant="h5" sx={{ fontSize: '1.5rem', maxWidth: '600px', marginBottom: '30px' }}>
      בלי ניירת, בלי קלסרים – כל המסמכים שלך מאובטחים וזמינים בלחיצת כפתור.
    </Typography>
    <Box component="img" sx={{ width: '75%', height: 'auto', boxShadow: '0 10px 20px rgba(0, 0, 0, 0.2)', animation: `${floatUp} 3s infinite alternate ease-in-out`, margin: '30px 0' }} src={Image} alt="מסמכים דיגיטליים" />
    <Box sx={{ display: 'flex', gap: '20px' }}>
      <UserAccess isLogin={1} />
      <UserAccess isLogin={0} />
    </Box>
  </Container>
);

export default HomePage;