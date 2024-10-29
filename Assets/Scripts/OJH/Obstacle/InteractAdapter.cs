using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Player�� ��ȣ�ۿ��� ��� �ν�����â�� adapter ������ �ν�����â���� event���ٰ� �Լ� ����.
public class InteractAdapter : MonoBehaviour, IInteractable
{
    // �̺�Ʈ�� �̿��� ��� ���
    public UnityEvent<PlayerController> OnInteractColEnter;

    public UnityEvent<PlayerController> OnInteractColStay;

    public UnityEvent<PlayerController> OnInteractColExit;

    public UnityEvent<PlayerController> OnInteractTriEnter;

    public UnityEvent<PlayerController> OnInteractTriStay;

    public UnityEvent<PlayerController> OnInteractTriExit;

    public void TargetInteractColEnter(PlayerController player)
    {
        OnInteractColEnter?.Invoke(player);
    }

    public void TargetInteractColStay(PlayerController player)
    {
        OnInteractColStay?.Invoke(player);
    }

    public void TargetInteractColExit(PlayerController player)
    {
        OnInteractColExit?.Invoke(player);
    }

    public void TargetInteractTriEnter(PlayerController player)
    {
        OnInteractTriEnter?.Invoke(player);
    }

    public void TargetInteractTriStay(PlayerController player)
    {
        OnInteractTriStay?.Invoke(player);
    }

    public void TargetInteractTriExit(PlayerController player)
    {
        OnInteractTriExit?.Invoke(player);
    }

}