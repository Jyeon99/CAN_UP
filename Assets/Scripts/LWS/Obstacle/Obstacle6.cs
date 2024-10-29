using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour
{
    // ������ ���� ������
    [SerializeField] private GameObject wallPrefab;

    // ���� �̵��ϴ� �ӵ�
    [SerializeField] private float moveSpeed;

    // ��� �ð� ����
    private WaitForSeconds appearDelay;

    // ���� ������ ��ġ
    [SerializeField] private Vector3 spawnOffset;

    public void WallCreate(PlayerController player)
    {
        // �÷��̾� ��ġ + offset���� ����
        Vector3 spawnPosition = transform.position + spawnOffset;

        StartCoroutine(WallCreateRoutine(spawnPosition));
    }

    // �ڷ�ƾ���� �� ������ �̵��� ����
    private IEnumerator WallCreateRoutine(Vector3 spawnPosition)
    {
        // ������ �ð� �Ŀ� �� ����
        yield return appearDelay;

        // ���� ���� ��ġ�� �����ϰ� �ʱ� ��ġ ����
        GameObject wallInstance = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);

        // ���� ��ǥ ��ġ���� ���������� �̵�
        while (Vector3.Distance(wallInstance.transform.position, transform.position) > 0.01f)
        {
            wallInstance.transform.position = Vector3.MoveTowards(wallInstance.transform.position, transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // ������ ����� �����ϸ� �ı�
        if ( Vector3.Distance(wallInstance.transform.position,transform.position) < 0.01f)
        {
            Destroy(wallInstance);
        }
    }
}
