import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router";
import MovieDetails from "./pages/MovieDetails";
import Home from "./pages/Home";
import Movies from "./pages/Movies";
import MainLayout from "./layouts/MainLayout";

import SearchResult from "./pages/SearchResult";
import UserWatchList from "./pages/UserWatchList";
import Register from "./pages/Register";
import Login from "./pages/LoginState";

const routes = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    children: [
      { index: true, element: <Home /> },
      { path: "/movies", element: <Movies /> },
      { path: "/movies/:id", element: <MovieDetails /> },
      { path: "/search/", element: <SearchResult /> },
      { path: "watchlist", element: <UserWatchList /> },
      { path: "login", element: <Login /> },
      { path: "register", element: <Register /> },
    ],
  },
]);

function App() {
  return <RouterProvider router={routes} />;
}

export default App;
