
async function getMovies(movieTitle) {
    const url = `/api/movies/${movieTitle}`;

    const response = await fetch(url, {
        method: 'GET',
        headers: { "Content-Type": "application/json" },
    });

    const movies = await response.json();
    return movies;
}

async function getMovieTrailer(movieDetails) {
    const url = `/api/trailers/${movieDetails}`;

    const response = await fetch(url, {
        method: 'GET',
        headers: { "Content-Type": "application/json" },
    });

    const trailer = await response.json();
    return trailer;
}

export default {
    getMovies,
    getMovieTrailer
}