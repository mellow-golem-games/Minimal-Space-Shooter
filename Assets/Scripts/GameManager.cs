using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    public GameObject SpeedyEnemyPrefab;
    public GameObject BossEnemyPrefab;

    private int basicEnemyCount = 0;
    private int maxBasicEnemy = 5;

    private Vector3 maxScreenBounds;

    //enemy spawning stuff
    public float timeToSpawnBasicEnemy = 4.0f;
    private float timeSinceBasicEnemySpawn = 0.0f;

    public float timeToSpawnSpeedyEnemy = 9.0f;
    private float timeSinceSpeedyEnemySpawn = 0.0f;


    public int scoreForBoss = 100;
    private int scoreSinceBoss = 0;
    private bool bossSpawned = false;



    void OnEnable() {
      BasicEnemy.OnBasicEnemyDestroyed += BasicEnemyDestroyed;
      TankEnemy.OnTankEnemyDestroyed += TankEnemyDestroyed;
      ScoreHandler.OnScoreChange += ScoreChangeHandler;
    }


    void onDisable() {
      BasicEnemy.OnBasicEnemyDestroyed -= BasicEnemyDestroyed;
      TankEnemy.OnTankEnemyDestroyed -= TankEnemyDestroyed;
      ScoreHandler.OnScoreChange -= ScoreChangeHandler;
    }

    void Start() {
      maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update() {
      timeSinceBasicEnemySpawn += Time.deltaTime;
      timeSinceSpeedyEnemySpawn += Time.deltaTime;
      SpawnBasicEnemy();
      SpawnSpeedyEnemy();
      SpawnBossEnemy();
    }

    private void ScoreChangeHandler(int value) {
      scoreSinceBoss+= value;
    }

    private void SpawnSpeedyEnemy() {
      if(timeSinceSpeedyEnemySpawn >= timeToSpawnSpeedyEnemy) {
        Instantiate(SpeedyEnemyPrefab, new Vector3(maxScreenBounds.x + 3, 0, 0), Quaternion.identity);
        timeSinceSpeedyEnemySpawn = 0.0f;
      }
    }

    private void SpawnBasicEnemy() {
      if (basicEnemyCount < maxBasicEnemy && timeSinceBasicEnemySpawn >= timeToSpawnBasicEnemy) {
        Instantiate(BasicEnemyPrefab, new Vector3(maxScreenBounds.x + 3, 0, 0), Quaternion.identity);
        basicEnemyCount++;
        timeSinceBasicEnemySpawn = 0.0f;
      }
    }

    private void BasicEnemyDestroyed() {
      basicEnemyCount--;
    }

    private void SpawnBossEnemy() {
      if (scoreSinceBoss >= scoreForBoss && !bossSpawned) {
        Instantiate(BossEnemyPrefab, new Vector3(maxScreenBounds.x + 3, 0, 0), Quaternion.identity);
        bossSpawned = true;
      }
    }

    private void TankEnemyDestroyed() {
      bossSpawned = false;
      scoreSinceBoss = 0;
    }
}
