import React, { useState } from "react";
import { observer } from "mobx-react-lite";
import { Button, Modal, Box, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import MyTextField from "./MyTextField";
import { userStore } from "../hooks/store/UserStore";
import { useNavigate } from 'react-router-dom';

const UserAccess = observer(({ isLogin }: { isLogin: number }) => {
    //2=update 1=register, 0=login
    const AllText = {
        btn: ["לכניסה לאזור האישי", "להצטרפות", "לעדכון פרטים"],
        title: ["התחברות", "הרשמה", "עדכון פרטים"],
        submit: ["התחבר", "הירשם", "עדכן"],
    }
    const theme = useTheme().palette;
    const [open, setOpen] = useState(false);
    const [formData, setFormData] = useState({ name: "", email: "", password: "" });
    const navigate = useNavigate();

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };
    const btnStyle = {
        backgroundColor: isLogin == 1 ? theme.primary.main : theme.secondary.main,
        color: "white",
        padding: "10px 20px",
        fontSize: "1rem",
        fontWeight: "bold",
        "&:hover": { backgroundColor: isLogin == 1 ? theme.primary.dark : theme.secondary.dark },
    };

    const handleSubmit = async () => {
        if (isLogin === 0) {
            await userStore.login(formData.name, formData.password);
            console.log("isLogin", formData);
        } else if (isLogin === 1) {
            await userStore.register(formData.name, formData.email, formData.password);
            console.log("isRegister", formData);
        } else {
            await userStore.update(formData.name, formData.email, formData.password);
            console.log("isUpdate", formData);
        }
        navigate("/profile");
        setOpen(false);
    };


    return (<>
        <Button
            variant="contained"
            sx={btnStyle}
            onClick={() => setOpen(true)}
        >
            {AllText.btn[isLogin]}
        </Button>

        <Modal open={open} onClose={() => setOpen(false)}>
            <Box
                sx={{
                    position: "absolute",
                    top: "50%",
                    left: "50%",
                    transform: "translate(-50%, -50%)",
                    bgcolor: theme.background.default,
                    p: 4,
                    boxShadow: 24,
                    width: 300,
                    textAlign: "center",
                }} >
                <Typography variant="h5" sx={{ mb: 2, color: theme.secondary.main }}>
                    {AllText.title[isLogin]}
                </Typography>

                <MyTextField label="שם משתמש" name="name" type="text"
                    value={formData.name} onChange={handleChange} />
                {isLogin > 0 && (
                    <MyTextField label="אימייל" name="email" type="email"
                        value={formData.email} onChange={handleChange} />
                )}
                <MyTextField label="סיסמה" name="password" type="password"
                    value={formData.password} onChange={handleChange} />
                <Button
                    fullWidth
                    variant="contained"
                    sx={btnStyle}
                    style={{ backgroundColor: theme.secondary.main }}
                    onClick={handleSubmit}
                >
                    {AllText.submit[isLogin]}
                </Button>
            </Box>
        </Modal>

    </>);
});

export default UserAccess;
