import UserSelectionCard from "./UserSelectionCard";


function UserSelectionList({ userSelections, token, onSelectionRemoved }) {
    if (userSelections.length === 0) return <p>Sem alimentos para esta dieta.</p>;

    return (
        <div className="food-groups">
            <ul className="food-list">
                {userSelections.map((userSelection) => (
                    <UserSelectionCard key={userSelection.foodId} userSelection={userSelection} token={token} onSelectionRemoved={onSelectionRemoved} />
                ))}
            </ul>
        </div>
    );
}
    
export default UserSelectionList;