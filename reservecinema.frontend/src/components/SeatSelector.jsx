import React, { useEffect, useState } from 'react';
import { getAvailableSeats } from '../services/api';
import { useNavigate } from 'react-router-dom';
import { createReservation } from '../services/api';

const SeatSelector = ({ showId }) => {
  const [seats, setSeats] = useState([]);
  const [selectedSeats, setSelectedSeats] = useState([]);
  const [customerName, setCustomerName] = useState('');
  const [message, setMessage] = useState(null);

  const navigate = useNavigate();
  
  useEffect(() => {
    const fetchSeats = async () => {
      try {
        const data = await getAvailableSeats(showId);
        setSeats(data);
      } catch (error) {
        console.error('Error al cargar butacas:', error);
      }
    };

    if (showId) {
      fetchSeats();
      setSelectedSeats([]);
      setCustomerName('');
      setMessage(null);
    }
  }, [showId]);

  const toggleSeat = (seatId) => {
    setSelectedSeats((prev) =>
      prev.includes(seatId)
        ? prev.filter((id) => id !== seatId)
        : [...prev, seatId]
    );
  };

  const handleReserve = async () => {
    if (!customerName || selectedSeats.length === 0) {
      setMessage('⚠️ Ingresa tu nombre y selecciona al menos una butaca.');
      return;
    }

    try {
      const result = await createReservation({
        showId,
        customerName,
        seatIds: selectedSeats,
      });

      navigate(`/reservation/${result.id}`);
      setSelectedSeats([]);
      setCustomerName('');
    } catch (error) {
      setMessage(`❌ Error: ${error.response?.data?.error || error.message}`);
    }
  };

  return (
    <div className="mt-8 p-6 border rounded-lg shadow-md bg-[#1e293b] max-w-xl mx-auto">
      <h3 className="text-xl font-semibold mb-4 text-yellow-200">Selecciona tus butacas</h3>

      <div className="grid grid-cols-5 gap-2 mb-6">
        {seats.map((seat) => {
          const isSelected = selectedSeats.includes(seat.id);
          return (
            <button
              key={seat.id}
              disabled={!seat.isAvailable}
              onClick={() => toggleSeat(seat.id)}
              className={`
                text-white font-bold py-2 px-0 rounded transition
                ${!seat.isAvailable
                  ? 'bg-gray-400 cursor-not-allowed'
                  : isSelected
                  ? 'bg-yellow-400 hover:bg-yellow-300 text-black'
                  : 'bg-green-500 hover:bg-green-400'}
              `}
            >
              {seat.row}-{seat.column}
            </button>
          );
        })}
      </div>

      <input
        type="text"
        placeholder="Tu nombre"
        className="w-full p-2 border border-gray-300 rounded mb-4 text-black"
        value={customerName}
        onChange={(e) => setCustomerName(e.target.value)}
      />

      <button
        onClick={handleReserve}
        className="w-full bg-yellow-400 text-black py-2 rounded hover:bg-yellow-300 transition font-semibold">
        Confirmar reserva 🎟️
      </button>

      {message && (
        <div className="mt-4 text-center text-sm text-white font-medium">{message}</div>
      )}
    </div>
  );
};


export default SeatSelector;
