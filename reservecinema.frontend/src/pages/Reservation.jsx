import { useParams } from 'react-router-dom';

const ReservationSuccess = () => {
  const { id } = useParams();

  return (
    <div className="p-6 text-center">
      <h2 className="text-2xl font-bold mb-4 text-green-600">¡Reserva Confirmada! ✅</h2>
      <p className="text-lg">Tu número de reserva es: <strong>{id}</strong></p>
    </div>
  );
};

export default ReservationSuccess;