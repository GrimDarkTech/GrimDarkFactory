using UnityEngine;

public class toolMode3Script : MonoBehaviour
{

    private Vector3 cursorPosition = new Vector2(0, 0);
    private Vector3 cursorDirection = new Vector2(0, 0);

    private float focusRange = 0.64f;
    [SerializeField] private float maxFocusRange = 0.70f;
    [SerializeField] private float minFocusRange = 0.46f;

    public float forceMultiplier = 60f;
    public float rotationAngle = 0.1f;
    public float forceRadius = 0.44f;
    public GameObject droneToolFirePoint;
    public GameObject droneToolFocusPoint;
    public ParticleSystem gravityParticleSystem;
    ParticleSystem.MainModule gravityParticleSystemMain;
    ParticleSystem.ShapeModule gravityParticleSystemShape;

    void Start()
    {
        gravityParticleSystem = droneToolFirePoint.GetComponentInChildren<ParticleSystem>();
        gravityParticleSystemMain = gravityParticleSystem.main;
        gravityParticleSystemShape = gravityParticleSystem.shape;
    }
    void FixedUpdate()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0;
        cursorDirection = (cursorPosition - gameObject.transform.position).normalized;
        rotationAngle = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);


        focusRange = (cursorPosition - droneToolFirePoint.transform.position).magnitude;

        if (focusRange > maxFocusRange)
        {
            focusRange = maxFocusRange;
        }
        if (focusRange < minFocusRange)
        {
            focusRange = minFocusRange;
        }
        RaycastHit2D focusRayHit;
        focusRayHit = Physics2D.Raycast(droneToolFirePoint.transform.position, gameObject.transform.right, focusRange);
        if (focusRayHit.collider != null && focusRayHit.transform.tag == "Walls")
        {
            Debug.DrawLine(droneToolFirePoint.transform.position, focusRayHit.point, Color.red);
            focusRange = focusRayHit.distance;

        }

        droneToolFocusPoint.transform.position = droneToolFirePoint.transform.position + gameObject.transform.right * focusRange;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit2D raycastHit2D;
            raycastHit2D = Physics2D.CircleCast(droneToolFocusPoint.transform.position, forceRadius, droneToolFirePoint.transform.right);
            if (raycastHit2D.collider != null && raycastHit2D.rigidbody != null)
            {
                raycastHit2D.rigidbody.AddForce((raycastHit2D.rigidbody.transform.position -droneToolFocusPoint.transform.position).normalized * forceMultiplier);
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            RaycastHit2D raycastHit2D;
            raycastHit2D = Physics2D.CircleCast(droneToolFocusPoint.transform.position, forceRadius, droneToolFirePoint.transform.right);
            if (raycastHit2D.collider != null && raycastHit2D.rigidbody != null)
            {
                raycastHit2D.rigidbody.AddForce((raycastHit2D.rigidbody.transform.position - droneToolFocusPoint.transform.position).normalized * -forceMultiplier);
            }
        }
    }
}