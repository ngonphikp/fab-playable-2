using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Animal")]
public class GetFlag : Action
{
    [SerializeField] private SharedAnimal Animal;
    [SerializeField] private SharedFlag Flag;

    public override TaskStatus OnUpdate()
    {
        Flag flag = Animal.Value.GetFlag;        
        if (flag)
        {
            flag.SetRandomPosition();
            Flag.Value = flag;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
