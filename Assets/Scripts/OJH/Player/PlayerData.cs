using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// PlayerData�� ���Ŀ� ������Ƽ ���� ����.
public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _jumpNum;    //mvp���� ����

    public int JumpNum { get {return _jumpNum; } set { _jumpNum = value; } }
    
    [SerializeField] private int _fallNum;  //mvp���� ����

    public int FallNum { get { return _fallNum; } set { _fallNum = value; } }

    [SerializeField] private float _jumpPower;

    public float JumpPower {  get { return _jumpPower; } set { _jumpPower = value; } }

    [SerializeField] private float _moveSpeed;

    public float MoveSpeed {  get { return _moveSpeed; }  set { _moveSpeed = value; } }

    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } } //���Ŀ� SaveData �ʰ� ������ ����.

    [SerializeField] private float _throwPower;

    public float ThrowPower { get { return _throwPower; } set { _throwPower = value; } }


}
