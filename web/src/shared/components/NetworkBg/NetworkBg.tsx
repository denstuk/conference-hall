import React from "react";
import Particles from "react-tsparticles";

export const NetworkBg: React.FC = () => {
    return (
        <Particles
            id="tsparticles"
            options={{
                background: {
                    opacity: 0,
                },
                fpsLimit: 40,
                interactivity: {
                    events: {
                        onClick: {
                            enable: false,
                            mode: "grab",
                        },
                        onHover: {
                            enable: false,
                            mode: "slow",
                        },
                        resize: true,
                    },
                    modes: {
                        bubble: {
                            distance: 400,
                            duration: 2,
                            opacity: 0.8,
                            size: 50,
                        },
                        push: {
                            quantity: 4,
                        },
                        repulse: {
                            distance: 200,
                            duration: 0.8,
                        },
                    },
                },
                particles: {
                    color: {
                        value: "#fb8310",
                    },
                    links: {
                        color: "#fb8310",
                        distance: 250,
                        enable: true,
                        opacity: 0.8,
                        width: 1,
                    },
                    collisions: {
                        enable: false,
                    },
                    move: {
                        direction: "none",
                        enable: true,
                        outMode: "bounce",
                        random: false,
                        speed: 1,
                        straight: false,
                    },
                    number: {
                        density: {
                            enable: true,
                            value_area: 800,
                        },
                        value: 80,
                    },
                    opacity: {
                        value: 0.2,
                    },
                    shape: {
                        type: "edge",
                    },
                    size: {
                        random: true,
                        value: 5,
                    },
                },
                detectRetina: true,
                zLayers: 1,
            }}
        />
    );
};
