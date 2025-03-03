// Layout.js
import React from 'react';
import { Outlet } from 'react-router-dom';

const Layout = ({children}:React.PropsWithChildren) => {
    return (
        <div>
            <h1>My App Layout</h1>
            {children}
            <Outlet />
        </div>
    );
};

export default Layout;
