using Sirenix.OdinInspector;
using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    [Title("RSE")]
    [SerializeField] private RSE_Goal rseGoalP1;
    [SerializeField] private RSE_Goal rseGoalP2;
    [SerializeField] private RSE_ResetBall rseResetBall;
    [SerializeField] private RSE_UpdateUI rseUpdateUI;
    [SerializeField] private RSE_StartTime rseStartTime;

    [Title("RSO")]
    [SerializeField] private RSO_CurrentScore rsoCurrentScoreP1;
    [SerializeField] private RSO_CurrentScore rsoCurrentScoreP2;

    [Title("SSO")]
    [SerializeField] private SSO_ScoreGain ssoScoreGain;
    [SerializeField] private SSO_Score ssoScoreP1;
    [SerializeField] private SSO_Score ssoScoreP2;
    [SerializeField] private SSO_ScoreWin ssoScoreWin;
    [SerializeField] private SSO_BallPos ssoBallPosP1;
    [SerializeField] private SSO_BallPos ssoBallPosP2;

    private void Start()
    {
        rsoCurrentScoreP1.Value = ssoScoreP1.Value;
        rsoCurrentScoreP2.Value = ssoScoreP2.Value;

        rseUpdateUI?.RaiseEvent();
        rseStartTime?.RaiseEvent();
    }

    private void OnEnable()
    {
        rseGoalP1.action += GoalP1;
        rseGoalP2.action += GoalP2;
    }

    private void OnDisable()
    {
        rseGoalP1.action -= GoalP1;
        rseGoalP2.action -= GoalP2;
    }

    private void GoalP1()
    {
        rseResetBall?.RaiseEvent(ssoBallPosP2.Value);

        rsoCurrentScoreP2.Value = Mathf.Clamp(rsoCurrentScoreP2.Value + ssoScoreGain.Value, 0, ssoScoreWin.Value);

        CheckWin();
    }

    private void GoalP2()
    {
        rseResetBall?.RaiseEvent(ssoBallPosP1.Value);

        rsoCurrentScoreP1.Value = Mathf.Clamp(rsoCurrentScoreP1.Value + ssoScoreGain.Value, 0, ssoScoreWin.Value);

        CheckWin();
    }

    private void CheckWin()
    {
        rseUpdateUI?.RaiseEvent();
    }
}