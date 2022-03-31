using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject enemyPrefab;
  private float spawnRange = 9.0f;
  public int enemyCount;
  public int waveNumber = 1;
  public GameObject powerupPrefab;
  void Start()
  {
    spawnEnemyWave(waveNumber);
    spawnGemPowerUp();
  }

  // Update is called once per frame
  void Update()
  {
    enemyCount = FindObjectsOfType<Enemy>().Length;

    if (enemyCount == 0)
    {
      waveNumber++;
      spawnEnemyWave(waveNumber);
      spawnGemPowerUp();
    }
  }
  void spawnEnemyWave(int enemiesToSpawn)
  {
    for (int i = 0; i < enemiesToSpawn; i++)
    {
      Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
  }

  void spawnGemPowerUp()
  {
      Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
  }

  private Vector3 GenerateSpawnPosition()
  {
    float randomNum = Random.Range(-spawnRange, spawnRange);
    Vector3 randomPos = new Vector3(randomNum, 0, randomNum);
    return randomPos;
  }
}
