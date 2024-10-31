using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle12 : MonoBehaviour
{
    // ������ �����̴� �ӵ�
    [SerializeField] private float _moveSpeed;

    // ���� �̵��� ���� ����
    [SerializeField] private Transform _startPos;

    // ���� �̵��� �� ����
    [SerializeField] private Transform _endPos;

    // ������ Rigidbody ������
    [SerializeField] private Rigidbody _rigid;

    // ���� ������ ���� �ڷ�ƾ ����
    private Coroutine _upRoutine;

    //OnCollisionEnter�ϸ�
    public void PlatformDown(PlayerController player)
    {
        // �÷����� �Ʒ��� ���� �ӵ��� ����
        _rigid.velocity = Vector3.down * _moveSpeed;
    }
    
    // OnCollisionExit�ϸ�
    public void PlatformReturn(PlayerController player)
    {
        // �÷����� _startPos�� ����
        _upRoutine = StartCoroutine(UpCoroutine());
    }

    //OnCollisionEnter�ϸ�
    public void PlatformDown(Item item)
    {
        // �÷����� �Ʒ��� ���� �ӵ��� ����
        _rigid.velocity = Vector3.down * _moveSpeed;
    }

    // OnCollisionExit�ϸ�
    public void PlatformReturn(Item item)
    {
        // �÷����� _startPos�� ����
        _upRoutine = StartCoroutine(UpCoroutine());
    }

    // �÷����� ���� �ڸ��� ���ư��� ��� �ڷ�ƾ
    IEnumerator UpCoroutine() 
    {
        while (true)
        {
            // �÷����� y��ǥ���� _startPos�� y��ǥ�� �̻��� ��
            if (gameObject.transform.position.y >= _startPos.position.y)
            {
                _rigid.velocity = Vector3.zero;     // �̵����� 0���� ����
                StopCoroutine(_upRoutine);          // �ڷ�ƾ ����
                _upRoutine = null;                  // �ڷ�ƾ ���� null�� ����
            }
            // �÷����� y��ǥ���� _startPos�� y��ǥ�� �̻��� �ƴ� ��� (���� ������ ���� ���� ���)
            else
            {
                // ���� ��ġ�� ���󺹱�
                _rigid.velocity = Vector3.up * _moveSpeed;
            }
            
            // null���� ��ȯ
            yield return null;
        }
    }
}
