using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class S_BallLocation : MonoBehaviour
{
    [Title("Parameters")]
    [SerializeField] private float timeClip;

    [Title("References")]
    [SerializeField] private SpriteRenderer sr;

    [Title("RSO")]
    [SerializeField] private RSO_CurrentBallPos rsoCurrentBallPos;

    private void OnEnable()
    {
        rsoCurrentBallPos.onValueChanged += UpdatePos;
    }

    private void OnDisable()
    {
        rsoCurrentBallPos.onValueChanged -= UpdatePos;
    }

    private IEnumerator Clip()
    {
        while(true)
        {
            sr.color = Color.white;

            yield return new WaitForSeconds(timeClip);

            sr.color = Color.black;

            yield return new WaitForSeconds(timeClip);
        }
    }

    private void Start()
    {
        StartCoroutine(Clip());
    }

    private void UpdatePos(Vector2 pos)
    {
        transform.position = new Vector2(rsoCurrentBallPos.Value.x, transform.position.y);
    }
}