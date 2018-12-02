﻿using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject Bonus;
    public int Max = 100;
    public int Spawned;
    //public int Spawned { get; private set; }

    void Start()
    {
        BonusSpawn();
    }

    private void BonusSpawn()
    {
        Spawned = Random.Range(1, Max);

        for (int i = 0; i < Spawned; i++)
        {
            var randomX = Random.Range(150, 800);
            var randomZ = Random.Range(-150, 330);
            Instantiate(Bonus, new Vector3(randomX, 0.87f, randomZ), Quaternion.identity);
        }
    }
}
