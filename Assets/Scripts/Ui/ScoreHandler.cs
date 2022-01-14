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
  private int speedyEnemnyValue = 15;
  private int bossEnemyValue = 50;
  private int startingHighScore;

  public static event Action<int> OnScoreChange;

  void OnEnable() {
    BasicEnemy.OnBasicEnemyDestroyed += BasicEnemyDestroyed;
    TankEnemy.OnTankEnemyDestroyed += TankEnemyDestroyed;
    SpeedyEnemy.OnSpeedyEnemyDestroyed += SpeedyEnemyDestroyed;
  }


  void OnDisable() {
    BasicEnemy.OnBasicEnemyDestroyed -= BasicEnemyDestroyed;
    TankEnemy.OnTankEnemyDestroyed -= TankEnemyDestroyed;
    SpeedyEnemy.OnSpeedyEnemyDestroyed -= SpeedyEnemyDestroyed;
  }

  void Start () {
    startingHighScore = PlayerPrefs.GetInt ("highscore", 0);
    highScore.text = "Score: " + score;
  }


  void Update () {
  }

  private void checkHighScore(int score) {
    if (score > startingHighScore) {
      PlayerPrefs.SetInt ("highscore", score);
    }
  }

  private void updateScoreText() {
    highScore.text = "Score: " + score;
    checkHighScore(score);
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

  private void SpeedyEnemyDestroyed() {
    score += speedyEnemnyValue;
    updateScoreText();
  }

}
