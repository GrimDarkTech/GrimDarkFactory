using UnityEngine;

public class materialInfo : MonoBehaviour
{
    [SerializeField] private string material;

    public string getMaterial()
    {
        return material;
    }
}
