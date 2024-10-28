using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;

    // ���� ����
    private float _decelerationFactor = 0.9f;

    // JumperData, Rigidbody ��������
    private void Start()
    {
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();
    }

    // DoAction ������
    public override BTNodeState DoAction()
    {
        // Grounded ������ ���� �̵� ���� X
        if (_jumperData._isGrounded)
        {
            return BTNodeState.Failure;
        }

        // A,D �Է½� �̵� ����
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {            
            float horizontalInput = Input.GetAxis("Horizontal");

            // ���� �̵� ������ �ݴ����� Ȯ��
            bool isOppositeDirection = (horizontalInput < 0 && _rigidbody.velocity.x > 0) || (horizontalInput > 0 && _rigidbody.velocity.x < 0);

            Debug.Log($"�ݴ� ���� ����: {isOppositeDirection}");

            // �ݴ���� Ű�� ������ �� ���� ����
            if (isOppositeDirection)
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x * (1 - _decelerationFactor), _rigidbody.velocity.y, _rigidbody.velocity.z);
                Debug.Log("���� ��");
            }
            else
            {
                _rigidbody.velocity = new Vector3(horizontalInput * _jumperData.MoveSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);
                Debug.Log("���߿��� �̵� ��");
            }

            return BTNodeState.Running;
        }
        // �� �Է� �� Failure ��ȯ
        else
        {
            return BTNodeState.Failure;
        }
    }
}
