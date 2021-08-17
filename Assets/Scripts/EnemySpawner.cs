using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Slime slimePrefab;
    public float spawnChance;

    public float startingSpawnChance;
    public float spawnChanceDelta;
    private void Start()
    {
        spawnChance = startingSpawnChance;
        InvokeRepeating("IncreaseDifficulty", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float spawnRandomRoll = Random.Range(0f, 1f);
        if (spawnRandomRoll < spawnChance)
        {
            SpawnSlime();
        }

    }

    void SpawnSlime()
    {
        float zPosition = Random.Range(-5f, 5f);
        Slime newSlime = Instantiate(slimePrefab, transform.position + (Vector3.forward * zPosition), slimePrefab.transform.rotation);
        float slimeSpeedMultiplier = Random.Range(0.95f, 1.1f);
        newSlime.speed *= slimeSpeedMultiplier;
    }

    void IncreaseDifficulty()
    {
        spawnChance += spawnChanceDelta;
    }
}
