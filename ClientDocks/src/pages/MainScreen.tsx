import React from "react";
import { useParams } from "react-router-dom";
import { Typography, Box } from "@mui/material";
import { FileDTO } from "../hooks/types";
import OneFile from "../components/OneFile";

const fileSets: Record<string, FileDTO[]> = {
    home: [
        { id: 1, name: "קובץ 1", userId: 101, size: "2MB", category: "home", url: "/files/sample.pdf", UploadDate: new Date("2024-03-20") },
        { id: 2, name: "קובץ 2", userId: 102, size: "1.5MB", category: "home", url: "/files/sample.pdf", UploadDate: new Date("2024-03-18") },
    ],
    about: [
        { id: 3, name: "קובץ A", userId: 103, size: "3MB", category: "about", url: "/files/sample.pdf", UploadDate: new Date("2024-03-15") },
    ],
    services: [
        { id: 4, name: "שירות 1", userId: 104, size: "5MB", category: "services", url: "/files/sample.pdf", UploadDate: new Date("2024-03-10") },
        { id: 5, name: "שירות 2", userId: 105, size: "4MB", category: "services", url: "/files/sample.pdf", UploadDate: new Date("2024-03-05") },
    ],
    contact: [
        { id: 6, name: "פרטי יצירת קשר", userId: 106, size: "500KB", category: "contact", url: "/files/sample.pdf", UploadDate: new Date("2024-02-28") },
    ],
};
  

const MainScreen = () => {
  const { categoryName } = useParams<{ categoryName: string }>();
  const files = fileSets[categoryName || "home"] || [];

  return (
    <Box sx={{ p: 4 }}>
      <Typography variant="h4">קטגוריה: {categoryName}</Typography>
      <ul>
    {files.map((file) => (
        <OneFile key={file.id} {...file} />
      ))}
      </ul>
    </Box>
  );
};

export default MainScreen;
