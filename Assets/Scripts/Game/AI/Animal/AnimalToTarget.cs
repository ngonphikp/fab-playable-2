using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Animal")]
public class AnimalToTarget : Action
{
    [SerializeField] private SharedAnimal Animal;
    [SerializeField] private SharedTransform Target;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value)
        {
            Target.Value = Animal.Value.transform;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
