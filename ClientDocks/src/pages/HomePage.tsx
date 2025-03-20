import { Box } from "@mui/material"
import OneFile from "../components/OneFile"

const HomePage = () => {
    return (
        <div>
            <h1>Home Page</h1>
            <p>Home page content goes here</p>
            <Box sx={{display: 'flex', flexWrap: 'wrap',gap:'15px',}}>
            <OneFile/>
            <OneFile/>
            <OneFile/>
            <OneFile/>
            </Box>
        </div>
        // <DashboardLayoutBasic />
        // <div className="grid_img">
        //     <h1>home_page</h1>
        //     {/* <UserProfile /> */}
        //     {/* <HomePageImages /> */}
    )
}
export default HomePage