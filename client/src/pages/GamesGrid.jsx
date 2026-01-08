import "./GameGrid.css";
import GameCard from "../components/GameCard";

export default function GameGrid({ games = [] }) {
  return (
    <section className="gameGrid">
      <div className="gameGrid__meta">
        Results found: {games.length}
      </div>

      <div className="gameGrid__grid">
        {games.map((g) => (
          <GameCard key={g.id} game={g} />
        ))}
      </div>
    </section>
  );
}
