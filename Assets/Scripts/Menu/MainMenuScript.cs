using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void startGame() 
    {
        SceneManager.LoadScene("Level");
    }
    public void openSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
