using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[TaskCategory("Animal")]
public class MoveAgentAnimal : MoveAgent
{
    [SerializeField] private SharedAnimal Animal;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        return base.OnUpdate();
    }

    protected override void SetDirection(Direction direction)
    {
        Animal.Value.SetDirection(direction);
    }
}

