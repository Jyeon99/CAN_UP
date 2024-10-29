using UnityEngine;

public class ActBaseWalk : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;


    int y;


    public override BTNodeState DoAction()
    {
       


        //Move
        if ((Input.GetKey(KeyCode.A)) && !Input.GetKey(KeyCode.Space)) //A �Ǵ� D Ű�� ������ ��, Space �Է����� �ʾ��� �� �̵�
        {
            _rigidbody.velocity = Vector3.left * _data.MoveSpeed;
            return BTNodeState.Running;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = Vector3.right * _data.MoveSpeed;
            return BTNodeState.Running;
        }



        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("Move", true);
            return BTNodeState.Success;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _rigidbody.velocity = Vector3.zero;
            return BTNodeState.Success;
        }


        else
        {
            return BTNodeState.Failure;
        }

    }
}
