using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Human")]
public class GetCage : Action
{
    [SerializeField] private SharedHuman Human;
    [SerializeField] private SharedCage Cage;

    public override TaskStatus OnUpdate()
    {
        var cage = Human.Value.GetCage();
        if (cage)
        {
            Cage.Value = cage;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
