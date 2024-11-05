using UnityEngine;

public class ActBaseJump : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    [SerializeField] float _startJumpPositionY = 0.3f;

    [SerializeField] float _jumpPowerRate;

    [SerializeField] AudioSource _jumpAudio;

    [SerializeField] AudioSource _moveAudio;

    [SerializeField] AudioClip _audioClip;

    Vector3 _jumpDirectionR = new Vector3(1, 2, 0).normalized;
    Vector3 _jumpDirectionL = new Vector3(-1, 2, 0).normalized;

    public override BTNodeState DoAction()
    {
        //��¡ �ִ��, �ִ����������� ����
        if (_data.JumpPower >= _data.MaxJumpPower)
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
            return BTNodeState.Success;
        }

        if (Input.GetKey(KeyCode.Space)) //Space�� ������ �ִ� ����
        {
            _data.JumpPower += Time.deltaTime * _jumpPowerRate; //Space�� ������ ������ �������� �����
            _animator.SetBool("isIdle", true);

            if (Input.GetKey(KeyCode.A)) // Space + A Ű�� ������ ���� �� 
            {
                _rigidbody.velocity = Vector3.zero; // ���缭
                transform.forward = Vector3.left; // ������ �Ĵٺ�
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
            return BTNodeState.Running;
        }

        //�·� ����
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.A)))) // A ���� ���·� Space�� ���� �·� ����
        {
            _rigidbody.AddForce(_jumpDirectionL * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        // ��� ����
        if ((Input.GetKeyUp(KeyCode.Space)) && ((Input.GetKey(KeyCode.D))))
        {
            _rigidbody.AddForce(_jumpDirectionR * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        // ���� ����
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _data.JumpPower, ForceMode.Impulse);
            JumpEvent();
            return BTNodeState.Success;
        }

        else
        {
            if (_rigidbody.velocity.y < 0) // ���� ��
            {
                Vector3 curVelocity = new Vector3(0, _rigidbody.velocity.y, 0); // �������� �������� ��

                _rigidbody.velocity = curVelocity;
            }

            return BTNodeState.Failure;
        }
    }

    //���� �� ���������� �߻��ϴ� �Լ�
    public void JumpEvent()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + _startJumpPositionY, transform.position.z);
        _data.IsGrounded = false;
        _animator.SetTrigger("Jump");
        _data.JumpPower = 0;
        _data.JumpCount++;
        _jumpAudio.PlayOneShot(_audioClip);
    }
}
