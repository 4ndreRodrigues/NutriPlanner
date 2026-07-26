import DietCard from "./DietCard";

function DietList({ diets, onSelectDiet }) {
    return (
        <ul>
            {diets.map((diet) => (
                <DietCard key={diet.id} diet={diet} onSelect={onSelectDiet} />
            ))}
        </ul>
    );
}

export default DietList;