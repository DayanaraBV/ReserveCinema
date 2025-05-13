import React, { useState } from 'react';
import ShowList from './components/ShowList';

function App() {
  const [selectedShow, setSelectedShow] = useState(null);

  return (
    <div style={{ padding: '2rem', fontFamily: 'Arial, sans-serif' }}>
      <h1 style={{ marginBottom: '1rem' }}>Reserva de Cine 🎟️</h1>

      {/* Lista de funciones (películas disponibles) */}
      <ShowList onSelectShow={setSelectedShow} />

      {/* Selector de butacas para la función elegida */}
      {selectedShow && (
        <div style={{ marginTop: '2rem' }}>
          <SeatSelector showId={selectedShow} />
        </div>
      )}
    </div>
  );
}


export default App;