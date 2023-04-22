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
    }

    void Update()
    {
        float DistToPlayer = Vector2.Distance(transform.position, Player.transform.position);
        if (DistToPlayer < aggro) StartHunting();
        else StopHunting();
    }

    void StartHunting()
    {
        if (Player.transform.position.x * Player.transform.position.x + Player.transform.position.y * Player.transform.position.y < transform.position.x * transform.position.x) {
            Instantiate(arrow, startPos.position, Quaternion.identity);
        }
    }

    void StopHunting() { rb.velocity = new Vector2(0, 0); }

}
