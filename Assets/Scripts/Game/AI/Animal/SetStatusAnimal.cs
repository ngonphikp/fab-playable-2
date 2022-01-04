using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Animal")]
public class SetStatusAnimal : Action
{
    [SerializeField] private SharedAnimal Animal;
    [SerializeField] private AnimalStatus status;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value)
        {
            Animal.Value.SetStatus(status);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
