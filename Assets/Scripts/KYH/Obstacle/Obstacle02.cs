using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle02 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private GameObject _replaceObstacle;
    [SerializeField] private Rigidbody _rigid;

    private Coroutine _railRoutine;

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

    // ���� ��� �ڷ�ƾ
    private IEnumerator RailRoutine()
    {
        // ĳ���� �ݴ� �������� �о��
        _rigid.AddForce(Vector3.left * _moveSpeed, ForceMode.Impulse);
        // �о�� Ÿ�̹� �߰�
        yield return new WaitForSeconds(1.0f);

        // �ڷ�ƾ�� null�� ó��
        _railRoutine = null;
    }
}
