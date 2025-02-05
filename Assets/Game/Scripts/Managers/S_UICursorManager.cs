using UnityEngine;

public class S_UICursorManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Texture2D handCursor;

    [Header("RSE")]
    [SerializeField] private RSE_CursorDefault rseCursorDefault;
    [SerializeField] private RSE_CursorHand rseCursorHand;

    private void OnEnable()
    {
        rseCursorDefault.action += OnCursorEndHover;
        rseCursorHand.action += OnCursorStartHover;
    }

    private void OnDisable()
    {
        rseCursorDefault.action -= OnCursorEndHover;
        rseCursorHand.action -= OnCursorStartHover;

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnCursorStartHover()
    {
        Vector2 cursorOffset = new Vector2(handCursor.width / 3, handCursor.height / 40);

        Cursor.SetCursor(handCursor, cursorOffset, CursorMode.Auto);
    }

    private void OnCursorEndHover()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}