using UnityEngine;

public class droneToolScript : MonoBehaviour
{

    private Vector3 cursorDirection = new Vector2(0, 0);
    private float focusRange = 0.64f;
    [SerializeField] private float maxFocusRange = 0.64f; //WIP

    public float rotationAngle = 0.1f;
    public GameObject droneToolFirePoint;
    
    void Update()
    {
        cursorDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotationAngle = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);

        focusRange = focusRange + Input.GetAxis("Mouse ScrollWheel");
        droneToolFirePoint.transform.position = gameObject.transform.position + droneToolFirePoint.transform.right * focusRange;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(droneToolFirePoint.transform.position, droneToolFirePoint.transform.right);
            if (hit.collider != null && hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(droneToolFirePoint.transform.right * 0.4f, hit.point);
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(droneToolFirePoint.transform.position, droneToolFirePoint.transform.right);
            if (hit.collider != null && hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(droneToolFirePoint.transform.right * -0.4f, hit.point);
            }
        }
    }
}