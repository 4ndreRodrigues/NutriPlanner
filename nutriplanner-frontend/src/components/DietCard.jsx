import { useState, useEffect } from "react";

function DietCard({diet,onSelect }) {
    return (
        <li className="diet-card" onClick={() => onSelect(diet.id)}>
            {diet.name}
            <div className="diet-tooltip">
                {diet.description}
            </div>
        </li> 
        )
}

export default DietCard;