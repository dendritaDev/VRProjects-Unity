using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnType : MonoBehaviour
{
    [SerializeField]
    private ActionBasedSnapTurnProvider snapTurn;
    [SerializeField]
    private ActionBasedContinuousMoveProvider continuousTurn;

 
    public void SetTypeFromIndex(int index)
    {
        if(index == 0)
        {
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }
        else if(index == 1)
        {
            snapTurn.enabled = true;
            continuousTurn.enabled = false;
        }
    }
}
