using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResetObject
{
        // �������� ��ȣ�� ��Ÿ���� �Ӽ�
        int StageNum { get; }

        // ������Ʈ�� �����ϴ� �޼���
        void Reset();
}