using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Animal")]
public class HasMove : Conditional
{
    [SerializeField] private SharedAnimal Animal;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value)
        {
            if (Animal.Value.Data.Move)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
