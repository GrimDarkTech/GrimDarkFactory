using UnityEngine;
using UnityEngine.UI;

public class cameraKeysScript : MonoBehaviour
{
    public void exitGame()
    {
    Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Cursor.visible = !Cursor.visible;
    }
}
