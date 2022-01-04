using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[TaskCategory("Animal")]
public class StopAgentAnimal : StopAgent
{
    [SerializeField] private SharedAnimal Animal;

    public override void OnStart()
    {
        agent = Animal.Value.GetComponent<NavMeshAgent>();
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        return base.OnUpdate();
    }
}

