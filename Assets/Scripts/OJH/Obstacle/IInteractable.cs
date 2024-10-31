using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    //collision
    // Player�� ���˽� �߻��ϴ� �Լ�
    void TargetInteractColEnter(PlayerController player);

    // Player�� �����߿� �߻��ϴ� �Լ�
    void TargetInteractColStay(PlayerController player);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractColExit(PlayerController player);

    //trigger
    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriEnter(PlayerController player);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriStay(PlayerController player);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriExit(PlayerController player);

    void TargetInteractColEnter(Item item);

    // Player�� �����߿� �߻��ϴ� �Լ�
    void TargetInteractColStay(Item item);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractColExit(Item item);

    //trigger
    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriEnter(Item item);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriStay(Item item);

    // Player�� ���� �� �������� �� �߻��ϴ� �Լ�
    void TargetInteractTriExit(Item item);

}
