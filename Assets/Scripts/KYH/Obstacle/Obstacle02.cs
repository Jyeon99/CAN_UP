using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle02 : MonoBehaviour, IObjectPosition
{
    // �÷��̾� �� �������� �з����� �ӵ�
    [SerializeField] private float _moveSpeed;

    // �÷��̾��� Rigidbody ������ ����
    [SerializeField] private Rigidbody _rigid;

    // ���� ���� ��� �ڷ�ƾ ����(�÷��̾��)
    private Coroutine _railRoutine;

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

    // ���� ���� ��� �Լ�(�÷��̾�)
    public void RailObstacle(PlayerController player)
    {
        // �÷��̾��� Rigidbody ������Ʈ�� ��������
        _rigid = player.gameObject.GetComponent<Rigidbody>();

        // �ڷ�ƾ ���� null�� ��� �ڷ�ƾ ����
        if (_railRoutine == null )
        {
            _railRoutine = StartCoroutine(RailRoutine());
        }
    }

    // ���� ���� ��� �Լ�(������)
    public void RailObstacle(Item item)
    {
        // �÷��̾��� Rigidbody ������Ʈ�� ��������
        _rigid = item.gameObject.GetComponent<Rigidbody>();

        // �ڷ�ƾ ���� null�� ��� �ڷ�ƾ ����
        if (_railRoutine == null)
        {
            _railRoutine = StartCoroutine(RailRoutine());
        }
    }

    // ���� ��� �ڷ�ƾ
    private IEnumerator RailRoutine()
    {
        // ĳ���� �ݴ� �������� �о��
        _rigid.AddForce(Vector3.left * _moveSpeed, ForceMode.Impulse);
        // �о�� Ÿ�̹� �߰�
        yield return new WaitForSeconds(0.2f);

        // �ڷ�ƾ�� null�� ó��
        _railRoutine = null;
    }
}
