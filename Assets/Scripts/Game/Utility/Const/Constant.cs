using System.Collections;
using System.Collections.Generic;

public static class Constant
{
    public static Dictionary<ActType, string> dic_TypeMove = new Dictionary<ActType, string>()
    {
        { ActType.Corn, "Move_Bao" },
        { ActType.Chicken, "Move_Milk" },
        { ActType.Chicken, "Move_Meat_Egg" },
        { ActType.Pig, "Move_Meat_Egg" },
    };
}
