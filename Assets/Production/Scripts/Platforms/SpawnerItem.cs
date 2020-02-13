using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerItem : MonoBehaviour
{
    public GameObject[] ItemPrefabs;
    public GameObject[] ItemSpawners;
    public int ChanceApparitionItem;

    private void Start()
    {
        int roll = Random.Range(0, 100);
        if(roll <= ChanceApparitionItem) spawnSomethingAwesomePlease();
        
    }

    void spawnSomethingAwesomePlease()
    {
        int spawnerChoosen = Random.Range(0, ItemSpawners.Length);
        int itemChosen = Random.Range(0, ItemPrefabs.Length);
        Instantiate(ItemPrefabs[itemChosen], ItemSpawners[spawnerChoosen].transform);
    }
}
