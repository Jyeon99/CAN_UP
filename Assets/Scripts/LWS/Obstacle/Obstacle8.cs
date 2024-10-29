using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle8 : MonoBehaviour
{    // �������� �ӵ�
    [SerializeField] private float fallSpeed = 20f;

    // ���� ��ġ�� ���ư��� �ӵ�
    [SerializeField] private float returnSpeed = 5f;

    // ������ ������ ���� ��ġ�� �� ��ġ
    private Vector3 startPosition;
    [SerializeField] private float fallDistance = 2f; // �������� �Ÿ�

    // �÷��̾� ���� ����
    [SerializeField] private float detectionRange = 1f;

    // ������ �������� �ִ��� ����
    private bool isFalling;

    private void Start()
    {
        // ������ �ʱ� ��ġ ����
        startPosition = transform.position;
    }

    private void Update()
    {
        // �÷��̾��� �Ӹ� ���� ������ �ִ��� ����
        if (PlayerIsBelow() && !isFalling)
        {
            isFalling = true;
        }

        // ������ �������ų� ���� ��ġ�� ���ư�
        if (isFalling)
        {
            Vector3 targetPosition = startPosition - new Vector3(0, fallDistance, 0);
            MovePlatform(targetPosition, fallSpeed);
        }
        else
        {
            MovePlatform(startPosition, returnSpeed);
        }
    }

    private bool PlayerIsBelow()
    {
        // �÷��̾ ���� �Ÿ� ���� �ִ��� Ȯ��
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
            float heightDifference = transform.position.y - player.transform.position.y;

            // �÷��̾ ���� �Ʒ��� �ְ�, x������ ���� �Ÿ� ���� �ִ��� Ȯ��
            return distanceToPlayer < detectionRange && heightDifference > 0;
        }
        return false;
    }

    private void MovePlatform(Vector3 targetPosition, float speed)
    {
        // ������ ��ǥ ��ġ���� �̵��ϵ��� ����
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ���� ��ȯ
        if (transform.position == targetPosition)
        {
            isFalling = !isFalling;
        }
    }
}
