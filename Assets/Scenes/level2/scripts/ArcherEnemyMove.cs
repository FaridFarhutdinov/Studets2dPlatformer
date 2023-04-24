using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float aggro;
    public Transform Player;
    public GameObject arrow;
    public Transform startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Instantiate(arrow, startPos.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        if (transform.position.x - Player.position.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(-1, 1, 1);
        float DistToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        if (DistToPlayer < aggro) StartHunting();
        else StopHunting();
    }

    void StartHunting()
    {
            Instantiate(arrow, startPos.position, Quaternion.identity);
    }

    void StopHunting() { rb.velocity = new Vector2(0, 0); }

}
