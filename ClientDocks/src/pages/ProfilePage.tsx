import UserAccess from "../components/UserAccess"
import { userStore } from "../hooks/store/userStore"

const ProfilePage = () => {

   const user=userStore.user
    return (
        <div>
            <h1>Profile Page</h1>
            <h2>{user?.name}</h2>
            <h2>{user?.email}</h2>
            <h3>{user?.categories.map((category)=>category.name).join(", ")}</h3>
            <h4>{user?.categories.map((category)=>category.files.map((file)=>file.fileName).join(", ")).join(", ")}</h4>
            <UserAccess isLogin={2} />
        </div>
    )
}
export default ProfilePage