using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Cage")]
public class GetAnimal : Action
{
    [SerializeField] private SharedCage Cage;
    [SerializeField] private SharedAnimal Animal;
    [SerializeField] private Type type = Type.CanFeeding;

    public override TaskStatus OnUpdate()
    {
        Animal animal = null;

        switch (type)
        {
            case Type.CanFeeding:
                animal = Cage.Value.GetAnimalCanFeeding(this.transform);
                break;
            case Type.CanGaining:
                animal = Cage.Value.GetAnimalCanGaining(this.transform);
                break;
        }

        if (animal)
        {
            Animal.Value = animal;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

    [System.Serializable]
    private enum Type
    {
        CanFeeding = 0,
        CanGaining
    }
}
