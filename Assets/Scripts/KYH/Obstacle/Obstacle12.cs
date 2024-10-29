using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle12 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] Rigidbody _rigid;

    // OnCollisionEnter�ϸ� ������ õõ�� ��������
    public void PlatformDown(PlayerController player)
    {
        Debug.Log("dadf");
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _endPos.position, _moveSpeed);
    }

    // OnCollisionExit�ϸ� ������ õõ�� �ö󰡱�
    public void PlatformReturn(PlayerController player)
    {
        Debug.Log("dffff");
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _startPos.position, _moveSpeed);
    }
}
