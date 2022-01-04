using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Human")]
public class RegisterAnimal : Action
{
    [SerializeField] private SharedHuman Human;
    [SerializeField] private SharedAnimal Animal;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value != null && Human.Value != null)
        {
            Animal.Value.Register(Human.Value);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
