using MEC;
using System.Collections.Generic;
using UnityEngine;

public class GroundStore : Ground
{
    public GroundStoreData StoreData => storeData;
    public GroundStoreSave StoreSave => storeSave;

    [Header("Object")]
    [SerializeField] private Transform m_PosStore;
    [SerializeField] private Signs m_Signs;
    [SerializeField] private Store m_Store;

    [SerializeField] private InteractCircle m_InterLoot;

    [Header("UI")]
    [SerializeField] private UIProgress m_Progress;

    [Header("Properties")]
    [SerializeField] private GroundStoreData storeData;
    [SerializeField] private UpgradeGround upgrade;
    private GroundStoreSave storeSave = new GroundStoreSave();
    private GroundStoreEntity storeEntity;

    private CoroutineHandle handleLoot;
    private int incre = 0;

#if UNITY_EDITOR
    private void OnValidate()
    {
        upgrade = this.GetComponent<UpgradeGround>();
    }
#endif

    private void OnDestroy()
    {
        KillLoot();
    }

    public override void Set(GroupGround group)
    {
        base.Set(group);

        storeSave.Id = this.Id;
        storeSave.SetType(storeData.Type);
        storeSave = DataManager.Save.Stores(storeSave);

        storeEntity = DataManager.Data.GroundStore.Data;

        m_Signs.Set(storeData.Type);
        m_Progress.Set(storeData.Type);
        m_Progress.Set(storeSave.Count, storeData.MaxCount);

        upgrade.Init(Data, storeSave, storeData, storeEntity);
        upgrade.m_OnUpgradeHandler.AddListener(UpgradeHandler);
        upgrade.m_OnUpgradeSuccess.AddListener(UpgradeSucess);
        upgrade.m_OnShowAds.AddListener(ShowAds);

        if (!Save.IsLock)
        {
            SetLevel();

            for (int i = 0; i < storeSave.Level; i++)
            {
                upgrade.Upgrade(i);
            }
        }
    }

    private void UpgradeHandler(int level)
    {
        var lv = storeEntity.Levels[level] as LevelStore;

        switch (lv.Type)
        {
            case UpStoreType.IncreaseCapacity:
                int count = (int)storeEntity.Levels[level].Value;
                IncreaseCapacity(count);
                break;
            default:
                break;
        }
    }

    private void UpgradeSucess(int level)
    {
        var lv = storeEntity.Levels[level] as LevelStore;

        string path = lv.Type.ToString();
        switch (lv.Type)
        {
            case UpStoreType.IncreaseCapacity:
                path += "Store";
                break;
        }
        upgrade.ShowToast(path);
        SetLevel();
    }

    private void ShowAds(int level)
    {
        upgrade.Upgrade(level);
            GameManager.S.isReward = true;
    }

    public void OpenSuccess()
    {
        SetLevel();
    }

    public void SetLevel()
    {
        if (storeSave.Level != 0)
        {
            if (m_Store)
            {
                Vector3 oldPos = m_Store.transform.position;
                PoolManager.S.Despawn(m_Store);
                m_Store.transform.position = oldPos;
                m_Store = null;
            }

            Store asStore = ResourceManager.S.LoadStore("Prefabs/Stores/" + storeEntity.Levels[storeSave.Level - 1].Visual);
            Store store = PoolManager.S.Spawn(asStore, m_PosStore);

            m_Store = store;
        }

        m_Store.Set(this);
    }

    private void IncreaseCapacity(int value)
    {
        storeData.IncreaseMaxCount(value);
        m_Progress.Set(storeSave.Count, storeData.MaxCount);
    }

#if UNITY_EDITOR
    public void ToolLoadDataStore()
    {
        m_Signs.ToolSet(storeData.Type);
        m_Progress.ToolSet(storeData.Type);
    }
#endif

    public override Store GetStore()
    {
        return m_Store;
    }

    public void InteractLootCropEnter2D(Collider2D collision)
    {
        //Debug.Log("InteractLootCropEnter2D: " + collision.tag);
        if (collision.CompareTag("Player"))
        {
            m_InterLoot.Motion();

            Player player = collision.GetComponentInParent<Player>();
            KillLoot();
            handleLoot = Timing.RunCoroutine(_LootAct(player));
        }
    }

    Human human;
    Human Human
    {
        get
        {
            if (human == null)
            {
                human = FindObjectOfType<Human>();
            }
            return human;
        }
    }

    private IEnumerator<float> _LootAct(Player player)
    {
        RewardData reward = new RewardData();
        reward.Type = RewardType.Currency;
        CurrencyData currency = new CurrencyData();
        currency.Type = CurrencyType.Coin;
        currency.Value = 450;
        reward.Data = currency;
        while (true)
        {
            if (storeSave.Count > 0)
            {
                yield return Timing.WaitForSeconds(0.1f);
                
                GameScene.S.Bag.Loot(reward);
                Human.Happy();
                storeSave.SubtractCount(storeSave.Count);
                m_Progress.Set(storeSave.Count, storeData.MaxCount);
            }
            yield return Timing.WaitForOneFrame;
        }
    }

    public void InteractLootCropExit2D(Collider2D collision)
    {
        //Debug.Log("InteractLootCropExit2D: " + collision.tag);
        if (collision.CompareTag("Player"))
        {
            m_InterLoot.UnMotion();
            KillLoot();
        }
    }

    private void KillLoot()
    {
        if (handleLoot.IsValid)
        {
            if (incre > 0)
            {
                DataManager.Save.Bag.IncreaseAct(storeData.Type, incre);
                incre = 0;
            }
            Timing.KillCoroutines(handleLoot);
        }
    }

    public void Collect(bool isCreBag = false)
    {
        if (isCreBag) DataManager.Save.Bag.IncreaseAct(storeData.Type, storeSave.Count);
        SubstractAct(storeSave.Count);
    }

    [SerializeField] TutorialBox tutorialBox;
    public void IncreaseAct(int value)
    {
        storeSave.IncreaseCount(value, storeData.MaxCount);
        m_Progress.Set(storeSave.Count, storeData.MaxCount);
        tutorialBox.gameObject.SetActive(true);
    }

    public void SubstractAct(int value)
    {
        storeSave.SubtractCount(value);
        m_Progress.Set(storeSave.Count, storeData.MaxCount);
    }

    public Transform GetProgress()
    {
        return m_Progress.transform;
    }
}
