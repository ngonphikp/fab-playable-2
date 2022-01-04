using MEC;
using Sirenix.OdinInspector;
using UnityEngine;

public class GroundCage : GroundAct
{
    [Header("Object")]
    [SerializeField] private Cage m_Cage;
    [SerializeField] private Food m_Food;
    [SerializeField] private GameObject m_EfUpgrade;

    //[Header("UI")]

    [Header("Properties")]
    [SerializeField] private GroundCageData cageData = new GroundCageData();
    private GroundCageEntity cageEntity;

    public override Cage GetCage()
    {
        return m_Cage;
    }

    protected override Human IncreaseHuman()
    {
        Human human = base.IncreaseHuman();

        Flag flag = m_Cage.IncreaseFlag();
        (human as Breed).Set(flag);

        return human;
    }

    public Food GetFood()
    {
        return m_Food;
    }

    protected override void SetLevel0()
    {
        m_Cage.Set(this);
        IncreaseHuman();

        int size = ActData.ActType == ActType.Chicken ? 3 : 1;
        for (int i = 0; i < size; i++)
        {
            m_Cage.IncreaseAnimal();
        }
    }

    protected override void LoadEntity()
    {
        cageEntity = DataManager.Data.GroundCage.Dictionary[ActData.ActType];
        actEntity = cageEntity;
    }

    protected override void IncreaseAnimal()
    {
        m_Cage.IncreaseAnimal();
    }

    protected override void IncreaseQuantityAct(int value)
    {
        m_Cage.IncreaseQuatityAnimal(value);
    }
}
