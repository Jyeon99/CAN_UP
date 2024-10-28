using UnityEngine;

[System.Serializable]
public class BaseData : PlayerData
{
    [SerializeField] private float _moveSpeed;

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    private float _z;

    public float Z { get { return _z; } private set { } }

    [SerializeField] private Vector3 _moveDir;

    public Vector3 MoveDir { get { return _moveDir; } set { _moveDir = value; } }

    [SerializeField] private float _canJumpTime; 

    public float CanJumpTime { get { return _canJumpTime; } set { _canJumpTime = value; } } // ���� ������ // Space ������ ������ �������� ���� ��

    [SerializeField] private float _maxTime;

    public float MaxTime { get { return _maxTime; } set { _maxTime = value; } }

    [SerializeField] private float _minJumpGauge;

    public float MinJumpGauge { get {return _minJumpGauge; } set {_minJumpGauge = value; } }

    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } } //���Ŀ� SaveData �ʰ� ������ ����.

    [SerializeField] private float _throwPower;

    public float ThrowPower { get { return _throwPower; } set { _throwPower = value; } }

    [SerializeField] private float _groundCheckDistance = 0.1f;

    public float GroundCheckDistance { get { return _groundCheckDistance; } set { _groundCheckDistance = value; } } 

    [SerializeField] private bool _isGrounded;

    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
}
