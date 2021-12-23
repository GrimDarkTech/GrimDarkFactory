using System.Collections;
using UnityEngine;

public class packerScript : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    [SerializeField] private GameObject box;

    private containerScript boxContent;
    private GameObject boxPlaced;
    private prefabInfo packedPrefabInfo;

    public bool IsPacker = true;
    void Start()
    {
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPacker)
        {
            switch (other.tag)
            {
                case "Material":
                    boxPlaced = Instantiate(box, gameObject.transform.position, gameObject.transform.rotation);
                    boxContent = boxPlaced.GetComponent<containerScript>();
                    packedPrefabInfo = other.gameObject.GetComponent<prefabInfo>();
                    Debug.Log(packedPrefabInfo.getPrefab().name);
                    boxContent.set—ontent(packedPrefabInfo.getPrefab());
                    Destroy(other.gameObject);
                    break;
            }
        }
        else
        {
            switch (other.tag)
            {
                case "Box":
                    boxContent = other.gameObject.GetComponent<containerScript>();
                    Instantiate(boxContent.get—ontent(), gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(other.gameObject);
                    break;
            }
        }

    }
}
