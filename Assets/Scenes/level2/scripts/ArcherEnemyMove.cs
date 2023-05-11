using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject arrow;
    public int hp = 3;
    private bool IsHeNear = false;
    public Transform startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsHeNear = true;
            Hunting();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsHeNear = false;
            Hunting();
        }
    }

    void Hunting()
    {
        if (IsHeNear == true)
        {
            Instantiate(arrow, startPos.position, Quaternion.identity);
            Invoke("Hunting", 2f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hit") TakeDamage();
        if (hp == 0) DiesOfCringe();
    }

    private void TakeDamage()
    {
        hp -= 1;
        rb.AddForce(new Vector2(-15 * transform.localScale.x, 5) * 10f, ForceMode2D.Force);
    }

    private void DiesOfCringe()
    {
        Destroy(this.gameObject);
    }
}
