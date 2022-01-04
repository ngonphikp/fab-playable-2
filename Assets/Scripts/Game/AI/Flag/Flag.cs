using BehaviorDesigner.Runtime;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SharedFlag : SharedVariable<Flag>
{
    public static implicit operator SharedFlag(Flag value) { return new SharedFlag { Value = value }; }
}

[System.Serializable]
public class Flag : MonoBehaviour
{
    private Cage cage;

    public void Set(Cage cage)
    {
        this.cage = cage;
    }

    public void SetRandomPosition()
    {
        this.transform.localPosition = cage.GetRandomPosition();
    }
}
