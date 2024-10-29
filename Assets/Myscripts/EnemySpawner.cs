using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public GameObject enemyPrefab;
    public float range;

    public float spawnTime = 1f;
    private float timer;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (timer <= 0)
        {
            float tx = Random.Range(10f, range) * (Random.Range(0, 2) * 2 - 1) + player.position.x;
            float tz = Random.Range(10f, range) * (Random.Range(0, 2) * 2 - 1) + player.position.z;

            Instantiate(
                enemyPrefab,
                new Vector3(tx, enemyPrefab.transform.localScale.y / 2, tz),
                Quaternion.identity
            );

            timer = spawnTime;
        }

        timer -= Time.deltaTime;
    }
}
