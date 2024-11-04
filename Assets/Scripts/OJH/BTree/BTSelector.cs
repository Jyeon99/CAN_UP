using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ù ������ Ȯ��, �����ϰų� Running ���� ��尡 �ִٸ� �ٷ� ����. �ϳ��� ���ٸ� Failure ����.
public class BTSelector : BTNode
{
    private BTNode _lastRunningNode;
    public override BTNodeState Evaluate()
    {
        if (_lastRunningNode != null)
        {
            if ((_lastRunningNode.Evaluate() == BTNodeState.Success))
            {
                return BTNodeState.Success;
            }
            else if ((_lastRunningNode.Evaluate() == BTNodeState.Running))
            {
                return BTNodeState.Running;
            }
        }

        foreach (BTNode node in _children)
        {
            BTNodeState result = node.Evaluate();
            if (result == BTNodeState.Success)
            {
                _lastRunningNode = node;
                return BTNodeState.Success;
            }
            else if (result == BTNodeState.Running)
            {
                _lastRunningNode = node;
                return BTNodeState.Running;
            }
        }

        return BTNodeState.Failure;
    }
}
