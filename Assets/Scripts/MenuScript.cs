using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Canvas quitMenu;
    public Button startButton;
    public Button quitButton;
    // Use this for initialization
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startButton.enabled = false;
        quitButton.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startButton.enabled = true;
        quitButton.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("LevelSelectMenu");
        //SceneManager.UnloadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
