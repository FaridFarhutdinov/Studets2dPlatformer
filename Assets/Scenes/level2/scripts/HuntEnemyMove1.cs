using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float aggro;
    public GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float DistToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        if (DistToPlayer < aggro) StartHunting();
        else StopHunting();
    }

    void StartHunting()
    {
        if (Player.transform.position.x < transform.position.x) {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(1, 1);
        }

        else if (Player.transform.position.x > transform.position.x){
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void StopHunting() { rb.velocity = new Vector2(0, 0); }

}
