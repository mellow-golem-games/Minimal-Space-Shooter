using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField]
    private int speed = 6;
    private Renderer m_Renderer;
    private bool outOfView = false;

    void Start() {
      m_Renderer = GetComponent<Renderer>();
      GetComponent<AudioSource>().Play();
    }

    void LateUpdate() {
      int factor = gameObject.tag == "Enemy" ? -1 : 1; // enemies fire opposite direction
      transform.Translate (Vector2.right * speed * Time.deltaTime * factor);

      if (!GetComponent<Renderer>().isVisible) {
        // this is a bit of a workaround as enemy bullets seems to start not visible
        // this prevents this from happening as it delays a frame at which point the bullet is visible.
        outOfView = true;
      }
    }

    void Update() {
      if (!GetComponent<Renderer>().isVisible && outOfView) {
        // TODO fix this as it fires when new bullets are created on enemies
        Destroy(gameObject);
      }
    }

    void OnCollisionEnter2D(Collision2D col) {
      Destroy(gameObject);
    }
}
