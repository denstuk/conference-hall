import React from "react";
import "./CreateBoard.sass";
import {Title} from "../../../../shared/components/Title/Title";
import {Toaster} from "../../../../shared/lib/providers/toaster";
import {ConferencesAPI} from "../../../../shared/api";

export const CreateBoard: React.FC = () => {
    const [title, setTitle] = React.useState("");

    const onSubmitBtnClick = async (): Promise<void> => {
        if (!title) return Toaster.error("Conference title cannot be empty");
        await ConferencesAPI.create.bind(ConferencesAPI)({ title });
        setTitle("");
    }

    return (
        <div className="create-board">
            <Title text="Create Conference" />
            <div className="create-board__input">
                <p>Title:</p>
                <input value={title} onChange={(e) => setTitle(e.target.value)} />
            </div>
            <div className="create-board__submit">
                <button onClick={() => onSubmitBtnClick()}>Ok</button>
            </div>
        </div>
    )
}
