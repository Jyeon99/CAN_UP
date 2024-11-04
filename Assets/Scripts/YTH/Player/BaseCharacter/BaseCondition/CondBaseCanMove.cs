using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Vector3 _size;

    public override bool DoCheck()
    {
        Vector3 _curPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // OverlapBox�� ��� ���� ��ġ ��ǥ

        Collider[] _hit = Physics.OverlapBox(_curPos, _size, Quaternion.identity); // �� ���� ����ü�� ����� 
                                                                              // �浹ü�� �迭�� ����
        for (int i = 0; i < _hit.Length; ++i)  
        {
            if (_hit[i].CompareTag("Ground") || _hit[i].CompareTag("ObstacleTri") || _hit[i].CompareTag("ObstacleCol"))
            {
                _data.IsGrounded = true;
                return true;
            }
            else
            {
                _data.IsGrounded = false;
            }
        }

        if (_data.IsStiff == true || _data.IsGrounded == false) // ���������� ������ ����, ���� �ִ� ���°� �ƴ� �� => �̵� �Ұ�
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnDrawGizmos() // OverlapBox�� ����� ���Ӿ����� Ȯ�� ����
    {
        Vector3 gizmos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Gizmos.DrawWireCube( gizmos,  _size);
    }
}
