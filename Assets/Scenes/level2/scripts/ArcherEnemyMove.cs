using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float aggro = 10;
    //public GameObject Player;
    public GameObject arrow;
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

}
