using UnityEngine;

public class containerScript : MonoBehaviour
{
    [SerializeField] private GameObject content;

    public GameObject get—ontent()
    {
        return content;
    }
    public void set—ontent(GameObject settingMaterial)
    {
        content = settingMaterial;
    }
}
