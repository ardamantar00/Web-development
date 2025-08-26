import WatchListMovie from "./WatchListMovie";

export default function WatchList({ movies, title, removeFromWatchList }) {
  return (
    <>
      {
        <div className=" container  py-3">
          <h1 className="mb-3 h4">{title}</h1>
          {movies.length == 0 ? (
            <div>Film Bulunamadı</div>
          ) : (
            <div
              id="movie-list"
              className="row row-cols- row-cols-md-4 row-cols-lg-6 g-lg-2"
            >
              {movies.map((m, index) => (
                <WatchListMovie
                  key={index}
                  movieObj={m}
                  onRemoveFromWatchList={removeFromWatchList}
                />
              ))}
            </div>
          )}
        </div>
      }
    </>
  );
}
