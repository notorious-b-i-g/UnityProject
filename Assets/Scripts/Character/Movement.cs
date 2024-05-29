using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lst_movement;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            movement.Normalize();
            lst_movement = movement;
        }

        animator.SetFloat("Vertical_Move", movement.y);
        animator.SetFloat("Horizontal_Move", movement.x);
        animator.SetFloat("lst_Vertical_Move", lst_movement.y);
        animator.SetFloat("lst_Horizontal_Move", lst_movement.x);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
