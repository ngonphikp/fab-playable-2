using BehaviorDesigner.Runtime;
using Spine.Unity;
using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[System.Serializable]
public class SharedAnimal : SharedVariable<Animal>
{
    public static implicit operator SharedAnimal(Animal value) { return new SharedAnimal { Value = value }; }
}

[System.Serializable]
public class Animal : MonoBehaviour
{
    public Human GetHuman => human;
    public Flag GetFlag => flag;
    public AnimalData Data => data;
    public AnimalEntity Entity => cage.AnimalEntity;

    [Header("Object")]
    [SerializeField] private GameObject m_Graphic;

    [Header("UI")]
    [SerializeField] private UIProgress m_Progress;

    [Header("Properties")]
    private AnimalData data;
    private Cage cage;
    private Flag flag;
    private Human human;
    private SkeletonAnimation sa;
    private BehaviorTree behavior;

    protected virtual void Awake()
    {
        sa = m_Graphic.GetComponent<SkeletonAnimation>();
        sa.Initialize(false);
        behavior = GetComponent<BehaviorTree>();
    }

    private void OnDisable()
    {
        behavior.enabled = false;
    }

    private void InitAI()
    {           
        behavior.enabled = true;
    }

    public void Set(Cage cage, AnimalData data)
    {
        this.cage = cage;
        this.data = data;

        m_Progress.Set(Entity.Type);
        
        InitAI();
    }

    public void Set(Flag flag)
    {
        this.flag = flag;

        this.flag.SetRandomPosition();
        this.transform.position = flag.transform.position;
    }

    public void SetStatus(AnimalStatus status)
    {
        if (this.data.Status == status) return;

        this.data.SetStatus(status);
        switch (status)
        {
            case AnimalStatus.Hungry:
                HideProgress();
                data.SetMatured(false);
                break;
            case AnimalStatus.EatFill:
                break;
            default:
                break;
        }
    }

    public void SetIdle()
    {
        switch (data.Status)
        {
            case AnimalStatus.Hungry:
                Hungry();
                break;
            case AnimalStatus.EatFill:
                if (!data.Matured)
                {
                    sa.AnimationState.SetAnimation(0, "Idle", true);
                    if (!m_Progress.gameObject.activeSelf)
                    {
                        ShowProgress(Entity.TimeMature, Mature);
                    }
                }
                else
                {
                    sa.AnimationState.SetAnimation(0, "Idle_Waiting", true);
                }
                break;
            default:
                break;
        }
    }

    protected virtual void Hungry()
    {
        sa.AnimationState.SetAnimation(0, "Idle_Special", true);
    }

    private void Mature()
    {
        data.SetMatured(true);
    }

    public void ShowProgress(float sumTime, Action callback)
    {
        m_Progress.gameObject.SetActive(true);
        m_Progress.CDT(sumTime, callback);
    }

    public void HideProgress()
    {
        m_Progress.gameObject.SetActive(false);
    }

    public void Register(Human human)
    {
        if (this.human)
        {
            if (this.human == human)
            {
                Debug.LogError("You are already registered in this animal");
            }
            else
            {
                Debug.LogError("Other human is already registered in this animal");
            }
            return;
        }
        this.human = human;
    }

    public void Deregister(Human human = null)
    {
        if (human == null || this.human == human)
        {
            this.human = null;
            this.data.SetMove(false);
        }
        else
        {
            Debug.LogError("Human don't work in this animal");
        }
    }

    public bool CanFeeding()
    {
        return data.Status == AnimalStatus.Hungry && !data.Matured && human == null;
    }

    public bool CanGaining()
    {
        return data.Matured && data.Status == AnimalStatus.EatFill && human == null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (human)
        {
            if (collision.CompareTag("Human"))
            {
                Human hm = collision.GetComponent<Human>();
                if(this.human == hm)
                {
                    data.SetMove(false);
                }
            }
        }
    }

    public void IncreaseQuantity(int value)
    {
        data.IncreaseQuantity(value);
    }

    public void SetDirection(Direction direction)
    {
        if (this.Data.Direction == direction) return;

        this.data.SetDirection(direction);

        switch (direction)
        {
            case Direction.Left:
                this.transform.localScale = new Vector3(-1, 1, 1);
                break;
            case Direction.Right:
                this.transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                break;
        }
    }
}
