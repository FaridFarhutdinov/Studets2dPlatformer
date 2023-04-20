using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour
{
    public float speed = 4f;
    float directionX = -1f;
    float directionY = -1f;
    int PathLength = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(speed * directionX, GetComponent<Rigidbody2D>().velocity.y);
    }

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

}
