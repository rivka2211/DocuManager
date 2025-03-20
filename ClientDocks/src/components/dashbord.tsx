import { extendTheme } from '@mui/material/styles';
import DashboardIcon from '@mui/icons-material/Dashboard';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import BarChartIcon from '@mui/icons-material/BarChart';
import DescriptionIcon from '@mui/icons-material/Description';
import LayersIcon from '@mui/icons-material/Layers';
import { AppProvider, Navigation } from '@toolpad/core/AppProvider';
import { DashboardLayout } from '@toolpad/core/DashboardLayout';
import { PageContainer } from '@toolpad/core/PageContainer';
import { useNavigate, useLocation } from 'react-router-dom';


const myCategories = ["חשמל", "מים", "גז", "אינטרנט", "טלפון", "ארנונה", "כללי"];
const myIcons = [<DashboardIcon />, <ShoppingCartIcon />, <BarChartIcon />, <DescriptionIcon />, <LayersIcon />];

const MYNAVIGATION: Navigation = myCategories.map((category, index) => {
    return { segmant: category, title: category, icon: myIcons[index] };
});
const NAVIGATION: Navigation = [
    {
        kind: 'header',
        title: 'Main items',
    },
    {
        segment: 'dashboard',
        title: myCategories[0],
        icon: <DashboardIcon />,
    },
    {
        segment: 'orders',
        title: 'Orders',
        icon: <ShoppingCartIcon />,
    },
    {
        kind: 'divider',
    },
    {
        kind: 'header',
        title: 'Analytics',
    },
    {
        segment: 'reports',
        title: 'Reports',
        icon: <BarChartIcon />,
        children: [
            {
                segment: 'sales',
                title: 'Sales',
                icon: <DescriptionIcon />,
            },
            {
                segment: 'traffic',
                title: 'Traffic',
                icon: <DescriptionIcon />,
            },
        ],
    },
    {
        segment: 'integrations',
        title: 'Integrations',
        icon: <LayersIcon />,
    },
];

const demoTheme = extendTheme({
    colorSchemes: { light: true, dark: true },
    colorSchemeSelector: 'class',
    breakpoints: {
        values: {
            xs: 0,
            sm: 600,
            md: 600,
            lg: 1200,
            xl: 1536,
        },
    },
});


function useDemoRouter() {
    const navigate = useNavigate();
    const location = useLocation();

    const router = {
        pathname: location.pathname,
        searchParams: new URLSearchParams(location.search),
        navigate: (path: string | URL) => navigate(path),
    };

    return router;
}

export default function DashboardLayoutBasic(props: any) {

    const router = useDemoRouter();

    return (
        <AppProvider
            navigation={MYNAVIGATION}
            router={router}
            theme={demoTheme}
        >
            <DashboardLayout>
                <PageContainer>
                    <div>my dashboard</div>
                </PageContainer>
            </DashboardLayout>
        </AppProvider>
    );
}
