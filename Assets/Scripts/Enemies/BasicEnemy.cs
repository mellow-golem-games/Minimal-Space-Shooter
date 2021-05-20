using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    public GameObject bulletPrefab;

    //Events
    public static event Action OnBasicEnemyDestroyed;

    [SerializeField]
    private int speed = 4;

    [SerializeField]
    private int shootTimer = 60;

    private Rigidbody2D rb;

    private bool isInMovementLoop = false;
    private int maxFrameForDirection = 30;
    private int currentFrameDirection = 0;
    private double SIZEX = 0.49; //constant size of the basic enemy in pixels TODO change for resolution
    private double SIZEY = 0.51;

    Vector3 tempVect;
    Vector3 maxScreenBounds;

    void Start() {
      rb = GetComponent<Rigidbody2D>();
      Physics2D.IgnoreLayerCollision(9, 10);
      Physics2D.IgnoreLayerCollision(9, 9);
      maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void FixedUpdate () {
      Move();
      Shoot();
    }

    public bool CheckBounds(Vector3 nextPosition) {
      return nextPosition.x + SIZEX > maxScreenBounds.x
             || nextPosition.x + SIZEY < 0 - (maxScreenBounds.x / 2) // allow enemy half distance of half screen
             || nextPosition.y + SIZEY > maxScreenBounds.y
             || nextPosition.y - SIZEY < (-1 * maxScreenBounds.y);
    }

    public void Move() {

      if (!isInMovementLoop && currentFrameDirection != maxFrameForDirection) {
        currentFrameDirection++;
        Vector3 nextPosition = rb.transform.position + tempVect;

        if(CheckBounds(nextPosition)) {
          // Debug.Log("OOB");
         // handle the case where it's OOB  right now it just stutters
        } else {
          rb.MovePosition(nextPosition);
        }
      } else {
        currentFrameDirection = 0;
        tempVect = new Vector3(UnityEngine.Random.Range(-1,2), UnityEngine.Random.Range(-1,2), 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
      }
    }

    void OnCollisionEnter2D(Collision2D col) {
      Destroy(gameObject);
      OnBasicEnemyDestroyed?.Invoke();
    }

    public void Shoot() {
      if (Time.frameCount % shootTimer == 0) {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(rb.transform.position.x, rb.transform.position.y, 0), Quaternion.identity);
        bullet.layer = LayerMask.NameToLayer("EnemyBullets");
        bullet.tag = "Enemy";
      }
    }
}