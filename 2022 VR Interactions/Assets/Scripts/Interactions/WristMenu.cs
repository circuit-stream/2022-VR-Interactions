using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Press menu, opens menu, click button
/// </summary>
public class WristMenu : MonoBehaviour
{
    public GameObject locomotionUI;
    public GameObject paintUI;
    public InputActionReference locomotionToggleReference = null;
    public InputActionReference paintSelectionToggleReference = null;

    private bool locomotionActive = false;
    private bool paintSelectionActive = false;

    void Start()
    {
        locomotionToggleReference.action.performed += PrimaryButtonPressed;
        paintSelectionToggleReference.action.performed += SecondaryButtonPressed;
    }
    private void OnDestroy()
    {
        locomotionToggleReference.action.performed -= PrimaryButtonPressed;
        paintSelectionToggleReference.action.performed += SecondaryButtonPressed;
    }

    /// <summary>
    /// Wrapper
    /// </summary>
    /// <param name="context"></param>
    public void PrimaryButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayLocomotionUI();
        }
    }

    public void SecondaryButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayPaintUI();
        }
    }
    
    public void DisplayLocomotionUI()
    {
        locomotionActive = !locomotionActive;
        locomotionUI.SetActive(locomotionActive);
    }

    public void DisplayPaintUI()
    {
        locomotionActive = !locomotionActive;
        paintUI.SetActive(locomotionActive);
    }
}
