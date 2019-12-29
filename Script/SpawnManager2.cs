using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{

    public Transform[] spawnPoints; // 적 AI를 소환할 위치들
    Vector3[] positions = new Vector3[6];
    public GameObject enemy;
   private  bool isSpawn = true;
    public float spawnDelay = 3.0f;
    float spawnTimer = 0f;
    public Door_Open door_open;
    public int Count;

    // Start is called before the first frame update
    void Start()
    {
        isSpawn = true;
    }
    private void SpawnWave()
    {

        SpawnEnemy();


    }


    void SpawnEnemy()
    {

        if (isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);

                Instantiate(enemy, spawnPoints[Random.Range(0, 3)].position, Quaternion.identity);
                Count++;
                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }

    }
    void Update()
    {
        SpawnWave();
        if(Count > 10)
        {
            isSpawn = false;
            door_open.Door2.SetActive(false);
        }
        
    }
}

// Update is called once per frame



