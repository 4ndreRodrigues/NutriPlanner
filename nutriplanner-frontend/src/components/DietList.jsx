import DietCard from "./DietCard";

function DietList({ diets, token, onSelectDiet }) {
    return (
        <ul>
            {diets.map((diet) => (
                <DietCard
                    key={diet.id}
                    diet={diet}
                    token={token}
                    onSelect={onSelectDiet}
                />
            ))}
        </ul>
    );
}

export default DietList;