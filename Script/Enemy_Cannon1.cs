using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cannon1 : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // target = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target);
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject spawn_point = GameObject.Find("sp_bullet1");
            GameObject bullet = Instantiate(bulletPrefab, spawn_point.transform.position, spawn_point.transform.rotation);
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
