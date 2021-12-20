using UnityEngine;

public class droneMovementScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private Vector2 movementForce = new Vector2 (0, 0);
    private Vector2 forwardRotationForce = new Vector2(0, 0);
    private Vector2 backwardRotationForce = new Vector2(0, 0);

    private float engineAngle = 0;

    //newPhysics


    private Vector2 dampersForce = new Vector2(0, 0);
    private Vector2 movementDirection = new Vector2(0, 0);
    private Vector2 velocityDirected = new Vector2(0, 0);
    private Vector2 velocityPerpendicular = new Vector2(0, 0);

    [SerializeField] private float forceMultipier = 50f;

    public GameObject engine;
    public GameObject engineBig;
    
    void Start()
    {
        Cursor.visible = false;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        movementDirection = ((Input.GetAxis("Horizontal")) * transform.right + Input.GetAxis("Vertical") * transform.up) * forceMultipier;
        velocityDirected = (Vector2.Dot(_rigidbody2D.velocity, movementForce) / movementForce.magnitude) * movementForce.normalized;
        Debug.DrawRay(_rigidbody2D.transform.position, dampersForce.normalized, Color.blue);
        movementForce = movementDirection - Vector2.down * _rigidbody2D.mass * 9.81f;
        _rigidbody2D.AddForce(movementForce);
        Debug.DrawRay(_rigidbody2D.transform.position, movementForce.normalized, Color.green);
        engineAngle = Mathf.Atan2(movementForce.y, movementForce.x) * Mathf.Rad2Deg + 270f;
        engine.transform.rotation = Quaternion.Euler(0, 0, engineAngle);
        engineBig.transform.rotation = Quaternion.Euler(0, 0, engineAngle);
        forwardRotationForce = transform.up * Input.GetAxis("bodyRotation") * forceMultipier * 0.05f;
        backwardRotationForce = transform.up * Input.GetAxis("bodyRotation") * forceMultipier * 0.05f;
        _rigidbody2D.AddForceAtPosition(forwardRotationForce, engineBig.transform.position);
        _rigidbody2D.AddForceAtPosition(backwardRotationForce, engine.transform.position);
    }
}
