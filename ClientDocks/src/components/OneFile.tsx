import  { useState } from 'react';
import { Box, Typography, useTheme } from '@mui/material';
import { FileDTO } from '../hooks/types';

//    const file: FileDTO = {
//         name: "Sample File.pdf",
//         userId: 0,
//         category: "General",
//         url: "https://docs.google.com/document/d/1sT3EvCZ6gF4eQHxACKDrqUuayCz_hniOSMEI-y0rVGU/edit?tab=t.0",
//         UploadDate: new Date(),
//         IssueDate: new Date()
//     };
const OneFile = (file:FileDTO) => {
    const theme=useTheme();
    const [hover, setHover] = useState(false);

    const fileStyle = {
        width: 300,
        height: 100,
        border: !hover ? `2px solid ${theme.palette.primary.main}`:"",
        backgroundColor: hover ? theme.palette.secondary.main : theme.palette.background.default,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        cursor: 'pointer',
        transition: 'background-color 0.5s',
    }


    const handleOpenFile = () => {
        window.open(file.url, '_blank');
    };

    return (
        <Box
            sx={fileStyle}
            onMouseEnter={() => setHover(true)}
            onMouseLeave={() => setHover(false)}
            onClick={handleOpenFile}
        >
            {hover ? (
                <Box sx={{ width: 200,height: 60, textAlign: 'center' }}>
                    <Typography variant="body1">Category: {file.category}</Typography>
                    <Typography variant="body2">Name: {file.name}</Typography>
                    {/* <Typography variant="body2">Size: {file.size} bytes</Typography> */}
                    <Typography variant="body2">Issue Date: {file.IssueDate?.toLocaleDateString()}</Typography>
                </Box>
            ) : (
                <Typography variant="h6" color='primary'>{file.name}</Typography>
            )}
        </Box>
    );
};

export default OneFile;

