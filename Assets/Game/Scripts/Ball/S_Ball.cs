using Sirenix.OdinInspector;
using UnityEngine;

public class S_Ball : MonoBehaviour
{
    [Title("Parameters")]
    [SerializeField] private TagsName tagPlayer;
    [SerializeField] private float gravityScale;

    [Title("References")]
    [SerializeField] private Rigidbody2D rb;

    [Title("RSE")]
    [SerializeField] private RSE_ResetBall rseResetBall;

    [Title("RSO")]
    [SerializeField] private RSO_CurrentBallPos rsoCurrentBallPos;

    private void Start()
    {
        rsoCurrentBallPos.Value = transform.position;
    }

    private void OnEnable()
    {
        rseResetBall.action += ResetBallPos;
    }

    private void OnDisable()
    {
        rseResetBall.action += ResetBallPos;
    }

    private void Update()
    {
        rsoCurrentBallPos.Value = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(tagPlayer.ToString()) && rb.gravityScale <= 0)
        {
            rb.gravityScale = gravityScale;
        }
    }

    private void ResetBallPos(Vector2 pos)
    {
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        transform.position = pos;
    }
}