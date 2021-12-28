import React, {FC} from "react";
import "./Navigation.sass";
import {BoardTitle} from "../BoardTitle/BoardTitle";

export const Navigation: FC = () => {
    const conferences = [
        { id: 1, title: 'Python язык сатанистов' },
        { id: 2, title: 'Личностный рост для PM' },
        { id: 3, title: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce tempor egestas enim. Aliquam justo lectus, egestas at ante vitae, semper iaculis ex. Nullam eget arcu dui. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Fusce eu ante egestas, sagittis odio sed, tempor metus. Vestibulum lorem enim, tincidunt ac enim non, lacinia pellentesque dolor. Nullam odio erat, condimentum ac nisi et, facilisis aliquam augue. Nunc in blandit libero. Integer consectetur, justo vel pretium ultrices, lectus sapien posuere ligula'},
        { id: 4, title: 'Frontend или дворник? Где больше перспектив..' }
    ]

    const cutLine = (line: string) => {
        return line.length > 50 ? line.substring(0, 50) + '...' : line;
    }

    return <nav className="navigation">
        <BoardTitle title="My Conferences" emoji="📖" />
        <div className="navigation__links">
            { conferences.map((conference) => {
                return <div key={conference.id} className="navigation-link">
                    <a href="#">{cutLine(conference.title)}</a>
                    <hr className="navigation-link__hr"/>
                </div>
            })}
        </div>
    </nav>
}