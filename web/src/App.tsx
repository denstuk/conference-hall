import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Auth } from "./pages/Auth/Auth";
import { Conference } from "./pages/Conference/Conference";
import { Home } from "./pages/Home/Home";
import { Me } from "./pages/Me/Me";
import { Page } from "./shared/components/Page/Page";

function App() {
    return (
        <div className="application">
            <React.Fragment>
                <BrowserRouter>
                    <Routes>
                        <Route index element={<Page content={<Home />} />} />
                        <Route path="/conferences/:id" element={<Page content={<Conference />} />} />
                        <Route path="/me" element={<Page content={<Me />} />} />
                        <Route path="/auth" element={<Auth />} />
                        <Route path="/admin" />
                    </Routes>
                </BrowserRouter>
            </React.Fragment>
        </div>
    );
}

export default App;
