using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_UIMainButtons : MonoBehaviour
{
    [Title("Parameters")]
    [SerializeField] private ScenesName sceneStart;
    [SerializeField] private ScenesName sceneRestart;
    [SerializeField] private ScenesName sceneMenu;

    [Title("RSE")]
    [SerializeField] private RSE_Start rseStart;
    [SerializeField] private RSE_Restart rseRestart;
    [SerializeField] private RSE_MainMenu rseMainMenu;
    [SerializeField] private RSE_Quit rseQuit;

    private void OnEnable()
    {
        rseStart.action += StartGame;
        rseRestart.action += RestartGame;
        rseMainMenu.action += MainMenu;
        rseQuit.action += QuitGame;
    }

    private void OnDisable()
    {
        rseStart.action -= StartGame;
        rseRestart.action -= RestartGame;
        rseMainMenu.action -= MainMenu;
        rseQuit.action -= QuitGame;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(sceneStart.ToString());
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(sceneRestart.ToString());
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(sceneMenu.ToString());
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}