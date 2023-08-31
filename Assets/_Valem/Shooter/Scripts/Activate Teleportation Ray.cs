using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField]
    private GameObject leftTeleportation;

    [SerializeField]
    private GameObject rightTeleportation;

    [SerializeField]
    private InputActionProperty leftActivate;

    [SerializeField]
    private InputActionProperty rightActivate;

    [SerializeField]
    private InputActionProperty leftCancel;
    [SerializeField]
    private InputActionProperty rightCancel;

    [SerializeField]
    private XRRayInteractor leftRay;

    [SerializeField]
    private XRRayInteractor rightRay;

    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        
        //Mientras el boton de seleccionado no este siendo pulsado o el rayo no este haciendo hovering con otra cosa como objeto o UI, si pulsamos el de activate, aparecen los rayos de teleporte
        leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>()== 0 && leftActivate.action.ReadValue<float>() > 0.1f);

        bool isRightRayHovering = leftRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        rightTeleportation.SetActive(!isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
