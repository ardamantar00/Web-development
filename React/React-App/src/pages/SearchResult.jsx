import React, { useEffect, useState } from "react";
import { NavLink, useSearchParams } from "react-router";
import Loading from "../components/Loading";
import Pagination from "../components/Pagination";
import SimilarMovies from "./SimilarMovies";
import MovieList from "../components/MovieList";

const apiUrl = "https://api.themoviedb.org/3";
const api_key = "3989e3b7ac9a0edf8eb77399418020e5";
const page = 1;
const language = "tr-TR";
const SearchResult = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [searchParams, setSearchParams] = useSearchParams();
  const [totalPages, setTotalPages] = useState(0);
  const query = searchParams.get("q");
  const page = searchParams.get("page") || 1;
  useEffect(() => {
    async function getMovies() {
      setLoading(true);
      try {
        const response = await fetch(
          `${apiUrl}/search/movie?api_key=${api_key}&query=${query}&page=${page}&language=${language}`
        );

        if (!response.ok) {
          throw new Error("Hata Oluştu");
        }
        const data = await response.json();

        if (data.results) {
          setMovies(data.results);
          setTotalPages(data.total_pages);
        }
        setError("");
      } catch (error) {
        setError(error.message);
      }

      setLoading(false);
    }

    getMovies();
  }, [searchParams]);

  if (loading) {
    return <Loading />;
  }
  if (error) {
    return <Error message={error} />;
  }

  return (
    <>
      {" "}
      <MovieList movies={movies} title={`Arama Sonuçları: ${query}`} />
      <Pagination
        page={page}
        setSearchParams={setSearchParams}
        query={query}
        totalPages={totalPages}
      />
    </>
  );
};

export default SearchResult;
