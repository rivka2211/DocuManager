import UserAccess from "../components/UserAccess"

const ProfilePage = () => {
    return (
        <div>
            <h1>Profile Page</h1>
            <p>Profile page content goes here</p>
            <p>here will be user profile details </p>
            <UserAccess isLogin={2} />
        </div>
    )
}
export default ProfilePage