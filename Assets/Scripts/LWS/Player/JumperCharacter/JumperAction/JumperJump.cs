using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    // DoAction ������
    public override BTNodeState DoAction()
    {
        // ���� �ð� = ���� ����ִ� �ð� + ��Ÿ�Ӻ��� �� �� Ȯ��
        if (_jumperData._isGrounded)
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

    // ���� ������ _isGrounded = true -> ���� ����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("ObstacleCol") || collision.gameObject.CompareTag("ObstacleTri"))
        {
            _jumperData._isGrounded = true;
        }
    }
}
