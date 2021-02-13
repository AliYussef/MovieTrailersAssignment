import React from 'react';
import logo from '../images/video-camera.png';

export const About = () => {
    return (
        <div className="about">
            <h1>Movie Trailer Finder</h1>
            <p className="aboutPar">Helps you find a movie details alongside with its available official trailer</p>
            <img src={logo} alt="Logo" />
        </div>
    );
}