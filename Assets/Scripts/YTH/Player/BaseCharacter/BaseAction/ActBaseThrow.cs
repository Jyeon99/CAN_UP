using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Progress;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] GameObject _item;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
           //if (Input.GetKeyUp(KeyCode.Mouse0) == false) // ��Ŭ�� ����, ��Ŭ�� ���� ���°� �ƴ� ��
           //{
                ThrowItem();
           // }
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

        if (Physics.Raycast(ray, out hit, 10f)) // 10f �Ÿ��� �׽�Ʈ�� ���� �ʿ�
        {
            // ������ ���콺 �������� ����
            Vector3 throwDirection = (hit.point - transform.position).normalized;

            // ��Ȱ��ȭ�� ���� �ۿ� Ȱ��ȭ�Ͽ� ����
            Rigidbody _itemRb = _item.GetComponent<Rigidbody>();
            _item.transform.SetParent(null);
            _itemRb.isKinematic = false;
            _itemRb.AddForce(throwDirection * _data.ThrowPower, ForceMode.Impulse);
        }
    }
}
