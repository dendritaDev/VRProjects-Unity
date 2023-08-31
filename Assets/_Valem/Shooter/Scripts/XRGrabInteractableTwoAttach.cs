using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    [SerializeField]
    private Transform leftAttachTransform;

    [SerializeField]
    private Transform rightAttachTransform;

    /// <summary>
    /// Esto lo hacemos para que cuando cambiemos un objeto de una mano a otra se adapte la posicion segun el controller sea left o right
    /// Actualmente esto ya esta implelmetnado por unity en el Xr Interaction Toolkit. 
    /// Solo tengo que ir al XR Grab Interactable y marcar como true la casilla de use Dynamic Attach
    /// </summary>
    /// <param name="args"></param>
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftAttachTransform;
        }
        else if(args.interactableObject.transform.CompareTag("Right Hand"))
        {
            attachTransform = rightAttachTransform;

        }

        base.OnSelectEntered(args);
    }
}
