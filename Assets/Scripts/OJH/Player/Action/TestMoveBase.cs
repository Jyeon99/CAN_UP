using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveBase : PlayerAction
{

    public override BTNodeState DoAction()
    {
        Debug.Log("������!");
        return BTNodeState.Running;
    }

}
