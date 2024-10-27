using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Player�� ��ȣ�ۿ��� ��� �ν�����â�� adapter ������ �ν�����â���� event���ٰ� �Լ� ����.
public class InteractAdapter : MonoBehaviour, IInteractable
{
    // �̺�Ʈ�� �̿��� ��� ���
    public UnityEvent<PlayerController> OnInteractEnter;

    public UnityEvent<PlayerController> OnInteractStay;

    public UnityEvent<PlayerController> OnInteractExit;

    public void TargetInteractEnter(PlayerController player)
    {
        OnInteractEnter?.Invoke(player);
    }

    public void TargetInteractStay(PlayerController player)
    {
        OnInteractStay?.Invoke(player);
    }

    public void TargetInteractExit(PlayerController player)
    {
        OnInteractExit?.Invoke(player);
    }

}