using UnityEngine;
using UnityEngine.InputSystem;

public class S_InputsManager : MonoBehaviour
{
    //[Header("Parameters")]

    //[Header("References")]

    //[Header("RSE")]

    //[Header("RSO")]

    //[Header("SSO")]

    private I_Inputs controls;
    private float val;

    private void OnEnable()
    {
        //controls.Inputs.MovementPlayer1.performed += ctx => Player1Move(ctx.ReadValue<float>);
    }

    private void OnDisable()
    {

    }

    private void Player1Move(float val)
    {
        
    }

    private void Player2Move()
    {

    }

    private void PauseMenu()
    {

    }
}