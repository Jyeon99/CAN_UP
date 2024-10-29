using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour, IResetObject
{
    // ������ ���� ������
    [SerializeField] private GameObject _wallPrefab;

    // ���� �̵��ϴ� �ӵ�
    [SerializeField] private float _moveSpeed;

    // ��� �ð� ����
    private WaitForSeconds _appearDelay;

    // ���� ������ ��ġ
    [SerializeField] private Vector3 _spawnOffset;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    //reset()���� ����ϱ� ���� wallInstance�� ������ �ʵ�
    private GameObject wallInstance;

    public void WallCreate(PlayerController player)
    {
        // �÷��̾� ��ġ + offset���� ����
        Vector3 spawnPosition = transform.position + _spawnOffset;

        StartCoroutine(WallCreateRoutine(spawnPosition));
    }

    // �ڷ�ƾ���� �� ������ �̵��� ����
    private IEnumerator WallCreateRoutine(Vector3 spawnPosition)
    {
        // ������ �ð� �Ŀ� �� ����
        yield return _appearDelay;

        // ���� ���� ��ġ�� �����ϰ� �ʱ� ��ġ ����
        wallInstance = Instantiate(_wallPrefab, spawnPosition, Quaternion.identity);

        // ���� ��ǥ ��ġ���� ���������� �̵�
        while (Vector3.Distance(wallInstance.transform.position, transform.position) > 0.01f)
        {
            wallInstance.transform.position = Vector3.MoveTowards(wallInstance.transform.position, transform.position, _moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void Reset()
    {
        if (wallInstance != null)
        {
            Destroy(wallInstance);
            wallInstance = null;
        }
    }
}
