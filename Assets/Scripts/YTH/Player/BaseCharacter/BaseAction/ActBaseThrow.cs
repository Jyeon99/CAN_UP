using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Progress;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] Item _item;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) == null) // ��Ŭ�� ����, ��Ŭ�� ���� ���°� �ƴ� ��
            {
                ThrowItem();
            }
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }

    }

    private void ThrowItem()
    {
        // ���콺 ��ġ�� �������� Ray ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // ������dmf ���콺 �������� ��ġ�� ����
            Vector3 throwDirection = (hit.point - transform.position).normalized;
            _item.GetComponent<Rigidbody>().AddForce(throwDirection * _data.ThrowPower, ForceMode.Impulse);
        }
    }
}
