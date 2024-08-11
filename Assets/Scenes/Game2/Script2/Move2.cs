using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector2 movement;

    void Update()
    {
        // รับค่าการเคลื่อนที่จาก Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // อัปเดตแอนิเมชันโดยใช้ SetBool
        animator.SetBool("isSwim", movement.sqrMagnitude > 0);

        // Flip ตัวละครเมื่อเคลื่อนที่ในแกน X
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        // เคลื่อนที่ตัวละคร
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
