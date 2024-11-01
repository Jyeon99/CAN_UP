using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    private bool _isJumping;

    private void Update()
    {
        CheckGround();

        if(_rigidbody.velocity.y > 0 && !_jumperData.IsGrounded)
        {
            if (!_isJumping)
            {
                _jumperData.JumpCount++;
            }
            _isJumping = true;
        }

    }

    

    // ���� �����ϴ� ����ĳ��Ʈ
    private void CheckGround()
    {
        // ����ĳ��Ʈ �߻� ������ �Ʒ��� ����
        Vector3 rayDirection = Vector3.down;

        // ����ĳ��Ʈ �ð�ȭ (�� �信�� ����)
        Debug.DrawRay(transform.position, rayDirection * 1.75f, Color.red);

        // ĳ���� �Ʒ� �������� ����ĳ��Ʈ �߻�
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 1.75f))
        {
            // ����ĳ��Ʈ�� �±װ� �´� ������Ʈ�� ��Ҵ��� Ȯ��
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("ObstacleCol") || hit.collider.CompareTag("ObstacleTri"))
            {
                Debug.Log("x");
                _jumperData.IsGrounded = true;
            }
        }
        else
        {
            _jumperData.IsGrounded = false;
        }
    }

    // DoAction ������
    public override BTNodeState DoAction()
    {
        if (_jumperData.IsGrounded)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, 0);
            _isJumping = false;

            return BTNodeState.Running;

        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}
