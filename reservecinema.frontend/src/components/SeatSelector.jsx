import React, { useEffect, useState } from 'react';
import { getAvailableSeats } from '../services/api';

const SeatSelector = ({ showId }) => {
  const [seats, setSeats] = useState([]);

  useEffect(() => {
    const fetchSeats = async () => {
      try {
        const data = await getAvailableSeats(showId);
        setSeats(data);
      } catch (error) {
        console.error('Error al cargar butacas:', error);
      }
    };

    if (showId) fetchSeats();
  }, [showId]);

  return (
    <div>
      <h3>Butacas disponibles para la función #{showId}</h3>
      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(5, 50px)', gap: '10px' }}>
        {seats.map(seat => (
          <button
            key={seat.id}
            disabled={!seat.isAvailable}
            style={{
              backgroundColor: seat.isAvailable ? '#4caf50' : '#ccc',
              color: 'white',
              border: 'none',
              padding: '10px',
              borderRadius: '4px',
              cursor: seat.isAvailable ? 'pointer' : 'not-allowed'
            }}
          >
            {seat.row}-{seat.column}
          </button>
        ))}
      </div>
    </div>
  );
};

export default SeatSelector;
