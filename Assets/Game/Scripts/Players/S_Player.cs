using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Player : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask wallLayer;

    [Title("RSE")]
    [SerializeField] private RSE_PlayerMove rsePlayerMove;
    [SerializeField] private RSE_PlayerJump rsePlayerJump;

    [Title("SSO")]
    [SerializeField] private SSO_PlayerSpeed ssoPlayerSpeed;
    [SerializeField] private SSO_JumpForce ssoJumpForce;

    private bool isMoving;

    private void OnEnable()
    {
        rsePlayerMove.action += PlayerMove;
        rsePlayerJump.action += PlayerJump;

    }

    private void OnDisable()
    {
        rsePlayerMove.action -= PlayerMove;
        rsePlayerJump.action -= PlayerJump;

    }

    private void CheckWall(float moveDirection)
    {
        Vector2 direction = new Vector2(moveDirection, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, (sr.size.x / 2) + 0.01f, wallLayer);

        if (hit.collider != null)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    private IEnumerator Move(float value)
    {
        while (isMoving)
        {
            CheckWall(value);

            if(isMoving)
            {
                rb.velocity = new Vector2(value * ssoPlayerSpeed.Value, rb.velocity.y);
            }

            yield return null;
        }

        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private void PlayerMove(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            isMoving = true;

            StartCoroutine(Move(ctx.ReadValue<float>()));
        }
        else if (ctx.canceled)
        {
            isMoving = false;

            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void PlayerJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            rb.AddForce(rb.velocity + Vector2.up * ssoJumpForce.Value, ForceMode2D.Impulse);
        }
    }
}