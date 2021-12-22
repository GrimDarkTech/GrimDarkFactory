using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cameraKeysScript : MonoBehaviour
{
    [SerializeField] private Button goToMenuButton;
    public void exitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Start()
    {
        goToMenuButton.enabled = false;
        goToMenuButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            goToMenuButton.gameObject.SetActive(Cursor.visible);
            goToMenuButton.enabled = !goToMenuButton.enabled;
        } 
    }
}
