import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { ThemeProvider } from '@emotion/react'
import { CssBaseline } from '@mui/material'
import theme from './theme.ts'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ThemeProvider theme={theme}>
    <CssBaseline /> {/* נותן רקע דיפולטי לפי ההגדרות */}
    <App />
    </ThemeProvider>
  </StrictMode>,
)
