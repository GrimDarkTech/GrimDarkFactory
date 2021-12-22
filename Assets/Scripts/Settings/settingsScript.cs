using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class settingsScript : MonoBehaviour
{
    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void goBack()
    {
        SceneManager.LoadScene("MainMenu"); //this is fine
    }
}
