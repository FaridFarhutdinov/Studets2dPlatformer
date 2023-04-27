using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direction = 1;
    public float aggro;
    public Transform Player;
    public GameObject arrow;
    public Transform startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Player.position.x < transform.position.x) direction *= -1;
        transform.localScale = new Vector3(direction, 1, 1);

        float DistToPlayer = Vector2.Distance(transform.position, Player.position);

        if (DistToPlayer < aggro) StartHunting();
        else StopHunting();
    }

    void StartHunting()
    {
            Instantiate(arrow, startPos.position, Quaternion.identity);
    }

    void StopHunting() { rb.velocity = new Vector2(0, 0); }

}
