using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    public GameObject BossEnemyPrefab;

    private int basicEnemyCount = 0;
    private int maxBasicEnemy = 5;
    private int score = 0; // TODO this was fine for testing but now we have this in two places, turn to scripable so we can re-use

    private Vector3 maxScreenBounds;

    //enemy spawning stuff
    public float timeToSpawnBasicEnemy = 5.0f;
    private float timeSinceBasicEnemySpawn = 0.0f;


    public int scoreForBoss = 100;
    private int scoreSinceBoss = 0;
    private bool bossSpawned = false;

    // enemy values
    private int basicEnemyScoreVal = 10;
    private int bossEnemyScoreVal = 50;


    void OnEnable() {
      BasicEnemy.OnBasicEnemyDestroyed += BasicEnemyDestroyed;
      TankEnemy.OnTankEnemyDestroyed += TankEnemyDestroyed;
    }


    void onDisable() {
      BasicEnemy.OnBasicEnemyDestroyed -= BasicEnemyDestroyed;
      TankEnemy.OnTankEnemyDestroyed -= TankEnemyDestroyed;
    }

    void Start() {
      maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update() {
      timeSinceBasicEnemySpawn += Time.deltaTime;
      if (!bossSpawned) {
        // we don't spawn new enemies while the boss is active
        SpawnBasicEnemy();
        SpawnBossEnemy();
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
      score+= basicEnemyScoreVal;
      scoreSinceBoss+= basicEnemyScoreVal;
    }

    private void SpawnBossEnemy() {
      if (scoreSinceBoss >= scoreForBoss && !bossSpawned) {
        Instantiate(BossEnemyPrefab, new Vector3(maxScreenBounds.x + 3, 0, 0), Quaternion.identity);
        bossSpawned = true;
      }
    }

    private void TankEnemyDestroyed() {
      score+= bossEnemyScoreVal;
      bossSpawned = false;
      scoreSinceBoss = 0;
    }
}
