using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // ��Ŭ�� ������ ��, ���콺�� ���� �ʾ��� ��
        {
           // if (Input.GetKey(KeyCode.Mouse0) == true)
           // {
           //     return BTNodeState.Running;
           // }
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }
}
