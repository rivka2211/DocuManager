import React, { useState } from "react";
import { observer } from "mobx-react-lite";
import { Button, Modal, Box, TextField, Typography } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import { UserStore } from "../hooks/store/userStore";

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

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };
    const btnStyle = {
        backgroundColor: isLogin==1 ? theme.primary.main : theme.secondary.main,
        color: "white",
        padding: "10px 20px",
        fontSize: "1rem",
        fontWeight: "bold",
        "&:hover": { backgroundColor: isLogin==1 ? theme.primary.dark : theme.secondary.dark },
    };

    const commonTextFieldProps = {
        fullWidth: true,
        margin: "normal",
        variant: "outlined",
        onChange: handleChange,
        sx: {
            "& .MuiOutlinedInput-root": {
                borderRadius: "8px",
                "& fieldset": {
                    borderColor: theme.primary.main, // צבע המסגרת
                },
                "&:hover fieldset": {
                    borderColor: theme.primary.dark, // צבע בעת מעבר עם העכבר
                },
                "&.Mui-focused fieldset": {
                    borderColor: theme.primary.dark, // צבע בעת פוקוס
                },
            },
        },
    };

    const handleSubmit = async () => {
        if (isLogin) {
            console.log("isLogin", formData);
            //   await UserStore.login(formData.name, formData.password);
        } else {
            console.log("isRegister", formData);
            //   await UserStore.register(formData.name, formData.email, formData.password);
        }
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

                <TextField
                    {...commonTextFieldProps}
                    label="שם משתמש"
                    name="name"
                    value={formData.name}
                />
                {isLogin>0 && (
                    <TextField
                        {...commonTextFieldProps}
                        label="אימייל"
                        name="email"
                        type="email"
                        value={formData.email}
                    />
                )}
                <TextField
                    {...commonTextFieldProps}
                    label="סיסמה"
                    name="password"
                    type="password"
                    value={formData.password}
                />
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
