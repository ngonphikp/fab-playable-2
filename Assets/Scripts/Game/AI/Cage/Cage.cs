using BehaviorDesigner.Runtime;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SharedCage : SharedVariable<Cage>
{
    public static implicit operator SharedCage(Cage value) { return new SharedCage { Value = value }; }
}

[System.Serializable]
public class Cage : MonoBehaviour
{
    public AnimalEntity AnimalEntity => animalEntity;

    [Header("Object")]
    [SerializeField] private Transform m_Graphic;
    [SerializeField] private Vector3 m_OffsetPosition;
    [SerializeField] private Vector2 m_LimitPosition;
    [SerializeField] private Flag m_FlagPrb;

    [Header("Properties")]
    [SerializeField] private List<Animal> animals = new List<Animal>();
    private GroundCage ground;
    private AnimalData animalTemp = new AnimalData();
    private AnimalEntity animalEntity;

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + m_OffsetPosition, new Vector3(m_LimitPosition.x * 2, m_LimitPosition.y * 2));
    }
#endif

    public void Set(GroundCage ground)
    {
        this.ground = ground;

        animalEntity = DataManager.Data.Animal.Dictionary[ground.ActData.ActType];
        animalTemp.SetQuantity(animalTemp.Quantity);
    }

    public Flag IncreaseFlag()
    {
        Flag flag = PoolManager.S.Spawn(m_FlagPrb, m_Graphic);
        flag.Set(this);

        return flag;
    }

    public void IncreaseAnimal()
    {
        Animal asAnimal = ResourceManager.S.LoadAnimal("Prefabs/Animals/" + ground.ActData.ActType.ToString());
        Animal animal = PoolManager.S.Spawn(asAnimal, m_Graphic);

        animal.Set(this, animalTemp.Clone());

        Flag flag = IncreaseFlag();
        
        animal.Set(flag);
        animals.Add(animal);
    }

    public Vector3 GetRandomPosition()
    {
        return m_OffsetPosition + new Vector3(Random.Range(-m_LimitPosition.x, m_LimitPosition.x), Random.Range(-m_LimitPosition.y, m_LimitPosition.y));
    }

    public bool CanFeeding()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].CanFeeding()) return true;
        }
        return false;
    }

    public bool CanGaining()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].CanGaining()) return true;
        }
        return false;
    }

    public Animal GetAnimalCanFeeding(Transform human)
    {
        List<int> cans = new List<int>();
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].CanFeeding()) cans.Add(i);
        }

        return GetAnimal(human, cans);
    }

    public Animal GetAnimalCanGaining(Transform human)
    {
        List<int> cans = new List<int>();
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].CanGaining()) cans.Add(i);
        }

        return GetAnimal(human, cans);
    }

    private Animal GetAnimal(Transform human, List<int> cans)
    {
        if (cans.Count == 0) return null;

        if (cans.Count == 1)
        {
            return animals[cans[0]];
        }

        int find = cans[0];
        float minDis = Vector3.Distance(human.position, animals[0].transform.position);
        for (int i = 1; i < cans.Count; i++)
        {
            float dis = Vector3.Distance(human.position, animals[i].transform.position);
            if (minDis > dis + 0.2f)
            {
                find = cans[i];
                minDis = dis;
            }
        }

        return animals[find];
    }

    public void IncreaseQuatityAnimal(int value)
    {
        animalTemp.IncreaseQuantity(value);
        for (int i = 0; i < animals.Count; i++)
        {
            animals[i].IncreaseQuantity(value);
        }
    }

    public Food GetFood()
    {
        return ground.GetFood();
    }
}
