import FoodCard from "./FoodCard";

// agrupa o array plano de alimentos num objeto: { "Proteína": [...], "Hidrato": [...], ... }
function groupByCategory(foods) {
    return foods.reduce((groups, food) => {
        const category = food.category || "Outros";
        if (!groups[category]) groups[category] = [];
        groups[category].push(food);
        return groups;
    }, {});
}

function FoodListByHealthCondition({ foods, token, userSelectionIds, onSelectionAdded, onSelectionRemoved }) {
    if (foods.length === 0) return <p>Sem alimentos para esta condição de saúde.</p>;

    const grouped = groupByCategory(foods);

    return (
        <div className="food-groups">
            {Object.entries(grouped).map(([category, categoryFoods]) => (
                <div key={category} className="food-group">
                    <h3>{category}</h3>
                    <ul className="food-list">
                        {categoryFoods.map((food) => (
                            <FoodCard key={food.id} food={food} token={token} isSelected={userSelectionIds.has(food.id)} onSelectionAdded={onSelectionAdded} onSelectionRemoved={onSelectionRemoved} />
                        ))}
                    </ul>
                </div>
            ))}
        </div>
    );
}

export default FoodListByHealthCondition;


