using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle9 : MonoBehaviour, IReplaceObstacle
{
    // �ö����� �� ����� �ߵ��� (�� ��ũ��Ʈ�� ������) Ʈ���Ź����� 1��. ������ ������ 2���̶�� �θ�����.
    // ������ ĳ���Ͱ� trigger enter�� exit�� �Ǵ��� �� �ְ� �ϱ� ����, isTrigger�� �ݶ��̴� ���� �ʿ� (�������� �������̺��� ���ƾ���)
    // 2�� ���� rigidbody �߷� ��� üũ ����, is kinematic üũ �ʿ�

    // 2�� ���� rigidbody
    [SerializeField] private Rigidbody _escapePlatform;

    // �ӵ� ������ ���� ( �÷��̾� �ӵ��� �������� ���� �ʿ� )
    [SerializeField] private float _moveSpeed;

    [SerializeField] GameObject _replaceObject;
    
    public void Runaway(PlayerController player)
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
}
