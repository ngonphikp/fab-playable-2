using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Animal")]
public class SetIdle : Action
{
    [SerializeField] private SharedAnimal Animal;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value)
        {
            Animal.Value.SetIdle();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
