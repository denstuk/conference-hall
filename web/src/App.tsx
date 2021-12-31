import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Conference } from "./pages/Conference/Conference";
import { Home } from "./pages/Home/Home";
import { Page } from "./shared/components/Page/Page";

function App() {
    return (
        <div className="application">
            <React.Fragment>
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<Page content={<Home />} />} />
                        <Route path="/conferences/:id" element={<Page content={<Conference />} />} />
                    </Routes>
                </BrowserRouter>
            </React.Fragment>
        </div>
    );
}

export default App;
