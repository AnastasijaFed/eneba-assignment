import { useState, useEffect } from 'react'
import Navbar from './components/Navbar'
import SearchOverlay from './components/SearchOverlay';
import GameGrid from './pages/GamesGrid';

import './App.css'

const API_BASE = "https://eneba-assignment-production.up.railway.app";


function App() {
  const [search, setSearch] = useState("");
  const [isSearchOpen, setIsSearchOpen] = useState(false);
  const [games, setGames] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    document.body.style.overflow = isSearchOpen ? "hidden" : "";
    return () => (document.body.style.overflow = "");
  }, [isSearchOpen]);

   useEffect(() => {
    const controller = new AbortController();

    async function fetchGames() {
      setLoading(true);
      setError(null);

      try {
        const query = search ? `?search=${encodeURIComponent(search)}` : "";
        const res = await fetch(`${API_BASE}/list${query}`, {
          signal: controller.signal,
        });

        if (!res.ok) {
          throw new Error(`Request failed: ${res.status}`);
        }

        const data = await res.json();
        setGames(data);
      } catch (err) {
        if (err.name !== "AbortError") {
          setError(err.message);
        }
      } finally {
        setLoading(false);
      }
    }

    fetchGames();

    return () => controller.abort();
  }, [search]);


  return (
    <>
      <Navbar
        value={search}
        onChange={setSearch}
        onClear={() => setSearch("")}
        onOpenMobileSearch={() => setIsSearchOpen(true)}
      />

      <SearchOverlay
        open={isSearchOpen}
        value={search}
        results={games} 
        onChange={setSearch}
        onClose={() => setIsSearchOpen(false)}
        onClear={() => setSearch("")}
      />
      <GameGrid games={games} />
    </>
  )
}

export default App
