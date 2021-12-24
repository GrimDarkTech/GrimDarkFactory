using System.Collections;
using UnityEngine;


public class prefabInfo : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private string prefabName;
    public GameObject getPrefab()
    {
        return prefab;
    }
    private void Start()
    {
        prefab = ReferenceData.references[prefabName];
    }
}
