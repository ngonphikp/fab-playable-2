using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Cage")]
public class HasStatusAnimal : Conditional
{
    [SerializeField] private SharedCage Cage;
    [SerializeField] private Type type = Type.CanFeeding;

    public override TaskStatus OnUpdate()
    {
        bool check = false;

        switch (type)
        {
            case Type.CanFeeding:
                check = Cage.Value.CanFeeding();
                break;
            case Type.CanGaining:
                check = Cage.Value.CanGaining();
                break;
        }        
        return check ? TaskStatus.Success : TaskStatus.Failure;
    }

    [System.Serializable]
    private enum Type
    {
        CanFeeding = 0,
        CanGaining
    }
}
