using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hog : MonoBehaviour
{
    public float walkSpeed  = 3f;
    private int direction = -1;
    private bool Is_Stuned = false;
    public int BossHp = 30;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Is_Stuned == false)
        {
            rb.velocity = new Vector2(walkSpeed * direction, rb.velocity.y);
        }

        if (BossHp < 1) Death();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Is_Stuned == false)
        {
            rb.velocity = new Vector2(walkSpeed * direction * 5, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "walls")
        {
            Is_Stuned = true;
            rb.AddForce(new Vector2(-15 * transform.localScale.x, 5) * 10f, ForceMode2D.Force);
            Invoke("Prosnuca", 3f);
        }

        if (col.gameObject.tag == "hit")
        {
            BossHp--;
        }
    }

    void Prosnuca()
    {
        direction *= -1;
        transform.localScale = new Vector3(direction, 1, 1);
        Is_Stuned = false;
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
