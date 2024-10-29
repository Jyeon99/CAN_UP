using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    

    public override BTNodeState DoAction()
    {
        Vector3 _jumpDirection = new Vector3(1,2,0).normalized;

        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space ������ �ִ� ����
        {                                                                                         
            _data.JumpPower += Time.deltaTime * 6f;  // ������ �����
            Debug.Log("������ ��¡ ��");

            if (_data.JumpPower >= _data.MaxJumpPower)  // �������� �ִ� �������� �Ѿ�� �ִ� ���������� ����                                                                                             
            {
                _data.JumpPower = _data.MaxJumpPower;
                _rigidbody.AddForce(_jumpDirection * _data.JumpPower, ForceMode.Impulse);
                _data.IsGrounded = false;
                _animator.SetTrigger("Jump");
                _data.JumpPower = 0;
                return BTNodeState.Success;
            }
            return BTNodeState.Running;
        }

        if ((Input.GetKeyUp(KeyCode.Space)) &&  !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space ���ų�
        {                                                                                              // �������� �ִ� �����¿� ���� ��
            _rigidbody.AddForce(_jumpDirection * _data.JumpPower, ForceMode.Impulse); // ����
            _animator.SetTrigger("Jump");
            Debug.Log("����!");

            _data.IsGrounded = false;
            _data.JumpPower = 0;
            return BTNodeState.Success;
        }

        else
        {
            return BTNodeState.Failure;
        }
    }
}
