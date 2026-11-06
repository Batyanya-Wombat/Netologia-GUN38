using UnityEngine;

public class IsometricMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Преобразуем ввод в изометрическое направление
        Vector2 isoDirection = new Vector2(input.x + input.y, (input.y - input.x) * 0.5f);
        isoDirection = isoDirection.normalized;

        rb.MovePosition(rb.position + isoDirection * speed * Time.fixedDeltaTime);
    }
}