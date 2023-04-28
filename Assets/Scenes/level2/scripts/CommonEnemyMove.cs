using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyMove : MonoBehaviour
{
    public float speed = 7f;
    float direction = -1f;
    public int hp = 3;

    void Start()
    {
        InvokeRepeating("reversal", 1.5f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void reversal() { direction *= -1; }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hit") hp -= 1;
        if (hp == 0) Destroy(this.gameObject);
    }
}
