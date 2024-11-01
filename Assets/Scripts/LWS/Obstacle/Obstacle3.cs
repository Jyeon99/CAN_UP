using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3 : MonoBehaviour, IObjectPosition
{
    [Header("���� ����")]

    [SerializeField] private float _explosionDelay; // ���߱��� ��� �ð�
    [SerializeField] private float _explosionForce; // ���� ����
    [SerializeField] private float _resetDelay; // ���� Ȱ��ȭ ��� �ð�

    // ���� ��� ��ü ������Ʈ �迭
    [SerializeField] private GameObject[] _warningSpheres;

    // ���� ���� �� Ÿ�̸�
    [SerializeField] bool _isTriggered = false;
    [SerializeField] float _explosionTimer;

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
        _explosionTimer = _explosionDelay;
    }
    public void Count(PlayerController player)
    {
        if (!_isTriggered)
        {
            _isTriggered = true;
            StartCoroutine(CountDown(player));
        }
    }

    private IEnumerator CountDown(PlayerController player)
    {
        while (_explosionTimer > 0)
        {
            _explosionTimer -= Time.deltaTime;

            // 2�� ������ �� ��ü �ϳ� �� ����
            if (_explosionTimer <= 2f && _explosionTimer > 1f)
            {
                _warningSpheres[0].GetComponent<Renderer>().material.color = Color.red;
            }

            // 1�� ������ �� �ϳ� �� ����
            else if (_explosionTimer <= 1f && _explosionTimer > 0f)
            {
                _warningSpheres[1].GetComponent<Renderer>().material.color = Color.red;
            }

            _explosionTimer -= Time.deltaTime;
            yield return null;
        }

        // ���� ����
        _warningSpheres[2].GetComponent<Renderer>().material.color= Color.red;
        Explode(player);
    }

    private void Explode(PlayerController player)
    {
        Rigidbody rigid = player.GetComponent<Rigidbody>();

        // ������ ���� ���
        Vector3 explosionDir = (player.transform.position - transform.position).normalized;
        rigid.AddForce(explosionDir * _explosionForce, ForceMode.Impulse);

        // ��Ȱ��ȭ �� ��Ȱ��ȭ ����
        gameObject.SetActive(false);
        Invoke(nameof(ResetPlatform), _resetDelay);
    }

    public void Count(Item item)
    {
        if (!_isTriggered)
        {
            _isTriggered = true;
            StartCoroutine(CountDown(item));
        }
    }

    private IEnumerator CountDown(Item item)
    {
        while (_explosionTimer > 0)
        {
            _explosionTimer -= Time.deltaTime;

            // 2�� ������ �� ��ü �ϳ� �� ����
            if (_explosionTimer <= 2f && _explosionTimer > 1f)
            {
                _warningSpheres[0].GetComponent<Renderer>().material.color = Color.red;
            }

            // 1�� ������ �� �ϳ� �� ����
            else if (_explosionTimer <= 1f && _explosionTimer > 0f)
            {
                _warningSpheres[1].GetComponent<Renderer>().material.color = Color.red;
            }

            _explosionTimer -= Time.deltaTime;
            yield return null;
        }

        // ���� ����
        _warningSpheres[2].GetComponent<Renderer>().material.color = Color.red;
        Explode(item);
    }

    private void Explode(Item item)
    {
        Rigidbody rigid = item.GetComponent<Rigidbody>();

        // ������ ���� ���
        Vector3 explosionDir = (item.transform.position - transform.position).normalized;
        rigid.AddForce(explosionDir * _explosionForce, ForceMode.Impulse);

        // ��Ȱ��ȭ �� ��Ȱ��ȭ ����
        gameObject.SetActive(false);
        Invoke(nameof(ResetPlatform), _resetDelay);
    }

    private void ResetPlatform()
    {
        gameObject.SetActive(true);
        _isTriggered = false;
        _explosionTimer = _explosionDelay;

        // ��� ��ü ���� �ʱ�ȭ
        foreach (var sphere in _warningSpheres)
        {
            sphere.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}