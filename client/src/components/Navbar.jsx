
import "./navbar.css";
import enebaLogo from "../assets/eneba-logo.png";
import search from "../assets/search.svg"
import flag from "../assets/lithuania.png"

export default function Navbar({ value, onChange, onClear, onOpenMobileSearch }) {
  return (
    <header className="nav">
      <div className="nav__container">
        <div className="nav__left">
            <svg
            xmlns="http://www.w3.org/2000/svg"
            width="20" height="20" viewBox="0 0 24 24"
            fill="none" stroke="currentColor" stroke-width="2"
            stroke-linecap="round" stroke-linejoin="round"
            aria-hidden="true" focusable="false" className="nav__menuIcon"
            >
            <line x1="3" y1="6" x2="21" y2="6"></line>
            <line x1="3" y1="12" x2="21" y2="12"></line>
            <line x1="3" y1="18" x2="21" y2="18"></line>
            </svg>
        <div className="nav__brand">
          <img
            src={enebaLogo}
            alt="Eneba"
            className="nav__logo"
          />
        </div>

        <div className="nav__search">
            <img src={search} alt="" aria-hidden="true" className="nav__searchIcon"/>
          <input
            className="nav__searchInput"
            type="text"
            placeholder="Search"
            value={value}
            onChange={(e) => onChange?.(e.target.value)}
          />

          {value ? (
            <button
              className="nav__clearBtn"
              onClick={onClear}
              aria-label="Clear search"
            >
               <svg
                xmlns="http://www.w3.org/2000/svg"
                width="20" height="20" viewBox="0 0 24 24"
                fill="none" stroke="currentColor" stroke-width="2"
                stroke-linecap="round" stroke-linejoin="round"
                aria-hidden="true" focusable="false"
                >
                <line x1="18" y1="6" x2="6" y2="18"></line>
                <line x1="6" y1="6" x2="18" y2="18"></line>
                </svg>
            </button>
           
          ) : null}
        </div>
        <div className="nav__locale">
            <img src={flag} alt="Lithuanian flag" className="nav__flag"></img>
            <span className="nav__localeText">English EU</span>
            <span className="nav__sep">|</span>
            <span className="nav__localeText">EUR</span>
          </div>
        </div>
        


        <div className="nav__right">

          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="20" height="20" viewBox="0 0 24 24"
            fill="none" stroke="currentColor" stroke-width="1.5"
            stroke-linecap="round" stroke-linejoin="round"
            aria-hidden="true" focusable="false"  className="nav__iconBtn"
             onClick={onOpenMobileSearch} role="button" tabIndex={0} 
             onKeyDown={(e) => e.key === "Enter" && onOpenMobileSearch?.()} 
             aria-label="Open search"
            >
            <circle cx="11" cy="11" r="7"></circle>
            <path d="M20 20l-3.5-3.5"></path>
            </svg>

        
            <svg
            xmlns="http://www.w3.org/2000/svg"
            width="20" height="20" viewBox="0 0 24 24"
            fill="none" stroke="currentColor" stroke-width="1.5"
            stroke-linecap="round" stroke-linejoin="round"
            aria-hidden="true" focusable="false"  className="nav__iconBtn"
            >
            <path d="M12 21s-7-4.35-9.33-8.17C.9 9.9 2.07 6.97 4.7 5.83c1.66-.72 3.57-.25 4.93 1.1L12 9.3l2.37-2.37c1.36-1.35 3.27-1.82 4.93-1.1 2.63 1.14 3.8 4.07 2.03 7-2.33 3.82-9.33 8.17-9.33 8.17z"></path>
            </svg>

            <svg
            xmlns="http://www.w3.org/2000/svg"
            width="20" height="20" viewBox="0 0 24 24"
            fill="none" stroke="currentColor" stroke-width="1.5"
            stroke-linecap="round" stroke-linejoin="round"
            aria-hidden="true" focusable="false" className="nav__iconBtn"
            >
            <circle cx="9" cy="20" r="1"></circle>
            <circle cx="17" cy="20" r="1"></circle>
            <path d="M3 4h2l2.2 11.2a2 2 0 0 0 2 1.6h7.6a2 2 0 0 0 2-1.6L22 8H6"></path>
            </svg>

     
            <svg
            xmlns="http://www.w3.org/2000/svg"
            width="20" height="20" viewBox="0 0 24 24"
            fill="none" stroke="currentColor" stroke-width="1.5"
            stroke-linecap="round" stroke-linejoin="round"
            aria-hidden="true" focusable="false"  className="nav__iconBtn"
            >
            <circle cx="12" cy="8" r="4"></circle>
            <path d="M4 20a8 8 0 0 1 16 0"></path>
            </svg>

        </div>
      </div>
    </header>
  );
}
