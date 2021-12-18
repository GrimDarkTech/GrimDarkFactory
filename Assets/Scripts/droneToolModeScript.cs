using UnityEngine;

public class droneToolModeScript : MonoBehaviour
{
    private toolMode1Script _toolMode1Script;
    private toolMode2Script _toolMode2Script;

    [SerializeField] private float mouseScrollValue = 1;
    private int toolId = 0;
    private int toolNumber = 2;

    void Start()
    {
        _toolMode1Script = gameObject.GetComponent<toolMode1Script>();
        _toolMode2Script = gameObject.GetComponent<toolMode2Script>();
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
                break;
            case 1:
                _toolMode1Script.enabled = false;
                _toolMode2Script.enabled = true;
                break;
        }
    }

}
