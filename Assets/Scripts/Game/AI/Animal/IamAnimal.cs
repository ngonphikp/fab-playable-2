using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskCategory("Animal")]
public class IamAnimal : Action
{
    [SerializeField] private Animal animal;
    [SerializeField] private SharedAnimal Animal;

    public override TaskStatus OnUpdate()
    {
        if (animal)
        {
            Animal.Value = animal;
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
