using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space ������ �ִ� ����
        {                                                                                         
            _data.JumpPower += Time.deltaTime * 6f;  // ������ �����
            Debug.Log("������ ��¡ ��");

            if (_data.JumpPower >= _data.MaxJumpPower)  // �������� �ִ� �������� �Ѿ�� �ִ� ���������� ����                                                                                             
            {
                _data.JumpPower = _data.MaxJumpPower;
                _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
                _data.JumpPower = 0;
                return BTNodeState.Success;
            }
            return BTNodeState.Running;
        }

        if ((Input.GetKeyUp(KeyCode.Space)) &&  !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space ���ų�
        {                                                                                              // �������� �ִ� �����¿� ���� ��
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse); // ����
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
