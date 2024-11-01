using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour, IResetObject, IObjectPosition
{
    // ������ ���� ������
    [SerializeField] private GameObject _wallPrefab;

    // ���� �̵��ϴ� �ӵ�
    [SerializeField] private float _moveSpeed;

    // ���� ������ ��ġ�� ��ǥ ��ġ
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private Vector3 _targetPosition;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    //reset()���� ����ϱ� ���� wallInstance�� ������ �ʵ�
    private GameObject wallInstance;

    // �̸� ����
    [SerializeField] string _name;


    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public void WallCreate(PlayerController player)
    {
        // �� ���� �� �ʱ���ġ ����
        wallInstance = Instantiate(_wallPrefab, _spawnPosition, Quaternion.identity);

        // ���� ��ǥ ��ġ���� �̵�
        MoveWall();
    }

    public void WallCreate(Item item)
    {
        // �� ���� �� �ʱ���ġ ����
        wallInstance = Instantiate(_wallPrefab, _spawnPosition, Quaternion.identity);

        // ���� ��ǥ ��ġ���� �̵�
        MoveWall();
    }

    // �� �̵��� �Լ�
    private void MoveWall()
    {
        wallInstance.transform.position = Vector3.MoveTowards(wallInstance.transform.position, _targetPosition, _moveSpeed*Time.deltaTime);
    }

    private void Update()
    {
        // UPDATE���� ���� ������ �̵�
        if (wallInstance != null && Vector3.Distance(wallInstance.transform.position, _targetPosition) > 0.01f)
        {
            MoveWall();
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
