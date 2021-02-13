import React, { useState } from 'react';
import { Button, Input, ListGroup, ListGroupItem, ListGroupItemHeading, ListGroupItemText, Spinner } from 'reactstrap';
import logo from '../images/video-camera.png';
import MovieClient from '../client/MovieClient';

export const Home = () => {
    const [moviesLoading, setMoviesLoading] = useState(false);
    const [trailerLoading, setTrailerLoading] = useState(false);
    const [input, setInput] = useState('');
    const [movies, setMovies] = useState([{}]);
    const [movieTrailer, setMovieTrailer] = useState({});

    async function getMovies() {
        try {
            if (input) {
                setMoviesLoading(true);
                const movies = await MovieClient.getMovies(input);
                setMovies(movies);
                setMoviesLoading(false);

                setInput('');
            }
        } catch (error) {
            console.error(error.message);
        }

    }

    async function getMovieTrailer(movieDetails) {
        try {
            setTrailerLoading(true);
            const movieTrailer = await MovieClient.getMovieTrailer(movieDetails);
            setTrailerLoading(false);
            setMovieTrailer(movieTrailer);
        } catch (error) {
            console.error(error.message);
        }

    }

    function onKeyPress(ev) {
        if (ev.key === 'Enter') {
            getMovies(input);
        }
    }

    const listItems = movies.map((movie) =>
        <ListGroupItem tag="a" action key={movie.title + movie.year}>
            <ListGroupItemHeading>{movie.title}</ListGroupItemHeading>
            <ListGroupItemText>Cast: {movie.cast}</ListGroupItemText>
            <ListGroupItemText>Year: {movie.year}</ListGroupItemText>
            <ListGroupItemText>Rank: {movie.rank}</ListGroupItemText>
            <ListGroupItemText><img src={movie.image ? movie.image.imageUrl : movie.image} alt="Logo" /></ListGroupItemText>
            <Button onClick={() => { getMovieTrailer(movie.title + movie.year) }} color="primary">Get trailer</Button>
            {(movieTrailer.videoId && movieTrailer.movieDetails === movie.title + movie.year) ? <div className="App">
                <p>{movieTrailer.title}</p>
                <iframe
                    title={movieTrailer.title}
                    style={{
                        width: "100%",
                        height: "500px"
                    }}
                    src={`https://www.youtube.com/embed/${movieTrailer.videoId}`}
                    frameBorder="0"
                />

            </div> : ""}
            {trailerLoading ? <Spinner className="spinner" color="primary" /> : ""}
        </ListGroupItem>
    );

    return (
        <div>
            <h1>Movie Trailer Finder</h1>
            <img src={logo} alt="Logo" />
            <div className="divContainer">
                <Input className="movieInput" type="text"
                    value={input}
                    autoFocus
                    onChange={e => setInput(e.target.value)}
                    onKeyPress={e => onKeyPress(e)} placeholder="Type movie name..." />
                <Button onClick={() => { getMovies() }} color="primary">Search</Button>
            </div>
            <div>
                {moviesLoading ? <Spinner className="spinner" color="primary" /> : ""}
                {movies[0].title ? <ListGroup className="listGroup">{listItems}</ListGroup> : ""}
            </div>
        </div>
    );
}
