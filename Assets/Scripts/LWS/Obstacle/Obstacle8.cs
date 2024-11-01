using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle8 : MonoBehaviour, IObjectPosition
{    // �������� �ӵ�
    [SerializeField] private float _fallSpeed;

    // ���� ��ġ�� ���ư��� �ӵ�
    [SerializeField] private float _returnSpeed;

    // ������ �� �ٽ� �ö󰡱������ ��� �ð�
    [SerializeField] private float _stayTime;

    // �̵��� �Ÿ�
    [SerializeField] private float _fallDistance;

    // ������ ���� ��ġ ����
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _endPos;

    // ������ �������� �ִ��� ����
    [SerializeField] private bool _isFalling;
    [SerializeField] private bool _isReturning;
    [SerializeField] private float _stayTimer;

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
        // ���� ��ġ�� ������ ��ġ ����
        _startPos = transform.position;
        _endPos = _startPos - new Vector3(0, _fallDistance, 0);
    }

    private void Update()
    {
        if (_isFalling)
        {
            // �������� ���� ��ġ�� fallPosition���� �̵�
            transform.position = Vector3.MoveTowards(transform.position, _endPos, _fallSpeed * Time.deltaTime);

            // ��ǥ ��ġ�� �����ϸ� ��� �ð� ����
            if (Vector3.Distance(transform.position, _endPos) < 0.01f)
            {
                _isFalling = false;
                _stayTimer = _stayTime;
            }
        }
        else if (_stayTimer > 0f)
        {
            // ��� �ð� ���
            _stayTimer -= Time.deltaTime;

            // ��� �ð��� ������ ���� ��ġ�� ���ư���
            if (_stayTimer <= 0f)
            {
                _isReturning = true;
            }
        }
        else if (_isReturning)
        {
            // ���� ��ġ�� ���ư���
            transform.position = Vector3.MoveTowards(transform.position, _startPos, _returnSpeed * Time.deltaTime);

            // ���� ��ġ�� �����ϸ� �̵� ����
            if (Vector3.Distance(transform.position, _startPos) < 0.01f)
            {
                _isReturning = false;
            }
        }
    }

    // ����͸� ���� ȣ��� �޼���
    public void ActivateFall(PlayerController player)
    {
        if (!_isFalling && !_isReturning) // �̵� ���� �ƴ� ���� ����
        {
            _isFalling = true;
        }
    }

    public void ActivateFall(Item item)
    {
        if (!_isFalling && !_isReturning) // �̵� ���� �ƴ� ���� ����
        {
            _isFalling = true;
        }
    }
}