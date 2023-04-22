using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchingDirections : MonoBehaviour
{
    private Rigidbody2D rb;
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public int HP = 3;

    CapsuleCollider2D touchingCol;
    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    [SerializeField]
    private bool _isGrounded;

    public bool IsGrounded { get { 
            return _isGrounded;
        } private set { 
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        } }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "obstacle")
        {
            HP -= 1;
            rb.AddForce(new Vector2(0, 2) * 1000f, ForceMode2D.Force);
        }
        if (HP == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
