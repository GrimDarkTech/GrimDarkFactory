using UnityEngine;

public class droneToolModeScript : MonoBehaviour
{
    private toolMode1Script _toolMode1Script;
    private toolMode2Script _toolMode2Script;
    private toolMode3Script _toolMode3Script;

    [SerializeField] private float mouseScrollValue = 1;
    private int toolId = 0;
    private int toolNumber = 3;

    void Start()
    {
        _toolMode1Script = gameObject.GetComponent<toolMode1Script>();
        _toolMode2Script = gameObject.GetComponent<toolMode2Script>();
        _toolMode3Script = gameObject.GetComponent<toolMode3Script>();
    }
    void Update()
    {
        mouseScrollValue = mouseScrollValue +  Input.GetAxis("Mouse ScrollWheel")*10;
        toolId = Mathf.Abs(Mathf.FloorToInt(mouseScrollValue));
        toolId = toolId % (toolNumber);
        switch (toolId)
        {
            case 0:
                _toolMode1Script.enabled = true;
                _toolMode2Script.enabled = false;
                _toolMode3Script.enabled = false;
                break;
            case 1:
                _toolMode1Script.enabled = false;
                _toolMode2Script.enabled = true;
                _toolMode3Script.enabled = false;
                break;
            case 2:
                _toolMode1Script.enabled = false;
                _toolMode2Script.enabled = false;
                _toolMode3Script.enabled = true;
                break;
        }
    }

}
