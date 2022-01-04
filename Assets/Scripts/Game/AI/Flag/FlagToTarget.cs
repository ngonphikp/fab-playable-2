using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Flag")]
public class FlagToTarget : Action
{
    [SerializeField] private SharedFlag Flag;
    [SerializeField] private SharedTransform Target;

    public override TaskStatus OnUpdate()
    {
        if (Flag.Value)
        {
            Target.Value = Flag.Value.transform;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
