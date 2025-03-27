import  { useState } from 'react';
import { Box, Typography, useTheme } from '@mui/material';
import { FileDTO } from '../hooks/types';

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
        window.open(file.fileUrl, '_blank');
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
                    <Typography variant="body1">Category: {file.category.name}</Typography>
                    <Typography variant="body2">Name: {file.fileName}</Typography>
                    <Typography variant="body2">Issue Date: {file.uploadTime?.toLocaleDateString()}</Typography>
                </Box>
            ) : (
                <Typography variant="h6" color='primary'>{file.fileName}</Typography>
            )}
        </Box>
    );
};

export default OneFile;

