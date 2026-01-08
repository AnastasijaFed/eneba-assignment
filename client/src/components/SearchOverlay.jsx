import "./SearchOverlay.css";

export default function SearchOverlay({ open, value, onChange, onClose, onClear }) {
  return (
    <div className={`searchOverlay ${open ? "is-open" : ""}`} aria-hidden={!open}>
      <div className="searchOverlay__backdrop" onClick={onClose} />

      <div className="searchOverlay__panel" role="dialog" aria-modal="true">
        <div className="searchOverlay__topbar">
          <button className="searchOverlay__btn" onClick={onClose} aria-label="Back">
            ←
          </button>

          <input
            className="searchOverlay__input"
            placeholder="Search"
            value={value}
            onChange={(e) => onChange?.(e.target.value)}
            autoFocus
          />

          <button className="searchOverlay__btn" onClick={onClear} aria-label="Clear">
            ✕
          </button>
        </div>

        <div className="searchOverlay__content">
        </div>
      </div>
    </div>
  );
}
