using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;

    // ���� ���� �ð� 0.2��
    private float _jumpCooldown = 0.0f;

    // ���� �������ڸ��� ���� �� �� �ֵ���, -1�� �ʱⰪ���� ����
    private float _groundedTime = -1f;

    // JumperData, Rigidbody ��������
    private void Start()
    {
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();
    }

    // DoAction ������
    public override BTNodeState DoAction()
    {
        // ���� �ð� = ���� ����ִ� �ð� + ��Ÿ�Ӻ��� �� �� Ȯ��
        if (_jumperData._isGrounded && Time.time >= _groundedTime + _jumpCooldown)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
            _jumperData._isGrounded = false; // ���� ���Ŀ� ���� ���� ���� ���·� ����
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    // ���� ����ִ� �����Ӹ��� _isGrounded = true -> ���� ����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumperData._isGrounded = true;
            _groundedTime = Time.time;
        }
    }
}
