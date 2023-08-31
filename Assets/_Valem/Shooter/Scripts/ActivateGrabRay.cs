using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    [SerializeField]
    private GameObject grabRay;

    [SerializeField]
    private XRDirectInteractor rightDirectGrab;

    void Update()
    {
        //solo podemos utilizar el rayo si no estamos cogiendo ya algo en la mano derecha
        grabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
    }
}
