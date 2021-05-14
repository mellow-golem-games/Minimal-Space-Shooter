using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    public GameObject playerRef;
    public GameObject bulletPrefab;

    public void Fire() {
      float playerX = playerRef.transform.position.x;
      float playerY = playerRef.transform.position.y;

      Instantiate(bulletPrefab, new Vector3(playerX, playerY, 0), Quaternion.identity);
    }
}
