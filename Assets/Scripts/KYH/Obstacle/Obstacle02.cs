using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle02 : MonoBehaviour, IReplaceObstacle
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private GameObject _replaceObstacle;

    public void RailObstacle(PlayerController player)
    {
        // �÷��̾� ������Ʈ�� ����
        // �÷��̾� ������Ʈ�� ���ǿ� OnTriggerStay ���� ��
        // �÷��̾� ������Ʈ�� ���� �ӵ��� ���� �������� �б�
        Rigidbody rigid = player.gameObject.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.left * _moveSpeed;
    }

    public void Replace()
    {
        gameObject.SetActive(false);
        _replaceObstacle.SetActive(true);
    }
}
