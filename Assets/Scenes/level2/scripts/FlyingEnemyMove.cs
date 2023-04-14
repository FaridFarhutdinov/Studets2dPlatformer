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
        //GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
        transform.position = transform.position + new Vector3(directionX * speed * Time.deltaTime, directionY * speed * Time.deltaTime, 0);
        transform.localScale = new Vector3(directionX, 1, 1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "level")
            directionX *= -1f;
    }

    void FixedUpdate()
    {
        PathLength += 1;
        if (PathLength == 450){
            directionX *= -1f;
            PathLength = 0;
        }

        if (PathLength % 30 == 0){
            directionY *= -1f;
        }

    }

}
