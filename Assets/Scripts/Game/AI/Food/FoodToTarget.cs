using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Food")]
public class FoodToTarget : Action
{
    [SerializeField] private SharedFood Food;
    [SerializeField] private SharedTransform Target;

    public override TaskStatus OnUpdate()
    {
        if (Food.Value)
        {
            Target.Value = Food.Value.transform;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
