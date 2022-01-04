using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Human")]
public class GetFlagHuman : Action
{
    [SerializeField] private SharedHuman Human;
    [SerializeField] private SharedFlag Flag;

    public override TaskStatus OnUpdate()
    {
        Flag flag = (Human.Value as Breed).GetFlag;  
        if (flag)
        {
            flag.SetRandomPosition();
            Flag.Value = flag;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
