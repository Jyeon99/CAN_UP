using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : PlayerAction
{
    public override BTNodeState DoAction()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space))
        {
            Debug.Log("�̵���");
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
