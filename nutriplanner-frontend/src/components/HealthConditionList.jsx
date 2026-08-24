import HealthConditionCard from "./HealthConditionCard";

function HealthConditionList({ healthConditions, token, selectedConditions, onSelectionAdded, onSelectionRemoved }) {

    return (
        <ul>
            {healthConditions.map((healthCondition) => (
                <HealthConditionCard
                    key={healthCondition.id}
                    healthCondition={healthCondition}
                    token={token}
                    isActive={selectedConditions.includes(healthCondition.id)}
                    onSelectionAdded={onSelectionAdded}
                    onSelectionRemoved={onSelectionRemoved}
                />
            ))}
        </ul>
    );
}

export default HealthConditionList;