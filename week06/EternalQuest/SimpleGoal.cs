public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(
        string shortName,
        string description,
        int points,
        bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override int GetPointsEarned()
    {
        if (_isComplete)
        {
            return GetPoints();
        }

        return 0;
    }

    public override string GetDetailsString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";

        return $"{checkbox} {base.GetDetailsString()}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }
}