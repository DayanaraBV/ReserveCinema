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
    <div className="bg-[#1e293b] rounded-lg p-6 shadow-lg mb-6">
      <h2 className="text-xl font-bold text-yellow-200 mb-4">🎬 Funciones disponibles</h2>
      <div className="space-y-4">
        {shows.map(show => (
          <div
            key={show.id}
            className="flex items-center justify-between bg-[#334155] p-4 rounded-md hover:bg-[#475569] transition"
          >
            <div>
              <h3 className="text-lg font-semibold">{show.movieTitle}</h3>
              <p className="text-sm text-gray-300">
                {new Date(show.startTime).toLocaleString()}
              </p>
            </div>
            <button
              onClick={() => onSelectShow(show.id)}
              className="bg-yellow-400 hover:bg-yellow-300 text-black px-4 py-1 rounded font-semibold"
            >
              Reservar
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ShowList;