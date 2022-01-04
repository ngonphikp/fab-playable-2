using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    public GeneralTable General;
    public ActTable Act;
    public CropTable Crop;
    public AnimalTable Animal;
    public HumanTable Human;
    public GroundLandTable GroundLand;
    public GroundCageTable GroundCage;
    public GroundStoreTable GroundStore;
    public PlayerTable Player;

    private void Start()
    {
        
    }

    public void Init(Transform parent = null)
    {
        DataManager.Data = this;
        if (parent) transform.SetParent(parent);

        General = new GeneralTable();
        Act = new ActTable();
        Crop = new CropTable();
        Animal = new AnimalTable();
        Human = new HumanTable();
        GroundLand = new GroundLandTable();
        GroundCage = new GroundCageTable();
        GroundStore = new GroundStoreTable();
        Player = new PlayerTable();
    }
}
