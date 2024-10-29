using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    public override BTNodeState DoAction()
    {
        Vector3 _jumpDirectionR = new Vector3(1, 2, 0).normalized;
        Vector3 _jumpDirectionL = new Vector3(-1, 2, 0).normalized;

        if (Input.GetKey(KeyCode.Space) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) // space ������ �ִ� ����
        {
            _data.JumpPower += Time.deltaTime * 6f;  // ������ �����
            Debug.Log("������ ��¡ ��");

            //������ �ִ� ���� �� ���� ����
            if (_data.JumpPower >= _data.MaxJumpPower)
            {
                _data.JumpPower = _data.MaxJumpPower;
                _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
                JumpEvent();
                return BTNodeState.Success;
            }

            return BTNodeState.Running;
        }

        //�·� ����
        else if ((Input.GetKeyUp(KeyCode.Space)) && (Input.GetKey(KeyCode.A)))
        {
            //������ �ִ� ���� �� (�ִ� ����������) �·� ����
            if (_data.JumpPower >= _data.MaxJumpPower && (Input.GetKey(KeyCode.A)))                      
            {                                                                                            //���ǹ� �����ؼ� ������ ��¡�� A/D Ű �������� ��� �̾����� ����
                _data.JumpPower = _data.MaxJumpPower;                                                    //������ ���� ����
                _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
                JumpEvent();
                return BTNodeState.Success;
            }

            _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        // ��� ����
        else if ((Input.GetKeyUp(KeyCode.Space)) && (Input.GetKey(KeyCode.D)))
        {
            //������ �ִ� ���� �� (�ִ� ����������) ��� ����
            if (_data.JumpPower >= _data.MaxJumpPower && (Input.GetKey(KeyCode.D)))
            {
                _data.JumpPower = _data.MaxJumpPower;
                _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
                JumpEvent();
                return BTNodeState.Success;
            }

            _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
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
        _data.IsGrounded = false;
        _animator.SetTrigger("Jump");
        _data.JumpPower = 0;
    }
}
