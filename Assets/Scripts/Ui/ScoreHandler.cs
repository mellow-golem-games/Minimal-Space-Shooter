using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
  public Text highScore;
  private int score = 0;

  private int basicEnemyValue = 10;

  void OnEnable() {
    BasicEnemy.OnBasicEnemyDestroyed += BasicEnemyDestroyed;
  }


  void onDisable() {
    BasicEnemy.OnBasicEnemyDestroyed -= BasicEnemyDestroyed;
  }

  void Start () {
    highScore.text = "Score: " + score;
  }


  void Update () {

  }

  private void updateScoreText() {
    highScore.text = "Score: " + score;
  }

  private void BasicEnemyDestroyed() {
    score += basicEnemyValue;
    updateScoreText();
  }

}
