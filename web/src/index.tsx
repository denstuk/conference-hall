import React from "react";
import ReactDOM from "react-dom";
import "./shared/styles/index.sass";
import 'react-toastify/dist/ReactToastify.css';
import App from "./App";
import { Provider } from "react-redux";
import { store } from "./shared/store";
import {ToastContainer} from "react-toastify";

ReactDOM.render(
    <React.StrictMode>
        <Provider store={store}>
            <App />
            <ToastContainer />
        </Provider>
    </React.StrictMode>,
    document.getElementById("root")
);
