import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import ReservationSuccess from './pages/ReservationSuccess';
import Navbar from './components/Navbar';

function App() {
   return (
    <div className="min-h-screen bg-[#0f172a] text-gray-100 font-sans">
      <Navbar />
      <main className="max-w-5xl mx-auto px-4 py-8">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/reservation/:id" element={<ReservationSuccess />} />
        </Routes>
      </main>
    </div>
  );
}

export default App;