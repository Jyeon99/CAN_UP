using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour, IResetObject, IObjectPosition
{
    // �����ǰ� ����� ��
    [SerializeField] private GameObject _wall;

    // ���� �̵��ϴ� �ӵ�
    [SerializeField] private float _moveSpeed;

    // reset()���� ����ϱ� ���� �ʿ��� ���� Ʈ������ ��ġ
    [SerializeField] private Vector3 _startPos;

    // ���� ��ǥ ��ġ
    [SerializeField] private Vector3 _targetPosition;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    // �̸� ����
    [SerializeField] string _name;

    private bool _isMoving;

    private void Awake()
    {
        _startPos = transform.position;
        _isMoving = false;
    }

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

    public void EnterWall(PlayerController player)
    {
        _isMoving = true; // �̵� ���� �÷��� Ȱ��ȭ
    }

    public void EnterWall(Item item)
    {
        _isMoving = true; // �̵� ���� �÷��� Ȱ��ȭ
    }

    private void Update()
    {
        // ���� ��ǥ ��ġ���� �̵��ϵ��� ������Ʈ
        if (_isMoving && _wall != null && Vector3.Distance(_wall.transform.position, _targetPosition) > 0.01f)
        {
            MoveWall();
        }
        else
        {
            _isMoving = false; // ��ǥ ��ġ�� �����ϸ� �̵� ����
        }
    }

    private void MoveWall()
    {
        _wall.transform.position = Vector3.MoveTowards(_wall.transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        _wall.transform.position = _startPos;
        _isMoving = false; // ���� �� �̵� ���� �ʱ�ȭ
    }
}
