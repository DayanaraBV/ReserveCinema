import React, { useEffect, useState } from 'react';
import { getShows } from '../services/api';

const ShowList = ({ onSelectShow }) => {
  const [shows, setShows] = useState([]);

  useEffect(() => {
    const fetchShows = async () => {
      try {
        const data = await getShows();
        setShows(data);
      } catch (error) {
        console.error('Error al cargar funciones:', error);
      }
    };

    fetchShows();
  }, []);

  return (
    <div>
      <h2>Funciones disponibles 🎬</h2>
      <ul>
        {shows.map(show => (
          <li key={show.id}>
            <button onClick={() => onSelectShow(show.id)}>
              {show.movieTitle} - {new Date(show.startTime).toLocaleString()}
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ShowList;