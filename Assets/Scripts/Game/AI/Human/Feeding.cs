using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskCategory("Human")]
public class Feeding : Action
{
    [SerializeField] private SharedHuman Human;
    [SerializeField] private SharedAnimal Animal;

    public override TaskStatus OnUpdate()
    {
        if (Human.Value != null)
        {
            (Human.Value as Breed).Feeding(Animal.Value);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
