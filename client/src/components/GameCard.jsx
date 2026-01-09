import "./GameCard.css";
import cashbackIcon from "../assets/cashback.png"
import xboxIcon from "../assets/xbox-icon.svg"
import psnIcon from "../assets/playstation-icon.png" 
import switchIcon from "../assets/switch.svg"


export default function GameCard({game}){
    const title = game?.title ?? "";
    const platform = game?.platform ?? "";
    const region = game?.region ?? "";
    const price = Number(game?.price ?? 0);
    const cashbackPercent = Number(game?.cashbackPercent ?? 0);
    const likes = Number(game?.likes ?? 0);
    const cashbackAmount = price && cashbackPercent ? (price * cashbackPercent) / 100 : 0;


    const platformIcon = platform.toLowerCase().includes("xbox") ? xboxIcon :
    (platform.includes("ps") || platform.toLowerCase().includes("playstation") || platform.includes("psn")) ? psnIcon :
    (platform.toLowerCase().includes("nintendo") || platform.toLowerCase().includes("switch")) ? switchIcon :
    null;
    const discount = game?.discount ?? null;
    const discountType = (discount?.type ?? "").trim().toLowerCase();
    const discountAmount = Number(discount?.amount ?? 0);

    let oldPrice = null;
    let discountLabel = null;

    if (discountAmount > 0 && price > 0) {
      if (discountType === "percent") {
        if (discountAmount < 100) {
          oldPrice = price / (1 - discountAmount / 100);
          discountLabel = `-${discountAmount}%`;
        }
      } else if (discountType === "fixed") {
        oldPrice = price + discountAmount;
        discountLabel = `-€${discountAmount.toFixed(2)}`;
      }
    }


     return(
        <article className="gc">
      <div className="gc__media">
        <img className="gc__img" src={game.imgUrl} alt={title} loading="lazy" />

        <div className="gc__cashbackPill">
          <img src={cashbackIcon} className="gc__cashbackIcon"></img>
          CASHBACK
        </div>

        <div className="gc__platform">
          <span className="gc__platformDot" aria-hidden="true">
            {platformIcon ? (
              <img className="gc__platformDotIcon" src={platformIcon} alt="" aria-hidden="true" />
            ) : null}
          </span>
          <span className="gc__platformText">{platform}</span>
        </div>
      </div>

      <div className="gc__body">
          <div className="gc__content">
            <div className="gc__title">{title}</div>

        <div className="gc__region">{region.toUpperCase()}</div>
       
          <div className="gc__fromRow">
            <span className="gc__fromLabel">From</span>
             {oldPrice && discountLabel ? (
              <>
              <span className="gc__oldPrice">€{oldPrice.toFixed(2)}</span>
              <span className="gc__discount">{discountLabel}</span>
              </>
                ) : null}
          </div>
        <div className="gc__priceRow">
          <div className="gc__price">€{price.toFixed(2)}</div>
          <div className="gc__info" aria-hidden="true">i</div>
        </div>

        <div className="gc__cashbackLine">
          Cashback: <span className="gc__cashbackValue">€{cashbackAmount.toFixed(2)}</span>
        </div>

        <div className="gc__likes">
          <svg className="gc__heart" viewBox="0 0 24 24" aria-hidden="true">
            <path
              d="M20.8 4.6c-1.6-1.5-4.2-1.5-5.8 0L12 7.5 9 4.6c-1.6-1.5-4.2-1.5-5.8 0-1.7 1.6-1.7 4.2 0 5.8l8.8 8.6 8.8-8.6c1.7-1.6 1.7-4.2 0-5.8z"
              fill="none"
              stroke="currentColor"
              strokeWidth="1.6"
              strokeLinejoin="round"
            />
          </svg>
          <span>{likes}</span>
        </div>
          </div>
        

        <div className="gc__actions">
          <button className="gc__btn gc__btn--primary" type="button">
            Add to cart
          </button>
          <button className="gc__btn gc__btn--ghost" type="button">
            Explore options
          </button>
        </div>
      </div>
    </article>
     );
}