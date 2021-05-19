using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {

   void Move();

   void Shoot();

   bool CheckBounds(Vector3 nextPosition);
}
