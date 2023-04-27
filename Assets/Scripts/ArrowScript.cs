using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float force = 10f;
    public GameObject Player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-10, 2) * force);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
            Destroy(this.gameObject);
    }
}
