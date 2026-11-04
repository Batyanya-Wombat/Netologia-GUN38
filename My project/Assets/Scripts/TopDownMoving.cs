using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Debug.Log("X: " + moveX + " | Y: " + moveY);

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * moveSpeed;
    }
}