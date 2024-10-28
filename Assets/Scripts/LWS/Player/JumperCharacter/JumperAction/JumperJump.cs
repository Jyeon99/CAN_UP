using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;
    
    // ���� ����ִ��� �Ǵ��� Grounded �� ����
    private bool _isGrounded;

    // DoAction ������
    public override BTNodeState DoAction()
    {
        // JumperData, Rigidbody ��������
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();

        // ���� ���� ������ ���� ����
        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
        }
        return BTNodeState.Running;
    }

    // ���� ����ִ� �����Ӹ��� _isGrounded = true -> ���� ����
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
