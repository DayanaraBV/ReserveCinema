import { Link } from 'react-router-dom';

const Navbar = () => {
  return (
    <nav className="bg-[#0f172a] text-yellow-200 px-6 py-4 shadow-md">
      <div className="max-w-5xl mx-auto flex justify-between items-center">
        <Link to="/" className="text-2xl font-bold tracking-wide">
          🎬 ReserveCinema
        </Link>
        <span className="text-sm">dayanarabone277@gmail.com</span>
      </div>
    </nav>
  );
};

export default Navbar;