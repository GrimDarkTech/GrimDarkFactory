using UnityEngine;


public class prefabInfo : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public GameObject getPrefab()
    {
        return prefab;
    }
}
