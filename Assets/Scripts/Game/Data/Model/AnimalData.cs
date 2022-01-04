[System.Serializable]
public class AnimalData
{
    public AnimalStatus Status = AnimalStatus.EatFill;
    public bool Matured = false;
    public bool Move = false;
    public int Quantity = 10;
    public Direction Direction = Direction.Right;

    public AnimalData Clone()
    {
        AnimalData clone = new AnimalData();
        clone.Status = Status;
        clone.Move = Move;
        clone.Quantity = Quantity;
        return clone;
    }

    public void SetStatus(AnimalStatus value)
    {
        Status = value;
    }

    public void SetMove(bool value)
    {
        Move = value;
    }

    public void SetMatured(bool value)
    {
        Matured = value;
    }

    public void IncreaseQuantity(int value)
    {
        Quantity += value;
    }

    public void SetQuantity(int value)
    {
        Quantity = value;
    }

    public void SetDirection(Direction direction)
    {
        Direction = direction;
    }
}
