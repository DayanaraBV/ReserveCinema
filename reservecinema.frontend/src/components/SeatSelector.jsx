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
    <div className="bg-[#1e293b] p-6 rounded-lg shadow-md text-white mt-8">
      <h3 className="text-xl font-bold text-yellow-300 mb-4">Selecciona tus butacas</h3>

      <div className="grid grid-cols-5 gap-3 justify-center mb-6">
        {seats.map((seat) => {
          const isSelected = selectedSeats.includes(seat.id);
          const seatColor = !seat.isAvailable
            ? 'bg-gray-500 cursor-not-allowed'
            : isSelected
            ? 'bg-yellow-400 hover:bg-yellow-300 text-black'
            : 'bg-green-500 hover:bg-green-400';

          return (
            <button
              key={seat.id}
              disabled={!seat.isAvailable}
              onClick={() => toggleSeat(seat.id)}
              className={`w-12 h-12 rounded text-sm font-bold transition ${seatColor}`}
            >
              {seat.row}-{seat.column}
            </button>
          );
        })}
      </div>

      <input
        type="text"
        placeholder="Tu nombre"
        className="w-full p-2 bg-[#0f172a] border border-gray-600 text-yellow-100 rounded mb-4 placeholder:text-gray-400 focus:outline-none focus:ring-2 focus:ring-yellow-400"
        value={customerName}
        onChange={(e) => setCustomerName(e.target.value)}
      />
      <div className="flex justify-between">
        <button
          onClick={() => {
            setSelectedSeats([]);
            setCustomerName('');
            setMessage(null);
          }}
          className="bg-gray-600 hover:bg-gray-500 text-white px-4 py-2 rounded"
        >
          Cancelar
        </button>

        <button
          onClick={handleReserve}
          className="bg-yellow-400 hover:bg-yellow-300 text-black px-6 py-2 rounded font-semibold"
        >
          Confirmar
        </button>
      </div>

      {message && (
        <p className="mt-4 text-center text-red-400 font-medium">{message}</p>
      )}
    </div>
  );
};


export default SeatSelector;
