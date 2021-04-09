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
    public Camera cam;

    Vector2 mPos;

    enum Direction
    {
        North,
        South,
        East,
        West
    }

    Direction curDirection = Direction.West;
    
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

        Vector2 aimDir = mPos - rb.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void UpdateInput()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        mPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    
    void movePlayer(Vector2 displacement)
    {
        Vector2 movement = new Vector2(canMoveHorizontal ? displacement.x : 0, canMoveVertical ? displacement.y : 0);
        UpdateDirection(movement);
        rb.MovePosition((Vector2) transform.position + (Vector2.ClampMagnitude(movement, 1) * speed * Time.deltaTime));
    }

    void UpdateDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        if (direction.x == 0 && direction.y == 0) { }     
        else if (angle < -135)
            curDirection = Direction.South;
        else if (angle <= -45)
            curDirection = Direction.West;
        else if (angle < 45)
            curDirection = Direction.North;
        else if (angle <= 135)
            curDirection = Direction.East;
        else
            curDirection = Direction.South;
    }
}
