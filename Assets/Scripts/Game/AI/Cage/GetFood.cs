using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Cage")]
public class GetFood : Action
{
    [SerializeField] private SharedCage Cage;
    [SerializeField] private SharedFood Food;

    public override TaskStatus OnUpdate()
    {
        Food food = Cage.Value.GetFood();

        if (food)
        {
            Food.Value = food;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
