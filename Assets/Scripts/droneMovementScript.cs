using UnityEngine;

public class droneMovementScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 movementForce = new Vector2 (0, 0);
    private Vector2 forwardRotationForce = new Vector2(0, 0);
    private Vector2 backwardRotationForce = new Vector2(0, 0);
    private float engineAngle = 0; 

    public GameObject engine;
    public GameObject engineBig;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        movementForce.x = Input.GetAxis("Horizontal");
        movementForce.y = Input.GetAxis("Vertical") * 0.8f; 
        _rigidbody2D.AddForce(movementForce);
        engineAngle = Mathf.Atan2(0.2f + movementForce.y, movementForce.x) * Mathf.Rad2Deg + 270f;
        engine.transform.rotation = Quaternion.Euler(0, 0, engineAngle);
        engineBig.transform.rotation = Quaternion.Euler(0, 0, engineAngle);
        forwardRotationForce = transform.up * Input.GetAxis("bodyRotation") * 0.05f;
        backwardRotationForce = transform.up * Input.GetAxis("bodyRotation") * 0.05f;
        _rigidbody2D.AddForceAtPosition(forwardRotationForce, engineBig.transform.position);
        _rigidbody2D.AddForceAtPosition(backwardRotationForce, engine.transform.position);
    }
}
