using UnityEngine;

[System.Serializable]
public class BaseData : PlayerData
{
    [SerializeField] private float _moveSpeed; // �̵� �ӵ�

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    [SerializeField] private float _maxJumpPower; // �ִ� ������ = 5m

    public float MaxJumpPower { get { return _maxJumpPower; } set { _maxJumpPower = value; } }

    [SerializeField] private float _rate;

    public float Rate { get { return _rate; } set { _rate = value; } }

    [SerializeField] private float _throwPower;

    public float ThrowPower { get { return _throwPower; } set { _throwPower = value; } }

    //[SerializeField] private bool _isGrounded; // ���� ����ִ��� ����

    //public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }

    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } } //���Ŀ� SaveData �ʰ� ������ ����.

    [SerializeField] private Vector3 _jumpDir;

    public Vector3 JumpDir { get { return _jumpDir; } set { _jumpDir = value; } }

    [SerializeField] private float _pickUpRange;

    public float PickUpRange { get { return _pickUpRange; ; } set { _pickUpRange = value; } }

}
