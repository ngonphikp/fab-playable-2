using BehaviorDesigner.Runtime;
using DG.Tweening;
using MEC;
using Spine.Unity;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[System.Serializable]
public class Breed : Human
{
    public Flag GetFlag => flag;
    private Flag flag;

    public void Set(Flag flag)
    {
        this.flag = flag;
    }

    public void GainAnimal(Animal animal)
    {
        Timing.RunCoroutine(_GainAnimal(animal));
    }

    private IEnumerator<float> _GainAnimal(Animal animal)
    {
        animal.Data.SetMove(false);
        animal.SetStatus(AnimalStatus.Hungry);
        save.IncreaseAct(animal.Entity.Quantity);        
        yield return Timing.WaitForSeconds(1f);
        animal.Data.SetMove(true);
    }

    public void Feeding(Animal animal)
    {
        Timing.RunCoroutine(_Feeding(animal));
    }

    private IEnumerator<float> _Feeding(Animal animal)
    {
        animal.Data.SetMove(false);
        animal.SetStatus(AnimalStatus.EatFill);
        animal.SetIdle();
        yield return Timing.WaitForSeconds(1f);
        animal.Data.SetMove(true);
    }
}
