using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
  public int speed;


  void Start() {
    Physics2D.IgnoreLayerCollision(0, 11);
  }

  void Update()  {
    // also stops movement on ui clicks
    if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
      Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 currentPosition = gameObject.transform.position;

      // manually override non moveable direction
      target.x = currentPosition.x;

      transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
  }

  private void EndGame() {
    // weird place for it but this is our end game trigger anyways so should be fine
    SceneManager.LoadScene("Over");
  }

  void OnCollisionEnter2D(Collision2D col) {
    // TODO play some sort of animation here before destory as it will stop the invoke from happening
    // Destroy(gameObject);
    Invoke("EndGame", 1);
  }
}
