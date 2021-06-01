using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] obstacles;

    private float spawnRate = 2f;
    private float spawnRateThreshold = 1f;

    private void Update()
    {
        int currentScore = FindObjectOfType<ScoreManager>().GetScore();
        if (spawnRate > spawnRateThreshold)
        {
            spawnRate -= currentScore * 0.01f;
        }
    }
    public void StartSpawn()
    {
        StartCoroutine("RandomSpawn");
    }

    IEnumerator RandomSpawn ()
    {
        for (; ; )
        {
            Spawn();
            float waitForSeconds = Random.Range(spawnRate, spawnRate * 2);
            yield return new WaitForSeconds(waitForSeconds);
        }
    }

    void Spawn()
    {
        if (!FindObjectOfType<PlayerController>().gameOver)
        {
            int choice = Random.Range(0, obstacles.Length);
            GameObject obstacle = obstacles[choice];
            Instantiate(obstacle, new Vector3(40, 0, 0), obstacle.transform.rotation);
        }
    }
}
