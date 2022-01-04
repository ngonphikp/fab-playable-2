using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{
    [Header("Object")]
    [SerializeField] private GameObject m_GraphicMoo;

    private SkeletonAnimation saMoo;

    protected override void Awake()
    {
        saMoo = m_GraphicMoo.GetComponent<SkeletonAnimation>();
        saMoo.Initialize(false);
        base.Awake();
    }

    protected override void Hungry()
    {
        base.Hungry();
        m_GraphicMoo.SetActive(false);
        m_GraphicMoo.SetActive(true);
        saMoo.AnimationState.SetAnimation(0, "Idle_Special_" + (Data.Direction == Direction.Right ? "R" : "L"), false);
    }
}
