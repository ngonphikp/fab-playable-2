using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskCategory("Human")]
public class ShowChat : Action
{
    [SerializeField] private SharedHuman Human;
    [SerializeField] private ChatType type;

    public override TaskStatus OnUpdate()
    {
        if (Human.Value != null)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
