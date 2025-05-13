import React, { useState } from 'react';
import ShowList from '../components/ShowList';
import SeatSelector from '../components/SeatSelector';

const Home = () => {
  const [selectedShow, setSelectedShow] = useState(null);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Reserva de Cine 🎟️</h1>
      <ShowList onSelectShow={setSelectedShow} />
      {selectedShow && <SeatSelector showId={selectedShow} />}
    </div>
  );
};

export default Home;