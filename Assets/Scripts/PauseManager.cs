using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    Actions actions;
    public static bool GameIsPaused = false;
    [SerializeField] GameObject pausemenuUI, crossKurawaHair;
    private void Awake()
    {
        pausemenuUI.SetActive(false);
    }
    private void OnEnable()
    {
        actions = new Actions();
        actions.UI.Enable();
        pausemenuUI.SetActive(false);
        actions.UI.Pause.performed += PauseMenu;
    }
    private void OnDisable()
    {
        actions.UI.Disable();
    }

    void PauseMenu(InputAction.CallbackContext context)
    {

        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Unpause()
    {
        Resume();
    }
    public void Resume()
    {
        pausemenuUI.SetActive(false);
        crossKurawaHair.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pausemenuUI.SetActive(true);
        crossKurawaHair.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadScene(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
            Resume();
        }
    }
    public void QuitGame()
    {
        Debug.Log("Application.Quit()");
        Application.Quit();
    }
}