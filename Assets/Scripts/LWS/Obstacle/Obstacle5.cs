using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5 : MonoBehaviour, IObjectPosition
{
    // �߻� �� ������
    [SerializeField] GameObject _obstaclePrefab;

    // �������� ���� �ֱ�
    [SerializeField] private float _launchInterval;

    // �߻� ����
    // 1,0,0 = ������, -1,0,0 = ����
    [SerializeField] private Vector3 _direction;

    // �߻� �ӵ�
    [SerializeField] private float _launchSpeed;

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

    private void Start()
    {
        // launchInterval���� �߻�
        InvokeRepeating(nameof(LaunchObstacle), 0f, _launchInterval);
    }

    private void LaunchObstacle()
    {
        // ������ ����
        GameObject obstacle = Instantiate(_obstaclePrefab, transform.position, Quaternion.identity);

        // �߻缳��
        Rigidbody rigid = obstacle.GetComponent<Rigidbody>();

        rigid.velocity = _direction.normalized * _launchSpeed;
    }
}
