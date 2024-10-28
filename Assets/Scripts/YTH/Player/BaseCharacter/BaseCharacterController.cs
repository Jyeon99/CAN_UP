using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody[] _rigidbodies;

    [SerializeField] Animator _animator;

    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody _rigid in _rigidbodies)
        {
            _rigid.isKinematic = true;
        }
    }

    public void TakeDamage()
    {
        //���� Ȱ��ȭ�ϱ� ����
        //1. �� ������ �������� �߷��� ���� �� �ֵ��� ����
        foreach (Rigidbody _rigid in _rigidbodies)
        {
            _rigid.isKinematic = false;
        }
        //2. �ִϸ����͸� ����
        _animator.enabled = false;

    }
}
