using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5Bullet : MonoBehaviour
{
    // �ε����� �� �÷��̾ �� ��
    [SerializeField] private float _pushForce;
    [SerializeField] private Vector3 _pushDir;

    // �̵� �ӵ��� ����
    private Vector3 _direction;
    private float _speed;



    private void Start()
    {
        Destroy(gameObject, 5f); // 5�� �� �ı�
    }

    public void Initialize(Vector3 direction, float speed)
    {
        _direction = direction.normalized;
        _speed = speed;
    }

    private void Update()
    {
        // �߻� �������� �̵�
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void PushPlayer(PlayerController player)
    {
        // �÷��̾��� rigid�� ������
        Rigidbody rigid = player.GetComponent<Rigidbody>();

        rigid.AddForce(_pushDir * _pushForce, ForceMode.Impulse);

        Destroy(gameObject);
    }

    public void PushPlayer(Item item)
    {
        // �÷��̾��� rigid�� ������
        Rigidbody rigid = item.GetComponent<Rigidbody>();

        rigid.AddForce(_pushDir * _pushForce, ForceMode.Impulse);

        Destroy(gameObject);
    }
}
