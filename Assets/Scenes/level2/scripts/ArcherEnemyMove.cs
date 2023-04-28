using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject arrow;
    public int hp = 3;
    public Transform startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            InvokeRepeating("StartHunting", 1.0f, 1.5f);
        }
    }

    void StartHunting()
    {
        Instantiate(arrow, startPos.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hit") hp -= 1;
        if (hp == 0) Destroy(this.gameObject);
    }
}
