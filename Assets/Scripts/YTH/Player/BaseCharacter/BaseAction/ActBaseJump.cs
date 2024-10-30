using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    [SerializeField] float _startJumpPositionY = 0.3f;
    public override BTNodeState DoAction()
    {
        Vector3 _jumpDirectionR = new Vector3(1, 2, 0).normalized;
        Vector3 _jumpDirectionL = new Vector3(-1, 2, 0).normalized;

        //���� ��¡ �ƽ�, �ִ����������� ����
        if (_data.JumpPower >= _data.MaxJumpPower && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space)))
        {
            _data.JumpPower = _data.MaxJumpPower;

            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            }
            else
            {
                _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            }
            JumpEvent();
            Debug.Log("�ִ� ����");
            return BTNodeState.Success;
        }

        if (Input.GetKey(KeyCode.Space))// space ������ �ִ� ����
        {

            _data.JumpPower += Time.deltaTime * 6f;
            //ȸ�� ����
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.velocity = Vector3.zero;
                transform.forward = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.velocity = Vector3.zero;
                transform.forward = Vector3.right;
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                transform.forward = Vector3.back;
            }
            Debug.Log("������ ��¡ ��");
            return BTNodeState.Running;
        }

        //�·� ����
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.A) || (Input.GetKeyUp(KeyCode.A)))))
        {
            _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            Debug.Log("�·� ��¦ ����");
            return BTNodeState.Success;
        }

        // ��� ����
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.D) || (Input.GetKeyUp(KeyCode.D)))))
        {
            _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            Debug.Log("��� ��¦ ����");
            return BTNodeState.Success;
        }

        // ���� ����
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            Debug.Log("���� ��¦ ����");
            return BTNodeState.Success;
        }



        else
        {
            return BTNodeState.Failure;
        }
    }

    //���� �� ���������� �߻��ϴ� �Լ�
    public void JumpEvent()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        _data.IsGrounded = false;
        _animator.SetTrigger("Jump");
        _data.JumpPower = 0;
    }
}
