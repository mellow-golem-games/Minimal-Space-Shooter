using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {
    public float speed;
    private float textureUnitSizeX;
    private Vector3 lastPosition;


    private void Start() {
      Sprite sprite = GetComponent<SpriteRenderer>().sprite;
      Texture2D texture = sprite.texture;
      textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }


    private void LateUpdate() {
       transform.Translate (Vector2.left * speed * Time.deltaTime);
       lastPosition = gameObject.transform.position;
       
       if (gameObject.transform.position.x * -1 >= textureUnitSizeX) {
         transform.position = new Vector3(0,gameObject.transform.position.y);

       }

    }


}
