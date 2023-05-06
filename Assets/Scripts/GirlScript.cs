using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirlScript : MonoBehaviour
{
    public float m_moveSpeed = 2f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    Vector2 moveInput = Vector2.zero;

    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    Rigidbody2D rb;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log("kajhdsfhgafj");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput != Vector2.zero)
        {
            bool success = MovePlayer(moveInput);
            animator.SetBool("isWalking", success);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        

    }

    public bool MovePlayer(Vector2 direction)
    {
        int count = rb.Cast(direction, movementFilter, castCollisions, m_moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            Vector2 moveVector = direction * m_moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveVector);
            return true;
        } else
        {
            return false;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        } 
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
