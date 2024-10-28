using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//BTNode ����
public enum BTNodeState
{
    Success,
    Failure,
    Running
}
//BTNode �⺻ ����
public abstract class BTNode 
{
    // �ڽĳ��� �����ϴ� ����
    protected List<BTNode> _children = new List<BTNode>();

    // �ڽ� �߰��ϴ� �Լ�
    public void AddChild(BTNode node)
    {
        _children.Add(node);
    }

    // ��� ���� �Լ�
    public abstract BTNodeState Evaluate();
}
