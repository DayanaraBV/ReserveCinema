import React, { useState } from 'react';
import ShowList from './components/ShowList';

function App() {
  const [selectedShow, setSelectedShow] = useState(null);

  const handleSelectShow = (id) => {
    console.log('Show seleccionado:', id);
    setSelectedShow(id);
  };

  return (
    <div className="App">
      <h1>Reserva de Cine</h1>
      <ShowList onSelectShow={handleSelectShow} />
    </div>
  );
}

export default App;