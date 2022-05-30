using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Tooltip("Sensitivity multiplier for moving the camera around")]
    public float LookSensitivity = 1f;
    [Tooltip("Limit to consider an input when using a trigger on a controller")]
    public float TriggerAxisThreshold = 0.4f;

    bool m_FireInputWasHeld;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public float GetLookInputsHorizontal()
    {
        return GetMouseOrStickLookAxis(GameConstants.k_MouseAxisNameHorizontal);
    }

    public float GetLookInputsVertical()
    {
        return GetMouseOrStickLookAxis(GameConstants.k_MouseAxisNameVertical);
    }

    public bool CanProcessInput()
    {
        return Cursor.lockState == CursorLockMode.Locked;
    }

    float GetMouseOrStickLookAxis(string mouseInputName)
    {
        if (CanProcessInput())
        {
            float i = Input.GetAxisRaw(mouseInputName);

            // apply sensitivity multiplier
            i *= LookSensitivity;


            // reduce mouse input amount to be equivalent to stick movement
            i *= 0.01f;
#if UNITY_WEBGL
            // Mouse tends to be even more sensitive in WebGL due to mouse acceleration, so reduce it even more
            i *= webglLookSensitivityMultiplier;
#endif
            return i;
        }

        return 0f;
    }

    public bool GetFireInput()
    {
        if (CanProcessInput())
        {
            return Input.GetButton(GameConstants.k_ButtonNameFire);
        }

        return false;
    }
    
    public bool GetAlternativeFireInput()
    {
        if (CanProcessInput())
        {
            return Input.GetButton(GameConstants.k_ButtonNameAlternativeFire);
        }

        return false;
    }
}
