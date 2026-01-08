import { useState, useEffect } from 'react'
import Navbar from './components/Navbar'
import SearchOverlay from './components/SearchOverlay';

import './App.css'

function App() {
  const [search, setSearch] = useState("");
  const [isSearchOpen, setIsSearchOpen] = useState(false);

  useEffect(() => {
    document.body.style.overflow = isSearchOpen ? "hidden" : "";
    return () => (document.body.style.overflow = "");
  }, [isSearchOpen]);


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
        onChange={setSearch}
        onClose={() => setIsSearchOpen(false)}
        onClear={() => setSearch("")}
      />
    </>
  )
}

export default App
