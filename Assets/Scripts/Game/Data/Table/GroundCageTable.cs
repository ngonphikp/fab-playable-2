using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundCageTable
{
    [ShowInInspector] public Dictionary<ActType, GroundCageEntity> Dictionary = new Dictionary<ActType, GroundCageEntity>();

    public GroundCageTable()
    {
        Dictionary.Clear();
        DB_GroundCage.ForEachEntity(entity =>
        {
            if (entity != null)
            {
                Enum.TryParse(entity.Get<string>("Type"), out ActType actType);
                int index = entity.Get<int>("Index");

                if (!Dictionary.ContainsKey(actType)) Dictionary.Add(actType, new GroundCageEntity() { Type = actType });
                Dictionary[actType].Levels.Insert(index, new LevelAct(entity));
            }
        });
    }
}
