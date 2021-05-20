using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;

    private int basicEnemyCount = 0;
    private int maxBasicEnemy = 5;

    void OnEnable() {
      BasicEnemy.OnBasicEnemyDestroyed += BasicEnemyDestroyed;
    }


    void onDisable() {
      BasicEnemy.OnBasicEnemyDestroyed -= BasicEnemyDestroyed;
    }

    void Start() {
      InvokeRepeating("SpawnBasicEnemy", 2.0f, 5.0f);

    }


    private void SpawnBasicEnemy() {
      if (basicEnemyCount < maxBasicEnemy) {
        Instantiate(BasicEnemyPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        basicEnemyCount++;
      }
    }

    private void BasicEnemyDestroyed() {
      basicEnemyCount--;
    }
}
