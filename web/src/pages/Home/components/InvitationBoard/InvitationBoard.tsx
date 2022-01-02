import React from "react";
import "./InvitationBoard.sass";

export const InvitationBoard: React.FC = () => {
    return (
        <div className="invitation-board">
            <div className="invitation-board__header">
                <h2 className="invitation-board__title">Invitations</h2>
                <div className="invitation-board__notifications">2</div>
            </div>
        </div>
    );
};
