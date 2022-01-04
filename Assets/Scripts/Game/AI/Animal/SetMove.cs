using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Animal")]
public class SetMove : Action
{
    [SerializeField] private SharedAnimal Animal;
    [SerializeField] private bool value = false;

    public override TaskStatus OnUpdate()
    {
        if (Animal.Value)
        {
            Animal.Value.Data.SetMove(value);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
