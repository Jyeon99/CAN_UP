using UnityEngine;

public class ActBaseReadyThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // ��Ŭ�� ������ ��, ���콺�� ���� �ʾ��� ��
        {
            Debug.Log("������ ��� ���� + ������ ���� Ȯ�� + ������ ���� �غ� �Ϸ�");
            return BTNodeState.Running;
        }
        else
        {
            Debug.Log("������ ��� ���� + ������ ���� Ȯ�� + ������ ���� �غ� ��XXXXX");
            return BTNodeState.Failure;
        }
    }
}

