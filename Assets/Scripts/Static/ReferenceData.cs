using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceData : MonoBehaviour
{
    public static Dictionary<string, GameObject> references = new Dictionary<string, GameObject> ();

    [SerializeField] private GameObject[] prefabs = new GameObject[25];
    private void Start()
    {
        references.Add("metalIngot", prefabs[0]);
        references.Add("metalPlate", prefabs[1]);
        references.Add("copperPlate", prefabs[2]);
        references.Add("copperIngot", prefabs[3]);
        references.Add("silicateIngot", prefabs[4]);
        //ores
        references.Add("metalScrap1", prefabs[5]);
        references.Add("metalScrap2", prefabs[6]);
        references.Add("metalScrap3", prefabs[7]);
        references.Add("copperScrap", prefabs[8]);
        references.Add("copperScrap2", prefabs[9]);
        references.Add("copperScrap3", prefabs[10]);
        references.Add("silicateScrap", prefabs[11]);
        references.Add("silicateScrap2", prefabs[12]);
        references.Add("silicateScrap3", prefabs[13]);
    }
}
