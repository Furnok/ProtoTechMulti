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
    [SerializeField] private SSO_JumpReloadTime ssoJumpReloadTime;

    private bool isMoving = false;
    private bool canJump = true;

    private Coroutine coroutine;

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
        if (ctx.performed)
        {
            isMoving = true;

            if(coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            coroutine = StartCoroutine(Move(ctx.ReadValue<float>()));
        }
        else if (ctx.canceled)
        {
            isMoving = false;

            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private IEnumerator JumpReload()
    {
        canJump = false;

        yield return new WaitForSeconds(ssoJumpReloadTime.Value);

        canJump = true;
    }

    private void PlayerJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && canJump)
        {
            rb.AddForce(rb.velocity + Vector2.up * ssoJumpForce.Value, ForceMode2D.Impulse);

            StartCoroutine(JumpReload());
        }
    }
}