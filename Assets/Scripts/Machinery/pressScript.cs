using System.Collections;
using UnityEngine;

public class pressScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D doorR;
    [SerializeField] BoxCollider2D doorL;
    [SerializeField] GameObject dropPoint;
    [SerializeField] GameObject plate;
    Animator pressAnimator;
    void Start()
    {
        pressAnimator = gameObject.GetComponent<Animator>();
        doorR.enabled = false;
        doorL.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ingot")
        {
            doorR.enabled = true;
            doorL.enabled = true;
            Destroy(other.gameObject);
            pressAnimator.SetBool("IsWorking", true);
            StartCoroutine(pressTimer(1.5f));
        }
    }

    IEnumerator pressTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(plate, dropPoint.transform.position, dropPoint.transform.rotation);
        pressAnimator.SetBool("IsWorking", false);
        doorR.enabled = false;
        doorL.enabled = false;
    }
}
