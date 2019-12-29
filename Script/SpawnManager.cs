using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPoints; // 적 AI를 소환할 위치들
    Vector3[] positions = new Vector3[6];
    public GameObject enemy;
    private bool isSpawn = true;
    private int Count;
    public float spawnDelay = 3.0f;
    float spawnTimer = 0f;
    public Door_Open door_open;
   

  //  private List<EnemyAI> enemies = new List<EnemyAI>(); // 생성된 적들을 담는 리스트
   
    // Start is called before the first frame update
    void Start()
    {
        isSpawn = true;
        Count = 0;
       
    }
    private void SpawnWave()
    {      
              
            SpawnEnemy(); 
       

    }


    void SpawnEnemy()
    {
      
       if(isSpawn == true)
          {
             if(spawnTimer > spawnDelay)
               {
                 int rand = Random.Range(0, positions.Length);

                 Instantiate(enemy, spawnPoints[Random.Range(0,3)].position, Quaternion.identity);
                Count++;

                 spawnTimer = 0f;
                }
                spawnTimer += Time.deltaTime;
            }

        }
    void Update()
    {
        SpawnWave();
        if (Count >10) { 
            isSpawn = false;
            door_open.Door.SetActive(false);
        }
       

    }
}
    
// Update is called once per frame



