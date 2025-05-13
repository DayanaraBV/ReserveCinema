import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import ReservationSuccess from './pages/ReservationSuccess';

function App() {
  return (
    <div className="max-w-4xl mx-auto">
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/reservation/:id" element={<ReservationSuccess />} />
      </Routes>
    </div>
  );
}


export default App;