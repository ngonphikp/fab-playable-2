using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Human")]
public class DeregisterAnimal : Action
{
    [SerializeField] private SharedHuman Human;
    [SerializeField] private SharedAnimal Animal;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value != null && Human.Value != null)
        {
            Animal.Value.Deregister(Human.Value);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
