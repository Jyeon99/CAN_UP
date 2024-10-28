using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    // Player�� ���˽� �߻��ϴ� �Լ�
    void TargetInteractEnter(PlayerController player);

    // Player�� �����߿� �߻��ϴ� �Լ�
    void TargetInteractStay(PlayerController player);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractExit(PlayerController player);
}
