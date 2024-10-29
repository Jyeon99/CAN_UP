using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle8 : MonoBehaviour
{    // �������� �ӵ�
    [SerializeField] private float fallSpeed;

    // ���� ��ġ�� ���ư��� �ӵ�
    [SerializeField] private float returnSpeed;

    // ������ �� �ٽ� �ö󰡱������ ��� �ð�
    [SerializeField] private float stayTime;

    // �̵��� �Ÿ�
    [SerializeField] private float fallDistance;

    // ������ ���� ��ġ ����
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    // ������ �������� �ִ��� ����
    [SerializeField] private bool playerEntered;
    [SerializeField] private bool isFalling;
    [SerializeField] private bool isReturning;
    [SerializeField] private float stayTimer;

    private void Start()
    {
        // ���� ��ġ�� ������ ��ġ ����
        startPos = transform.position;
        endPos = startPos - new Vector3(0, fallDistance, 0);
    }

    private void Update()
    {
        if (isFalling)
        {
            // �������� ���� ��ġ�� fallPosition���� �̵�
            transform.position = Vector3.MoveTowards(transform.position, endPos, fallSpeed * Time.deltaTime);

            // ��ǥ ��ġ�� �����ϸ� ��� �ð� ����
            if (Vector3.Distance(transform.position, endPos) < 0.01f)
            {
                isFalling = false;
                stayTimer = stayTime;
            }
        }
        else if (stayTimer > 0f)
        {
            // ��� �ð� ���
            stayTimer -= Time.deltaTime;

            // ��� �ð��� ������ ���� ��ġ�� ���ư���
            if (stayTimer <= 0f)
            {
                isReturning = true;
            }
        }
        else if (isReturning)
        {
            // ���� ��ġ�� ���ư���
            transform.position = Vector3.MoveTowards(transform.position, startPos, returnSpeed * Time.deltaTime);

            // ���� ��ġ�� �����ϸ� �̵� ����
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                isReturning = false;
            }
        }
    }

    // ����͸� ���� ȣ��� �޼���
    public void ActivateFall(PlayerController player)
    {
        if (!isFalling && !isReturning) // �̵� ���� �ƴ� ���� ����
        {
            isFalling = true;
        }
    }
}
