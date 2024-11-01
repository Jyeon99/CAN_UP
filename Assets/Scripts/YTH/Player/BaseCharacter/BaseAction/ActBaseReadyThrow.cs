using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // ��Ŭ�� ������ ��, ���콺�� ���� �ʾ��� ��
        {
            _data.IsReadyToThrow = true;
            return BTNodeState.Running;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.Mouse1) && _data.IsReadyToThrow == true)
        {
            _data.IsReadyToThrow = false;
            return BTNodeState.Failure;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}

