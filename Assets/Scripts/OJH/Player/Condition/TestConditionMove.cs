using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConditionMove : PlayerCondition
{
    public override bool DoCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("�����̽��� ������ ��");
            return true;
        }
        else
        {
            Debug.Log("�����̽��� �ȴ���");
            return false;
        }
    }
}
