import "./SearchOverlay.css";

export default function SearchOverlay({ open, value, onChange, onClose, onClear, results }) {
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
          {value.trim().length > 0 && results?.map((item) => (
            <div key={item.id} className="searchResult">
              <img src={item.imgUrl} alt="" className="searchResult__img" />
              
              <div className="searchResult__details">
                <span className="searchResult__badge">Digital good</span>
                <h3 className="searchResult__title">
                  {item.title} ({item.platform}) {item.region}
                </h3>
              </div>

              <div className="searchResult__priceArea">
                <span className="searchResult__from">From</span>
                <span className="searchResult__price">€{item.price}</span>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
