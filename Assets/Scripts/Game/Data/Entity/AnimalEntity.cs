using System;

[System.Serializable]
public class AnimalEntity
{
    public ActType Type = ActType.Chicken;
    public float Speed = 1f;
    public float TimeMature = 5f;
    public int Quantity = 10;

    public AnimalEntity()
    {

    }

    public AnimalEntity(DB_Animal entity)
    {
        Enum.TryParse(entity.Get<string>("Type"), out ActType actType);
        Type = actType;
        Speed = entity.Get<float>("Speed");
        TimeMature = entity.Get<float>("TimeMature");
        Quantity = entity.Get<int>("Quantity");
    }
}
