using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEventFactory : MonoBehaviour
{
    // Start is called before the first frame update
    private static ButtonEventFactory instance;
   
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public static ButtonEventFactory GetInstance() {

        if (instance == null) {

            GameObject gameObject = new GameObject();

            gameObject.AddComponent<ButtonEventFactory>();

            DontDestroyOnLoad (gameObject);

            instance = gameObject.GetComponent<ButtonEventFactory>();
        }

        return instance;
    }

    public void ChangeScene(int nextScene) { 
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }

    public void PauseGame(GameObject pauseMenu) { 
        Time.timeScale = 0f;
        if (pauseMenu != null) { pauseMenu.SetActive(true); }
    }

    public void ResumeGame(GameObject pauseMenu)
    {
        Time.timeScale = 1f;
        if (pauseMenu != null) { pauseMenu.SetActive(false); }
    }

    public void QuitGame() { 
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
