using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour
{
    public float speed = 4;
    float directionX = -1f;
    //float directionY = -1f;
    int PathLength = 0;
   // float sin = 0.2f;

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(directionX * speed, 0, 0);
        transform.localScale = new Vector3(directionX, 1, 1);

        PathLength += 1;
        if (PathLength == 300) {
            directionX *= -1f;
            PathLength = 1;
        }

        /*if (PathLength % 5 == 0) {
            directionY += sin;
        }

        if (directionY == 1 || directionY == -1) {
            sin *= -1;
        }*/
    }
}
