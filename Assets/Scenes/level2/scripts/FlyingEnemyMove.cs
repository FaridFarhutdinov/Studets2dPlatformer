using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour
{
    public float speed = 4;
    float directionX = -1;
    float directionY = -1;
    int PathLength = 0;
    public int hp = 3;

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(directionX * speed, directionY * speed, 0);
        transform.localScale = new Vector3(directionX, 1, 1);

        PathLength += 1;
        if (PathLength == 300){
            directionX *= -1f;
            PathLength = 1;
        }

        if (PathLength % 30 == 0){
            directionY *= -1f;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hit") hp -= 1;
        if (hp == 0) Destroy(this.gameObject);
    }

}
