using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActBasePickItem : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // ��Ŭ�� �Է� ��
        {
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
