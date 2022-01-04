using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimalTable
{
    [ShowInInspector] public Dictionary<ActType, AnimalEntity> Dictionary = new Dictionary<ActType, AnimalEntity>();

    public AnimalTable()
    {
        Dictionary.Clear();
        DB_Animal.ForEachEntity(entity =>
        {
            if (entity != null)
            {
                AnimalEntity animal = new AnimalEntity(entity);
                Dictionary.Add(animal.Type, animal);
            }
        });
    }
}
