import { useParams } from "react-router-dom";
import { Typography, Box } from "@mui/material";
import OneFile from "../components/OneFile";
import { userStore } from "../hooks/store/UserStore";
import FileAccess from "../components/FileAccess";

  
const MainScreen = () => {
  const { categoryName } = useParams<{ categoryName: string }>();
  const categories = userStore.user?.categories;
  const currentCategory = categories?.find((category) => category.name === categoryName);
  const files = currentCategory?.files ?? [];

  return (
    <Box sx={{ p: 4 }}>
      <FileAccess actionType={currentCategory?.id||1} />
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
