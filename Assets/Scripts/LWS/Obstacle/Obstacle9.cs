using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle9 : MonoBehaviour, IReplaceObstacle, IObjectPosition
{
    // �ö����� �� ����� �ߵ��� (�� ��ũ��Ʈ�� ������) Ʈ���Ź����� 1��. ������ ������ 2���̶�� �θ�����.
    // ������ ĳ���Ͱ� trigger enter�� exit�� �Ǵ��� �� �ְ� �ϱ� ����, isTrigger�� �ݶ��̴� ���� �ʿ� (�������� �������̺��� ���ƾ���)
    // 2�� ���� rigidbody �߷� ��� üũ ����, is kinematic üũ �ʿ�

    // 2�� ���� rigidbody
    [SerializeField] private Rigidbody _escapePlatform;

    // �ӵ� ������ ���� ( �÷��̾� �ӵ��� �������� ���� �ʿ� )
    [SerializeField] private float _moveSpeed;

    [SerializeField] GameObject _replaceObject;

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

    public void Runaway(PlayerController player)
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(horizontalInput * _moveSpeed, 0, 0);
        _escapePlatform.velocity = moveDir;
    }
    public void Runaway(Item item)
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(horizontalInput * _moveSpeed, 0, 0);
        _escapePlatform.velocity = moveDir;
    }

    public void Replace()
    {
        _replaceObject.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rigid = collision.collider.GetComponent<Rigidbody>();
        if (rigid.velocity.y <= 0)
        {
            rigid.velocity = Vector3.down;
        }
    }
}
