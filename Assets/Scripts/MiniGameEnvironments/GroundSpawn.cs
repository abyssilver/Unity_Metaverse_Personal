using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{

    public GameObject groundPrefab;
    
    public float moveSpeed = 2f;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;

    public float minY = -6f;
    public float maxY = 0f;

    private float timer;
    private float nextSpawnTime;


    void Start()
    {
        SetNextSpawnTime();
    }

    
    void Update()
    {
        if (!MinigameManager.GameStarted)
            return;
        timer += Time.deltaTime;

        if(timer >= nextSpawnTime)
        {
            SpawnGround();
            SetNextSpawnTime();
            timer = 0f;
        }

    }

    void SpawnGround()
    {
        GameObject ground = Instantiate(groundPrefab);

        float randomY = Random.Range(minY, maxY);

        ground.transform.position = new Vector3(20f, randomY, 0f);
        ground.transform.localScale = Vector3.one;

        ground.AddComponent<MovingObject>().moveSpeed = moveSpeed;
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}
