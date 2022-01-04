using System;

[System.Serializable]
public class RewardData
{
    public RewardType Type;
    public object Data;

    public RewardData()
    {

    }

    public RewardData(string content)
    {
        string[] str = content.Split(';');
        Enum.TryParse(str[0], out RewardType rewardType);
        Type = rewardType;
        switch (rewardType)
        {
            case RewardType.Act:
                break;
            case RewardType.Currency:
                Enum.TryParse(str[1], out CurrencyType currencyType);
                Data = new CurrencyData()
                {
                    Type = currencyType,
                    Value = uint.Parse(str[2])
                };
                break;
        }
    }
}
