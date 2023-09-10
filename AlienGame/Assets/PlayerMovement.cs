using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    
    private bool isMoving = false;

    private Vector2 lastMoveVector = new Vector2(0, 0);
    
    // Update is called once per frame
    void Update()
    {
        int horInput = 0;
        int verInput = 0;

        if (Input.GetKey("w"))
            verInput = 1;

        if (Input.GetKey("s"))
            verInput = -1;

        if (Input.GetKey("d"))
            horInput = 1;

        if (Input.GetKey("a"))
            horInput = -1;

        Vector2 moveVector = new Vector2(horInput, verInput);
        if (moveVector == Vector2.zero && lastMoveVector != Vector2.zero)
        {
            animator.SetTrigger("stopped");
            isMoving = false;
        }
        else if (moveVector != Vector2.zero && moveVector != lastMoveVector)
        {
            if (verInput > 0)
                animator.SetTrigger("walk_up");
            else if (verInput < 0)
                animator.SetTrigger("walk_down");
            else if (horInput > 0)
                animator.SetTrigger("walk_right");
            else if (horInput < 0)
                animator.SetTrigger("walk_left");
            isMoving = true;
        }

        rb.velocity = moveVector * Time.deltaTime * speed;
        lastMoveVector = moveVector;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided with: " + col.gameObject.name);
    }
}
