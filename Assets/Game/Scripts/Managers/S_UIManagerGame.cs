using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class S_UIManagerGame : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelEnd;
    [SerializeField] private TextMeshProUGUI textWin;
    [SerializeField] private TextMeshProUGUI textLose;
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonRestart;

    [Title("RSE")]
    [SerializeField] private RSE_PauseMenu rsePauseMenu;
    [SerializeField] private RSE_UnPauseMenu rseUnPauseMenu;
    [SerializeField] private RSE_Win rseWin;

    private bool isPaused;

    private void OnEnable()
    {
        rsePauseMenu.action += CallPause;
        rseUnPauseMenu.action += UnPauseGame;
        rseWin.action += Win;

        Cursor.visible = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void OnDisable()
    {
        rsePauseMenu.action -= CallPause;
        rseUnPauseMenu.action -= UnPauseGame;
        rseWin.action -= Win;
    }

    private void CallPause()
    {
        if(!panelEnd.activeInHierarchy)
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
    }

    private void PauseGame()
    {
        isPaused = true;
        Cursor.visible = true;
        //buttonResume.Select();

        panelPause.SetActive(true);

        Time.timeScale = 0.0f;
    }

    private void UnPauseGame()
    {
        isPaused = false;
        Cursor.visible = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        EventSystem.current.SetSelectedGameObject(null);

        panelPause.SetActive(false);

        Time.timeScale = 1.0f;
    }

    private void Win(bool val)
    {
        //buttonRestart.Select();

        if (val)
        {
            textWin.text = "Player 1: Win";
            textLose.text = "Player 2: Lose";
        }
        else
        {
            textWin.text = "Player 2: Win";
            textLose.text = "Player 1: Lose";
        }

        panelEnd.SetActive(true);

        Time.timeScale = 0.0f;
    }
}