using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;

    // ���� ����ִ��� �Ǵ��� Grounded �� ����
    private bool _isGrounded;

    // ���� ���� �ð� 0.2��
    private float _jumpCooldown = 0.2f;

    // ���� �������ڸ��� ���� �� �� �ֵ���, -1�� �ʱⰪ���� ����
    private float _groundedTime = -1f;

    // DoAction ������
    public override BTNodeState DoAction()
    {
        // JumperData, Rigidbody ��������
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();

        // ���� �ð� = ���� ����ִ� �ð� + ��Ÿ�Ӻ��� �� �� Ȯ��
        if (_isGrounded && Time.time >= _groundedTime + _jumpCooldown)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
            _isGrounded = false; // ���� ���Ŀ� ���� ���� ���� ���·� ����
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    // ���� ����ִ� �����Ӹ��� _isGrounded = true -> ���� ����
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _groundedTime = Time.time;
        }
    }
}
