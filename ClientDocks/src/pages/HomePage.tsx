import React, { useEffect, useRef } from "react";
import "./HomePage.css"; // קובץ עיצוב מותאם אישית
import Image from "../assets/homePage.jpg"; // תמונה מותאמת אישית
import UserAccess from "../components/UserAccess";

const Home: React.FC = () => {
  const titleRef = useRef<HTMLHeadingElement | null>(null);

  // אפקט להופעת הכותרת בהדרגה
  useEffect(() => {
    if (titleRef.current) {
      titleRef.current.style.opacity = "1";
      titleRef.current.style.transform = "translateY(0)";
    }
  }, []);

  return (
    <div className="home-container">
      <h1 ref={titleRef} className="main-title">
        המסמכים שלך, מסודרים ונגישים תמיד – <span className="highlight">PaperPows</span>
      </h1>
      <p className="sub-title">
        בלי ניירת, בלי קלסרים – כל המסמכים שלך מאובטחים וזמינים בלחיצת כפתור.
      </p>

        <UserAccess isLogin={1} />

      <div className="image-container">
        <img style={{ width: '75%' }} src={Image} alt="מסמכים דיגיטליים" className="animated-image" />
      </div>

      <div className="buttons-container ">
        <div className="animated-image">
        <UserAccess isLogin={1} /> 
        </div>
        <div className="animated-image">
        <UserAccess isLogin={0} /> 
        </div>
      </div>
    </div>
  );
};

export default Home;
