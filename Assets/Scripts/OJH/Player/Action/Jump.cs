using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerAction
{
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("����!");
            return BTNodeState.Running;
        }
        else
        {
            Debug.Log("������ 0���� ����");
            return BTNodeState.Failure;
        }
    }
}
