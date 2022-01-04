import React, { useEffect } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Auth } from "./pages/Auth/Auth";
import { Conference } from "./pages/Conference/Conference";
import { Home } from "./pages/Home/Home";
import { Me } from "./pages/Me/Me";
import { Page } from "./shared/components/Page/Page";
import { AuthAPI } from "./shared/api";
import { useDispatch } from "react-redux";
import { bindActionCreators } from "redux";
import { LocalStorage } from "./shared/lib/providers/local-storage";
import { authDispatchers } from "./shared/store";

function App() {
    const dispatch = useDispatch();
    const { authorize, logout } = bindActionCreators(authDispatchers, dispatch);

    useEffect(() => {
        async function checkAuthorization(): Promise<void> {
            const token = LocalStorage.get("AUTH_TOKEN");
            if (!token) {
                logout();
                return;
            }
            try {
                const user = await AuthAPI.me();
                if (user) {
                    authorize(user);
                    return;
                }
            } catch (err) {
                console.log(err);
            }
            logout();
        }
        checkAuthorization();
    }, []);

    return (
        <div className="application">
            <BrowserRouter>
                <Routes>
                    <Route index element={<Page content={<Home />} />} />
                    <Route path="/conferences/:id" element={<Page content={<Conference />} />} />
                    <Route path="/me" element={<Page content={<Me />} />} />
                    <Route path="/auth" element={<Auth />} />
                    <Route path="/admin" />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
