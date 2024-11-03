using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActJumperJump : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] GameObject _rayShooter;

    [SerializeField] AudioSource _audio;

    [SerializeField] AudioClip _audioClip;

    private bool _isJumping;

    private bool _isSound;

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
        Debug.DrawRay(_rayShooter.transform.position, rayDirection * 1f, Color.red);
        Debug.Log("shootray");

        // ĳ���� �Ʒ� �������� ����ĳ��Ʈ �߻�
        RaycastHit hit;
        if (Physics.Raycast( _rayShooter.transform.position, rayDirection, out hit, 1f))
        {
            // ����ĳ��Ʈ�� �±װ� �´� ������Ʈ�� ��Ҵ��� Ȯ��
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("ObstacleCol") || hit.collider.CompareTag("ObstacleTri"))
            {
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
             
            if(_isSound == false)
            {
                _isSound = true;
                _audio.PlayOneShot(_audioClip);
            }
            return BTNodeState.Running;

        }
        else
        {
            _isSound = false;
            return BTNodeState.Failure;
        }
    }
}
