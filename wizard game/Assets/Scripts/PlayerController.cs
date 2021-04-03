using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Vector2 movementInput;
    [SerializeField] bool canMove = true;
    [SerializeField] bool canMoveHorizontal = true;
    [SerializeField] bool canMoveVertical = true;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateInput();
    }

    void FixedUpdate()
    {
        if (canMove)
            movePlayer(movementInput);
    }

    void UpdateInput()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void movePlayer(Vector2 displacement)
    {
        Vector2 movement = new Vector2(canMoveHorizontal ? displacement.x : 0, canMoveVertical ? displacement.y : 0);
        rb.MovePosition((Vector2) transform.position + (Vector2.ClampMagnitude(movement, 1) * speed * Time.deltaTime));
    }
}
