using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Animal")]
public class HasHumanAnimal : Conditional
{
    [SerializeField] private SharedAnimal Animal;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value)
        {
            if (Animal.Value.GetHuman)
            {
                return TaskStatus.Success;
            }
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
