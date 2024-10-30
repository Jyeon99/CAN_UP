using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// PlayerData�� ���Ŀ� ������Ƽ ���� ����.
[System.Serializable]
public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _jumpNum;    //mvp���� ����

    public int JumpNum { get { return _jumpNum; } set { _jumpNum = value; } }

    [SerializeField] private int _fallNum;  //mvp���� ����

    public int FallNum { get { return _fallNum; } set { _fallNum = value; } }

    [SerializeField] private float _jumpPower;

    public float JumpPower { get { return _jumpPower; } set { _jumpPower = value; } }

    [SerializeField] private bool _isGrounded;

    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }


    // ���� ����: ���� ��Ȳ, ��ֹ��� ���������� ��������
    //isStiff ������ ���� ��ֹ��� ���������� ������������ ���.             
    [SerializeField] private bool _isStiff;

    public bool IsStiff { get { return _isStiff; }  set { _isStiff = value; }  }



}
