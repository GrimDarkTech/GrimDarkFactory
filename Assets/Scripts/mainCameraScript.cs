using UnityEngine;

public class mainCameraScript : MonoBehaviour
{
    [SerializeField] private GameObject folowTarger;
    Vector3 targerPosition;
    Vector3 folowerSmooth;
    Quaternion targerRotation;
    Quaternion folowerRotSmooth;
    public float smoothness = 0.2f;
    void FixedUpdate()
    {
        targerPosition = new Vector3(folowTarger.transform.position.x, folowTarger.transform.position.y, gameObject.transform.position.z);
        targerRotation = folowTarger.transform.rotation;
        folowerRotSmooth = Quaternion.Lerp(gameObject.transform.rotation, targerRotation, smoothness);
        folowerSmooth = Vector3.Lerp(gameObject.transform.position, targerPosition, smoothness);

        gameObject.transform.position = folowerSmooth;
        gameObject.transform.rotation = folowerRotSmooth;
    }
}
