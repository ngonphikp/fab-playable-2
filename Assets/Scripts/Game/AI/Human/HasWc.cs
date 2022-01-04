using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Human")]
public class HasWc : Conditional
{
    [SerializeField] private SharedHuman Human;

    public override TaskStatus OnUpdate()
    {
        if (Human.Value)
        {
            if (Human.Value.Data.Wc)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
