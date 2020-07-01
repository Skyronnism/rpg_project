using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

public class ActionScheduler : MonoBehaviour
{
    IAction currentAction;

    // Start is called before the first frame update
    public void StartAction(IAction action)
    {
        if(currentAction == action) return;
        if(currentAction != null){
            currentAction.Cancel();
        }
        currentAction = action;
    
    }
}
