import { TextField } from '@mui/material';
import { useTheme } from '@mui/material/styles';



export default function MyTextField({ label, name, value, type, onChange }:
    { label: string, name: string, value: string, type: string, onChange: (e: React.ChangeEvent<HTMLInputElement>) => void }) {

    const theme = useTheme().palette;
    const textStyle = {
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
    }

    return (
        <TextField
            label={label}
            name={name}
            type={type}
            value={value}
            required
            margin="normal"
            variant="outlined"
            fullWidth
            onChange={onChange}
            sx={textStyle}
        />
    )
}
