using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        rb.velocity = movement * moveSpeed;

        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }
}
