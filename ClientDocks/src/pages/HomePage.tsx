
import UserAccess from "../components/UserAccess"

const HomePage = () => {
    return (
        <div>
            <h1>Home Page</h1>
            <p>Home page content goes here</p>
            <UserAccess isLogin={1} />
            <UserAccess isLogin={0} />
   
        </div>
    )
}
export default HomePage