using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // Load Character Select scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Character Select");
    }

    public void Quit()
    {
        // Quit the game
        Application.Quit();
    }
}
