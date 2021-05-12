using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
  private int startingxOffset = 2; //our default offset from the border

  // private float defaultPos = -8;
  // private double defaultWidth = 21.64103;
  // this is our default width for our target resolution. We may want to get more specific
  // and use the aspect ratio, but we can come back to that later and figure it out.
  // current imp probably changes difficulty based on screen size

  void Start() {
    float xPos = getStartingX();
    transform.position = new Vector3(xPos, 0, 0);
  }

  private float getStartingX () {
    float cameraHeight = Camera.main.orthographicSize * 2;
    float cameraWidth = cameraHeight * Camera.main.aspect;

    return (cameraWidth / 2) * -1 + startingxOffset ;
  }
}
