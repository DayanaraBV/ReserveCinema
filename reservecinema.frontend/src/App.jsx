import React, { useState } from 'react';
import ShowList from './components/ShowList';
import { TicketIcon } from '@heroicons/react/24/outline';

function App() {
  const [selectedShow, setSelectedShow] = useState(null);

  return (
    <div className="p-8 font-sans">
      <h1 className="flex items-center text-red-500 text-3xl font-bold gap-2 mb-4">Reserva de Cine <TicketIcon className="w-9 h-9 relative top-1"/></h1>

      {/* Lista de funciones (películas disponibles) */}
      <ShowList onSelectShow={setSelectedShow} />

      {/* Selector de butacas para la función elegida */}
      {selectedShow && (
        <div className="mt-8">
          <SeatSelector showId={selectedShow} />
        </div>
      )}
    </div>
  );
}


export default App;