import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { getReservationById } from '../services/api';

const ReservationSuccess = () => {
  const { id } = useParams();
  const [reservation, setReservation] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchReservation = async () => {
      try {
        const data = await getReservationById(id);
        setReservation(data);
      } catch (err) {
          console.error(err);
          setError('No se pudo cargar la reserva.');
      }
    };

    fetchReservation();
  }, [id]);

  if (error) {
    return <div className="text-red-500 p-4">{error}</div>;
  }

  if (!reservation) {
    return <div className="text-white p-4">Cargando reserva...</div>;
  }

  return (
    <div className="bg-[#1e293b] text-white rounded-lg p-6 shadow-md max-w-xl mx-auto mt-8">
      <h2 className="text-2xl font-bold text-yellow-300 mb-4 text-center">
        ¡Reserva confirmada! 🎉
      </h2>

      <div className="space-y-2">
        <p><span className="font-semibold text-yellow-200">ID:</span> {reservation.id}</p>
        <p><span className="font-semibold text-yellow-200">Cliente:</span> {reservation.customerName}</p>
        <p><span className="font-semibold text-yellow-200">Película:</span> {reservation.show.movieTitle}</p>
        <p><span className="font-semibold text-yellow-200">Fecha:</span> {new Date(reservation.show.startTime).toLocaleString()}</p>

        <div>
          <p className="font-semibold text-yellow-200 mb-1">Butacas:</p>
          <div className="flex flex-wrap gap-2">
            {reservation.seats.map((seat, index) => (
              <span
                key={index}
                className="bg-yellow-400 text-black px-3 py-1 rounded text-sm font-semibold"
              >
                {seat.row}-{seat.column}
              </span>
            ))}
          </div>
        </div>
      </div>

      <div className="mt-6 text-center">
        <a
          href="/"
          className="text-sm text-yellow-400 hover:underline"
        >
          ⬅ Volver a funciones
        </a>
      </div>
    </div>
  );
};
export default ReservationSuccess;