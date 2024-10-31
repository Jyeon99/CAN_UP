using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : PlayerAction
{
    [SerializeField] JumperData _jumperData;

    [SerializeField] Rigidbody _rigidbody;

    // DoAction ������
    public override BTNodeState DoAction()
    {
        // Grounded ������ ���� �̵� ���� X
        if (_jumperData.IsGrounded)
        {
            return BTNodeState.Failure;
        }

        // isStiff �϶��� �ݴ� ����Ű ���� �� ƨ���� ������ �ӵ� ����
        if (_jumperData.IsStiff)
        {
            bool horizontalInput = Input.GetButton("Horizontal");

            // ���� �ӵ� ����� �ݴ� �������� Ȯ��
            if ((horizontalInput == true && _rigidbody.velocity.x > 0 ))  
            {
                _rigidbody.AddForce(Vector3.left * _jumperData.Resist, ForceMode.Force);
            }
            
            else if ((horizontalInput == true && _rigidbody.velocity.x < 0))
            {
                _rigidbody.AddForce(Vector3.right * _jumperData.Resist, ForceMode.Force);
            }

            // �ݴ� Ű �Է��� ������ ���� �Ұ�
            return BTNodeState.Failure;
        }

        // A,D �Է½� �̵� ����
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {            
            float horizontalInput = Input.GetAxis("Horizontal");

            _rigidbody.velocity = new Vector3(horizontalInput * _jumperData.MoveSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);

            return BTNodeState.Running;
        }

        // �� �Է� �� Failure ��ȯ
        else
        {
            return BTNodeState.Failure;
        }
    }
}
