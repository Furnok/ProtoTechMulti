using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_InputManager : MonoBehaviour
{
    [SerializeField] private RSE_PlayerMove rsePlayerMove1;
    [SerializeField] private RSE_PlayerMove rsePlayerMove2;
    [SerializeField] private RSE_PlayerJump rsePlayerJump1;
    [SerializeField] private RSE_PlayerJump rsePlayerJump2;

    private void Start()
    {
        // Delay to ensure controllers are detected before joining
        Invoke(nameof(AutoJoinPlayers), 0.1f);
    }

    private void AutoJoinPlayers()
    {
        var playerInputManager = GetComponent<PlayerInputManager>();

        // Get the number of connected gamepads
        int numGamepads = Gamepad.all.Count;

        // Join a player for each connected gamepad
        for (int i = 0; i < numGamepads; i++)
        {
            var playerInput =  playerInputManager.JoinPlayer(i, -1, null, Gamepad.all[i]);

            PlayerInput player = playerInput.GetComponent<PlayerInput>();

            InputActionAsset actionAsset = player.actions;

            InputActionMap actionMap = actionAsset.FindActionMap("Inputs");

            foreach (var action in actionMap)
            {
                if(action.name == "Movement Player")
                {
                    if(i == 0)
                    {
                        action.started += ctx => rsePlayerMove1.RaiseEvent(ctx);
                        action.performed += ctx => rsePlayerMove1.RaiseEvent(ctx);
                        action.canceled += ctx => rsePlayerMove1.RaiseEvent(ctx);
                    }

                    if (i == 1)
                    {
                        action.started += ctx => rsePlayerMove2.RaiseEvent(ctx);
                        action.performed += ctx => rsePlayerMove2.RaiseEvent(ctx);
                        action.canceled += ctx => rsePlayerMove2.RaiseEvent(ctx);
                    }
                }

                if (action.name == "Jump Player")
                {
                    if (i == 0)
                    {
                        action.started += ctx => rsePlayerJump1.RaiseEvent(ctx);
                        action.performed += ctx => rsePlayerJump1.RaiseEvent(ctx);
                        action.canceled += ctx => rsePlayerJump1.RaiseEvent(ctx);
                    }

                    if (i == 1)
                    {
                        action.started += ctx => rsePlayerJump2.RaiseEvent(ctx);
                        action.performed += ctx => rsePlayerJump2.RaiseEvent(ctx);
                        action.canceled += ctx => rsePlayerJump2.RaiseEvent(ctx);
                    }
                }
            }
        }
    }
}
