using Sirenix.OdinInspector;
using System.Collections;
using TMPro;
using UnityEngine;

public class S_UIGame : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private TextMeshProUGUI textScoreP1;
    [SerializeField] private TextMeshProUGUI textScoreP2;
    [SerializeField] private TextMeshProUGUI textTime;

    [Title("RSE")]
    [SerializeField] private RSE_UpdateUI rseUpdateUI;
    [SerializeField] private RSE_StartTime rseStartTime;

    [Title("RSO")]
    [SerializeField] private RSO_CurrentScore rsoCurrentScoreP1;
    [SerializeField] private RSO_CurrentScore rsoCurrentScoreP2;
    [SerializeField] private RSO_CurrentTime rsoCurrentTime;

    [Title("SSO")]
    [SerializeField] private SSO_Time ssoTime;

    private void Start()
    {
        rsoCurrentTime.Value = ssoTime.Value;

        UpdateUITime();
    }

    private void OnEnable()
    {
        rseUpdateUI.action += UpdateUIScore;
        rseStartTime.action += StartTime;
    }

    private void OnDisable()
    {
        rseUpdateUI.action -= UpdateUIScore;
        rseStartTime.action -= StartTime;
    }

    private void UpdateUIScore()
    {
        textScoreP1.text = rsoCurrentScoreP1.Value.ToString("00");
        textScoreP2.text = rsoCurrentScoreP2.Value.ToString("00");
    }

    private void UpdateUITime()
    {
        int minutes = rsoCurrentTime.Value / 60;
        int seconds = rsoCurrentTime.Value % 60;

        textTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator Time()
    {
        yield return new WaitForSeconds(1);

        rsoCurrentTime.Value = Mathf.Clamp(rsoCurrentTime.Value + 1, 0, 3600);
        
        UpdateUITime();

        StartCoroutine(Time());
    }

    private void StartTime()
    {
        StartCoroutine(Time());
    }
}