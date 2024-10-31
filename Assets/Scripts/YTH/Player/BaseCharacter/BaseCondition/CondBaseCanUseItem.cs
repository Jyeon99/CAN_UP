using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondBaseCanUseItem : PlayerCondition
{
    [SerializeField] BaseData _data;

    public override bool DoCheck()
    {
        Debug.Log("Can use Item");
        if (_data.IsStiff == true)
        {
            Debug.Log("������ ��� �Ұ���");
            return false;
        }
        else
        {
            return true;
        }

    }
}
