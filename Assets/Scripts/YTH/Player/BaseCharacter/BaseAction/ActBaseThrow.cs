using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseThrow : PlayerAction
{
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) == null) // ��Ŭ�� ����, ��Ŭ�� ���� ���°� �ƴ� ��
            {
                return BTNodeState.Success;
            }
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
