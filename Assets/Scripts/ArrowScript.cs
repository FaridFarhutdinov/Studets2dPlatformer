using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float force = 0.025f;
    public Transform Player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Player.position.x * force, Player.position.y * force), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
            Destroy(this.gameObject);
    }
}
