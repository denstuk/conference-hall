import React, { useEffect } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Auth } from "./pages/Auth/Auth";
import { Conference } from "./pages/Conference/Conference";
import { Home } from "./pages/Home/Home";
import { Me } from "./pages/Me/Me";
import { Page } from "./shared/components/Page/Page";
import { Admin } from "./pages/Admin/Admin";
import { useAuth } from "./shared/hooks";
import { NotFound } from "./pages/NotFound/NotFound";

function App() {
    const { auth, user } = useAuth();
    useEffect(() => {
        auth().then();
    }, [auth]);

    return (
        <div className="application">
            <BrowserRouter>
                <Routes>
                    <Route index element={<Page content={<Home />} />} />
                    <Route path="/conferences/:id" element={<Page content={<Conference />} />} />
                    <Route path="/me" element={<Page content={<Me />} />} />
                    <Route path="/auth" element={<Auth />} />
                    {
                        user && user.role === 2 && (<Route path="/admin" element={<Page content={<Admin />} />} />)
                    }
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
