using System.Collections;
using UnityEngine;

public class ActBaseWalk : PlayerAction
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] BaseData _data;

    [SerializeField] Animator _animator;

    [SerializeField] AudioSource _audio;

    [SerializeField] AudioClip _audioClip;

    [SerializeField] float _walkSoundDurateTime; // �ȴ� �Ҹ� �ֱ�

    private WaitForSeconds _seconds;

    Vector3 dir = new Vector3(-1, 0, 0);

    private void Awake()
    {
        _seconds = new WaitForSeconds(_walkSoundDurateTime);
    }

    public override BTNodeState DoAction()
    {
        //�·� �̵�
        if ((Input.GetKey(KeyCode.A)) && !Input.GetKey(KeyCode.Space)) //A �Ǵ� D Ű�� ������ ��, Space �Է����� �ʾ��� �� �̵�
        {
            _rigidbody.velocity = dir * _data.MoveSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), _data.Rate * Time.deltaTime);
            _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.sqrMagnitude));
            _animator.SetBool("isIdle", false);
            if (_data.WalkRoutine == null)
            {
                _data.WalkRoutine = StartCoroutine(PlayWalkSound());
            }
            return BTNodeState.Running;
        }
        //��� �̵�
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = -dir * _data.MoveSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-dir), _data.Rate * Time.deltaTime);
            _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.sqrMagnitude));
            _animator.SetBool("isIdle", false);
            if (_data.WalkRoutine == null)
            {
                _data.WalkRoutine = StartCoroutine(PlayWalkSound());
            }
            return BTNodeState.Running;
        }

        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("isIdle", true);
            _rigidbody.velocity = Vector3.zero;
            return BTNodeState.Failure;
        }

        else
        {
            return BTNodeState.Failure;
        }


    }

    private IEnumerator PlayWalkSound()
    {
        while (true)
        {
            _audio.clip = _audioClip;
            _audio.Play();
            yield return _seconds;
        }     
    }

}
