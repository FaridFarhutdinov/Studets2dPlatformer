using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour
{
    public float speed = 4f;
    float direction = -1f;
    int kostil = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    /*void 2D(Collision2D col)
    {
        if (col.gameObject.tag == "level")
            direction *= -1f;
    }*/

    void FixedUpdate()
    {
        kostil += 1;
        if (kostil == 450){
            direction *= -1f;
            kostil = 0;
        }
    }

}
