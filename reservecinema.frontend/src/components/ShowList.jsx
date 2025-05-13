import React, { useEffect, useState } from 'react';
import { getShows } from '../services/api';
import { FilmIcon } from '@heroicons/react/24/outline'

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
      <h2 className="flex items-center text-red-500 text-2xl font-bold gap-2 mb-4">Funciones disponibles <FilmIcon className="w-7 h-7 relative top-1"/></h2>
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