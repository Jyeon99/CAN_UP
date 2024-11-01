using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4 : MonoBehaviour, IObjectPosition
{
    // �ݺ� �ֱ� (��)
    [SerializeField] float _moveInterval;

    // �ӵ�
    [SerializeField] float _speed;

    // �̵� ����
    [SerializeField] Vector3 _dir;

    // �ʱ� ��ġ
    [SerializeField] Vector3 _startPos;

    // �÷��̾ �о ���� ũ��
    [SerializeField] float _pushForce;

    [SerializeField] bool _movingOut;

    // �̸� ����
    [SerializeField] string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    private void Start()
    {
        _startPos = transform.position;
        StartCoroutine(RoutineObstacle());
    }

    private IEnumerator RoutineObstacle()
    {
        while (true)
        {
            // ��ǥ ��ġ ���
            Vector3 targetPosition = _movingOut ? _startPos + _dir : _startPos;

            // ��ǥ ��ġ���� �̵�
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

                yield return null;
            }

            _movingOut = !_movingOut;

            yield return new WaitForSeconds(_moveInterval);
        }
    }

    public void PushPlayer(PlayerController player)
    {
        Rigidbody rigid = player.GetComponent<Rigidbody>();
        if (rigid != null)
        {
            Vector3 pushDirection = (player.transform.position - transform.position).normalized;
            rigid.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
        }
    }

    public void PushItem(Item item)
    {
        Rigidbody rigid = item.GetComponent<Rigidbody>();
        if (rigid != null)
        {
            Vector3 pushDirection = (item.transform.position - transform.position).normalized;
            rigid.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
        }
    }
}
