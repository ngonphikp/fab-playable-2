using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SharedFood : SharedVariable<Food>
{
    public static implicit operator SharedFood(Food value) { return new SharedFood { Value = value }; }
}

[System.Serializable]
public class Food : MonoBehaviour
{
    
}
