function HealthConditionCard({ healthCondition, onSelect, isActive }) {
    return (
        <li
            className={`healthcondition-card ${isActive ? "active" : ""}`}
            onClick={() => onSelect(healthCondition.id)}
        >
            {healthCondition.name}
            <div className="healthcondition-tooltip">
                {healthCondition.description}
            </div>
        </li>
    );
}

export default HealthConditionCard;