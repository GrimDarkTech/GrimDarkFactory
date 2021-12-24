using System.Collections;
using UnityEngine;

public class pressScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D doorR;
    [SerializeField] BoxCollider2D doorL;
    [SerializeField] GameObject dropPoint;
    [SerializeField] GameObject plateMetal;
    [SerializeField] GameObject plateCopper;
    private materialInfo oreMaterial;
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
            oreMaterial = other.gameObject.GetComponent<materialInfo>();
            Destroy(other.gameObject);
            pressAnimator.SetBool("IsWorking", true);
            StartCoroutine(pressTimer(1.5f, oreMaterial.getMaterial()));
        }
    }

    IEnumerator pressTimer(float time, string material)
    {
        yield return new WaitForSeconds(time);

        switch (material)
        {
            case "metal":
                Instantiate(plateMetal, dropPoint.transform.position, dropPoint.transform.rotation);
                break;
            case "copper":
                Instantiate(plateCopper, dropPoint.transform.position, dropPoint.transform.rotation);
                break;
        }
        pressAnimator.SetBool("IsWorking", false);
        doorR.enabled = false;
        doorL.enabled = false;
    }
}
