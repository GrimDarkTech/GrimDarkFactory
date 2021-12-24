using UnityEngine;
using System.Collections;

public class refineryScript : MonoBehaviour
{
    private BoxCollider2D propCollider;
    [SerializeField] GameObject dropPoint;
    [SerializeField] GameObject ingotMetal;
    [SerializeField] GameObject ingotCopper;
    [SerializeField] GameObject ingotSilicate;
    private materialInfo oreMaterial;
    void Start()
    {
        propCollider = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ore")
        {
            oreMaterial = other.gameObject.GetComponent<materialInfo>();
            Destroy(other.gameObject);
            StartCoroutine(refineryTimer(2, oreMaterial.getMaterial()));
        }
    }

    IEnumerator refineryTimer(float time, string material)
    {
        yield return new WaitForSeconds(time);
        switch (material)
        {
            case "metal":
                Instantiate(ingotMetal, dropPoint.transform.position, dropPoint.transform.rotation);
                    break;
            case "copper":
                Instantiate(ingotCopper, dropPoint.transform.position, dropPoint.transform.rotation);
                break;
            case "silicate":
                Instantiate(ingotSilicate, dropPoint.transform.position, dropPoint.transform.rotation);
                break;
        }
    }
}
