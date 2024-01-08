using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 secsBetweenSpawnsMinMax;
    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;
    public Vector2 spawnSizeMinMax;
    public Vector2 spawnAngleMinMax;


    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secsBetweenSpawnsMinMax.y, secsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            float spawnAngle = Random.Range(spawnAngleMinMax.x, spawnAngleMinMax.y);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            nextSpawnTime += Time.time + secondsBetweenSpawns;
            Vector2 SpawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), spawnSize + Random.Range(-screenHalfSizeWorldUnits.y, screenHalfSizeWorldUnits.y));

            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, SpawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
