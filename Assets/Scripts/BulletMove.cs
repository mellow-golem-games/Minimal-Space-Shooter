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
      transform.Translate (Vector2.right * speed * Time.deltaTime);
    }

    void Update() {
      if (!m_Renderer.isVisible) {
        Destroy(gameObject);
      }
    }
}
