using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public int speed;

  void Update()  {
    if (Input.GetMouseButton(0)) {
      Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 currentPosition = gameObject.transform.position;

      // manually override non moveable direction
      target.x = currentPosition.x;

      transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
  }
}
