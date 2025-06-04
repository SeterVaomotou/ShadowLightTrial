using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject instructionsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Trial_1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void ShowInstructions()
    {
        menuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        instructionsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
