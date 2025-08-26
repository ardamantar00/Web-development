import React, { useEffect, useState } from "react";
import { NavLink } from "react-router";
import Loading from "../components/Loading";
import Movie from "../components/Movie";
import SimilarMovies from "./SimilarMovies";
import MovieList from "../components/MovieList";

const apiUrl = "https://api.themoviedb.org/3";
const api_key = "3989e3b7ac9a0edf8eb77399418020e5";
const page = 1;
const language = "tr-TR";
const Movies = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  useEffect(() => {
    async function getMovies() {
      setLoading(true);
      try {
        const response = await fetch(
          `${apiUrl}/movie/popular?api_key=${api_key}&page=${page}&language=${language}`
        );

        if (!response.ok) {
          throw new Error("Hata Oluştu");
        }
        const data = await response.json();

        if (data.results) {
          setMovies(data.results);
        }
        setError("");
      } catch (error) {
        setError(error.message);
      }

      setLoading(false);
    }

    getMovies();
  }, []);

  if (loading) {
    return <Loading />;
  }
  if (error) {
    return <Error message={error} />;
  }

  return <MovieList movies={movies} title={"Popüler Filmler"} />;
};

export default Movies;
