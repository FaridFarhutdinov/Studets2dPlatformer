using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    float direction = -1f;
    public float speed;
    public int hp = 3;
    public GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("reversal", 1.5f, 3.0f);
    }

    void Update()
    {
        rb.velocity = new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void reversal() { direction *= -1; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            InvokeRepeating("StartHunting", 1.0f, 1.5f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            StopHunting();
        }
    }



    void StartHunting()
    {
        if (Player.transform.position.x < transform.position.x){
            direction = -1f;
            //charge(-1);
        }

        else if (Player.transform.position.x > transform.position.x){
            direction = 1f;
            //charge(1);
        }
    }

    //void charge(int dir) { rb.velocity = new Vector2(speed * 5 * direction, GetComponent<Rigidbody2D>().velocity.y); }

    void StopHunting() { new Vector2(speed * direction, GetComponent<Rigidbody2D>().velocity.y); }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hit") hp -= 1; 
        if (hp == 0) Destroy(this.gameObject);
    }

}
