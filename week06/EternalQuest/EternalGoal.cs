public class EternalGoal : Goal
{
    public EternalGoal(
        string shortName,
        string description,
        int points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals can always be recorded.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int GetPointsEarned()
    {
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        return $"[ ] {base.GetDetailsString()}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }
}