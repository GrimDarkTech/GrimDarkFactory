
using UnityEngine;

public class destructionZoneScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        Destroy(collision.gameObject);
    }
}
