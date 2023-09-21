using System;

public enum DefaultStats
{
    Attack,
    Defense,
    Health,
    Critical
}

[Serializable]

public class ItemStats
{
    public DefaultStats baseStats;
}
