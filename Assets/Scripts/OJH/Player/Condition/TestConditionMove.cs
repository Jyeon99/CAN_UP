using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConditionMove : PlayerCondition
{
    [SerializeField]private float power;
    public override bool DoCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            power += Time.deltaTime;
            Debug.Log("�����̽��� ������ ��");
            return true;
        }
        else
        {
            power = 0;
            Debug.Log("�����̽��� �ȴ���");
            return false;
        }
    }
}
