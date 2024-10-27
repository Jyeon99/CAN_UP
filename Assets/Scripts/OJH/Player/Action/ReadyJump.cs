using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyJump : PlayerAction
{
   
    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("������ ��¡ ��");
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
    
}
