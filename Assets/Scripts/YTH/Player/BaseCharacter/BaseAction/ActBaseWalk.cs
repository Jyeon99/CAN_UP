using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBaseWalk : PlayerAction 
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    public override BTNodeState DoAction()
    {
        if ((Input.GetKey(KeyCode.A)) && !Input.GetKey(KeyCode.Space)) //A �Ǵ� D Ű�� ������ ��, Space �Է����� �ʾ��� �� �̵�
        {
            _rigidbody.velocity = Vector3.left * _data.MoveSpeed;
            Debug.Log("left �̵���");
            return BTNodeState.Running;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = Vector3.right * _data.MoveSpeed;
            Debug.Log("right �̵���");
            return BTNodeState.Running;
        }

        else
        {
            return BTNodeState.Failure;
        }

    }
}
