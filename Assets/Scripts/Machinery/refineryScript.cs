using UnityEngine;
using System.Collections;

public class refineryScript : MonoBehaviour
{
    private BoxCollider2D propCollider;
    [SerializeField] GameObject dropPoint;
    [SerializeField] GameObject ingot;
    void Start()
    {
        propCollider = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ore")
        {
            Destroy(other.gameObject);
            StartCoroutine(refineryTimer(2));
        }
    }

    IEnumerator refineryTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(ingot, dropPoint.transform.position, dropPoint.transform.rotation);
    }
}
