using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondBaseHasItem : PlayerCondition
{
    [SerializeField] BaseData _data;

    public override bool DoCheck()
    {
        if (_data.HasItem == true)
        {
            Debug.Log("������ ��� ���� + ������ ���� Ȯ��");
            return true;
        }
        else
        {
            Debug.Log("������ ��� ���� + ������ ���� X");
            return false;
        }
    }
}
