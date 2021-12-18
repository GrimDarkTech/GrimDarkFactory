using UnityEngine;

public class toolMode2Script : MonoBehaviour
{

    private Vector3 cursorPosition = new Vector2(0, 0);
    private Vector3 cursorDirection = new Vector2(0, 0);

    private float focusRange = 0.64f;
    [SerializeField] private float maxFocusRange = 0.64f;
    [SerializeField] private float minFocusRange = 0.16f;

    public float rotationAngle = 0.1f;
    public GameObject droneToolFirePoint;
    public GameObject droneToolFocusPoint;

    void Update()
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
        if (focusRayHit.collider != null)
        {
            Debug.DrawLine(droneToolFirePoint.transform.position, focusRayHit.point, Color.red);
            focusRange = focusRayHit.distance;
        }

        droneToolFocusPoint.transform.position = droneToolFirePoint.transform.position + gameObject.transform.right * focusRange;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(droneToolFirePoint.transform.position, droneToolFirePoint.transform.right);
            if (hit.collider != null && hit.rigidbody != null)
            {
                Debug.DrawLine(droneToolFocusPoint.transform.position, hit.transform.position, Color.green);
                hit.rigidbody.AddForce(droneToolFirePoint.transform.right * 1.5f);
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(droneToolFocusPoint.transform.position, droneToolFirePoint.transform.right);
            if (hit.collider != null && hit.rigidbody != null)
            {
                Debug.DrawLine(droneToolFocusPoint.transform.position, hit.transform.position, Color.blue);
                hit.rigidbody.AddForce(droneToolFocusPoint.transform.right * -1.5f);
            }
        }
    }
}