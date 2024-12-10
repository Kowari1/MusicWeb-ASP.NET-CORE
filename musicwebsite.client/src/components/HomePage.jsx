import React, { useEffect, useState } from 'react';
import axios from 'axios';

function HomePage() {
  const [genres, setGenres] = useState([]);
  const [tracks, setTracks] = useState([]);
  const [selectedGenre, setSelectedGenre] = useState('');
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(0);

  const pageSize = 10;

  useEffect(() => {
    axios.get('api/home/genres')
      .then(response => setGenres(response.data))
      .catch(error => console.error('Ошибка загрузки жанров:', error));
  }, []);

  useEffect(() => {
    axios.get('api/home/tracks', {
      params: {
        genre: selectedGenre,
        page,
        pageSize,
      },
    })
      .then(response => {
        setTracks(response.data.tracks);
        setTotalCount(response.data.totalCount);
      })
      .catch(error => console.error('Ошибка загрузки треков:', error));
  }, [selectedGenre, page]);

  return (
    <div>
      <header>
        <h1>Music Website</h1>
        <div>
          <label>Выберите жанр:</label>
          <select onChange={(e) => setSelectedGenre(e.target.value)}>
            <option value="">Все жанры</option>
            {genres.map((genre, index) => (
              <option key={index} value={genre}>{genre}</option>
            ))}
          </select>
        </div>
      </header>
      <main>
        <div>
          <h2>Список треков</h2>
          {tracks.map(track => (
            <div key={track.id}>
              <p>Название: {track.title}</p>
              <p>Исполнитель: {track.artist}</p>
              <p>Жанр: {track.genre}</p>
              <p>Длительность: {track.duration}</p>
            </div>
          ))}
        </div>
        <div>
          <button
            onClick={() => setPage(prev => Math.max(prev - 1, 1))}
            disabled={page === 1}
          >
            Назад
          </button>
          <span>Страница {page}</span>
          <button
            onClick={() => setPage(prev => prev + 1)}
            disabled={page * pageSize >= totalCount}
          >
            Вперед
          </button>
        </div>
      </main>
    </div>
  );
}

export default HomePage;
