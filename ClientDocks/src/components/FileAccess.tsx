import { Box, Button, Modal, Typography, useTheme } from "@mui/material";
import { useState } from "react";
import MyTextField from "./MyTextField";
import { observer } from "mobx-react";
import { userStore } from "../hooks/store/UserStore";


const FileAccess = observer(({ actionType }: { actionType: number }) => {
    //0=update 1=global, 2+=in-category
    const AllText = {
        btn: ["לעדכון פרטי הקובץ", "להוספת קובץ"],
        title: ["עדכון פרטים", "הוספה"],
        submit: ["עדכן", "הוסף"],
    }

    const theme = useTheme().palette;
    const [open, setOpen] = useState(false);
    const [formData, setFormData] = useState({ name: "", URL: "", category: "" });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };
    const btnStyle = {
        backgroundColor: theme.primary.main,
        color: "white",
        padding: "10px 20px",
        fontSize: "1rem",
        fontWeight: "bold",
        "&:hover": { backgroundColor: theme.primary.dark },
    };

    function handleSubmit(): void {
        console.log("formData", formData);
        let currentCategory = actionType;
        if (actionType < 2) {
            const categories = userStore.user?.categories;
            currentCategory = categories?.find((category) => category.name === formData.category)?.id||0;
        }
        console.log("currentCategory", currentCategory);
        
        setOpen(false);
    }

    return (<>
        <Button
            variant="contained"
            sx={btnStyle}
            onClick={() => setOpen(true)}
        >
            {AllText.btn[actionType === 0 ? 0 : 1]}
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
                    {AllText.btn[actionType === 0 ? 0 : 1]}
                </Typography>

                <MyTextField label="שם משתמש" name="name" type="text"
                    value={formData.name} onChange={handleChange} />
                <MyTextField label="ניתוב לקובץ" name="URL" type="URL"
                    value={formData.URL} onChange={handleChange} />
                {actionType > 0 && (
                    <MyTextField label="קטגוריה" name="category" type="text"
                        value={formData.category} onChange={handleChange} />
                )}
                <Button
                    fullWidth
                    variant="contained"
                    sx={btnStyle}
                    style={{ backgroundColor: theme.secondary.main }}
                    onClick={handleSubmit}
                >
                    {AllText.submit[actionType === 0 ? 0 : 1]}
                </Button>
            </Box>
        </Modal>

    </>);
})

export default FileAccess
