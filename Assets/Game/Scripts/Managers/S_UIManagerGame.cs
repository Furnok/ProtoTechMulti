using Sirenix.OdinInspector;
using UnityEngine;

public class S_UIManagerGame : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelEnd;

    [Title("RSE")]
    [SerializeField] private RSE_PauseMenu rsePauseMenu;
    [SerializeField] private RSE_Win rseWin;

    [Title("TEMP")]
    [SerializeField] private ScenesName sceneName;

    private bool isPaused;

    private void OnEnable()
    {
        rsePauseMenu.action += CallPause;
        rseWin.action += Win;

        Cursor.visible = false;
    }

    private void OnDisable()
    {
        rsePauseMenu.action -= CallPause;
        rseWin.action -= Win;
    }

    private void CallPause()
    {
        if (isPaused)
        {
            UnPauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Cursor.visible = true;

        panelPause.SetActive(true);

        Time.timeScale = 0.0f;
    }

    private void UnPauseGame()
    {
        isPaused = false;
        Cursor.visible = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        panelPause.SetActive(false);

        Time.timeScale = 1.0f;
    }

    private void Win()
    {
        panelPause.SetActive(true);
    }
}