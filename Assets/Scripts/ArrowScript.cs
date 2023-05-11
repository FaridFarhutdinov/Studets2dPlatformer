using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float force = 5f;
    public Transform Player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Player.position.x - transform.position.x, transform.position.y - Player.position.y);
        rb.AddForce(direction * force);
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(Player.position.x - transform.position.x, transform.position.y - Player.position.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
            Destroy(this.gameObject);
    }
}
