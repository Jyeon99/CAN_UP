using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // ��Ŭ�� ������ ��, ���콺�� ���� �ʾ��� ��
        {
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}

