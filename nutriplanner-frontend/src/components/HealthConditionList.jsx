import HealthConditionCard from "./HealthConditionCard";

function HealthConditionList({ healthConditions, selectedId, onSelect }) {
    return (
        <ul>
            {healthConditions.map((healthCondition) => (
                <HealthConditionCard
                    key={healthCondition.id}
                    healthCondition={healthCondition}
                    onSelect={onSelect}
                    isActive={healthCondition.id === selectedId}
                />
            ))}
        </ul>
    );
}

export default HealthConditionList;