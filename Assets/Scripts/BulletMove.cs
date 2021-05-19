using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField]
    private int speed = 6;
    private Renderer m_Renderer;

    void Start() {
      m_Renderer = GetComponent<Renderer>();
    }

    void LateUpdate() {
      int factor = gameObject.tag == "Enemy" ? -1 : 1; // enemies fire opposite direction
      transform.Translate (Vector2.right * speed * Time.deltaTime * factor);
    }

    void Update() {
      if (!m_Renderer.isVisible) {
        // TODO fix this as it fires when new bullets are created on enemies
        // Destroy(gameObject);
      }
    }

    void OnCollisionEnter2D(Collision2D col) {
      Destroy(gameObject);
    }
}
