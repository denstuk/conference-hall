import React from "react";
import {Home} from "./pages/Home/Home";
import {Page} from "./shared/components/Page/Page";

function App() {
    return <div className="App">
        <Page content={<Home />} />
    </div>;
}

export default App;
