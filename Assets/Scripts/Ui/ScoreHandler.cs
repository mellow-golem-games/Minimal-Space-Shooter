using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
  public Text highScore;
  private int score = 0;

  private int basicEnemyValue = 10;
  private int bossEnemyValue = 50;

  public static event Action<int> OnScoreChange;

  void OnEnable() {
    BasicEnemy.OnBasicEnemyDestroyed += BasicEnemyDestroyed;
    TankEnemy.OnTankEnemyDestroyed += TankEnemyDestroyed;
  }


  void onDisable() {
    BasicEnemy.OnBasicEnemyDestroyed -= BasicEnemyDestroyed;
    TankEnemy.OnTankEnemyDestroyed -= TankEnemyDestroyed;
  }

  void Start () {
    highScore.text = "Score: " + score;
  }


  void Update () {

  }

  private void updateScoreText() {
    highScore.text = "Score: " + score;
    OnScoreChange?.Invoke(score);
  }

  private void BasicEnemyDestroyed() {
    score += basicEnemyValue;
    updateScoreText();
  }

  private void TankEnemyDestroyed() {
    score += bossEnemyValue;
    updateScoreText();
  }

}
