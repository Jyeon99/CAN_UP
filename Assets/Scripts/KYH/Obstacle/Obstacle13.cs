using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle13 : MonoBehaviour, IResetObject, IObjectPosition
{
    // Reset �� ���� ���� ����� ����
    private Quaternion _startRot;

    // Reset �� ����� �������� ����
    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

    // ���� ȸ�� ����
    [SerializeField] private float _rotateAngle;

    // ������ ȸ���ߴ��� üũ
    [SerializeField] private bool _isRotate;

    // ȸ���� ������Ʈ
    [SerializeField] private GameObject _rotatePos;

    // ������ Rigidbody ������
    [SerializeField] private Rigidbody _rigid;

    private Coroutine _rotateRoutine;

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
        // ó���� ȸ�� ������ ����
        _startRot = transform.rotation;
    }

    // ���� ȸ�� �Լ�(�÷��̾��)
    public void RotatePlatform(PlayerController player)
    {
        // �̹� ȸ�������� ���� ó��
        if (_isRotate == true)
            return;

        // _rotatePos�� ȸ�������� _rotateAngle�� ������ŭ ȸ��
        gameObject.transform.RotateAround(_rotatePos.transform.position, Vector3.forward, _rotateAngle);
        _isRotate = true;   // ȸ���ߴٰ� üũ

    }

    // ���� ȸ�� �Լ�(�����ۿ�)
    public void RotatePlatform(Item item)
    {
        // �̹� ȸ�������� ���� ó��
        if (_isRotate == true)
            return;

        // _rotatePos�� ȸ�������� _rotateAngle�� ������ŭ ȸ��
        gameObject.transform.RotateAround(_rotatePos.transform.position, Vector3.forward, _rotateAngle);
        _isRotate = true;   // ȸ���ߴٰ� üũ

    }

    public void Reset()
    {
        transform.rotation = _startRot;
    }
}
