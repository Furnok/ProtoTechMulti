using Sirenix.OdinInspector;
using UnityEngine;

public class S_Ball : MonoBehaviour
{
    [Title("RSO")]
    [SerializeField] private RSO_CurrentBallPos rsoCurrentBallPos;

    private void Update()
    {
        rsoCurrentBallPos.Value = transform.position;
    }
}