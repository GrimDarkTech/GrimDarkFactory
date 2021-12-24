using System.Collections;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    bool isTimerActive = false;
    private GameObject[] prefabs;
    private float num = 0;
    [SerializeField] private float limit = 0;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private GameObject prefab3;
    private void Update()
    {
        if (isTimerActive == false)
        {
            if (limit == 0 || num < limit)
            {
                StartCoroutine(Timer(6f));
                isTimerActive = true;
                num = num + 1;
            }
        }
    }
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(prefab1, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(prefab2, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(prefab3, gameObject.transform.position, gameObject.transform.rotation);
        isTimerActive = false;
    }

}

