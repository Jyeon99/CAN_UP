using System.Collections;
using UnityEngine;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] GameObject _item;

    [SerializeField] Animator _animator;

    [SerializeField] Transform throwPoint;
    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && _data.IsReadyToThrow == true) // ���콺 ��Ŭ���� ���� �������� ����
        {
            throwRoutine = StartCoroutine(ThrowRoutine());
            _data.IsReadyToThrow = false;
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    public void ThrowItem()
    {
        Vector3 _mousePos = Input.mousePosition;
        _mousePos.z = Camera.main.WorldToScreenPoint(throwPoint.position).z;

        Vector3 _worldMousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        _worldMousePos.z = throwPoint.position.z; // Z�� ����

        // ���� ���� ��� (X, Y�ุ ���)
        Vector3 _throwDirection = (_worldMousePos - transform.position).normalized;
        _throwDirection.z = 0; // Z���� 0���� ����

        if (_worldMousePos.x > transform.position.x) // ���� �������� �Ĵٺ�
        {
            transform.forward = Vector3.right;
        }
        else
        {
            transform.forward = Vector3.left;
        }

        Rigidbody _itemRb = _item.GetComponent<Rigidbody>();                                  // ���� ��� Ȱ��ȭ�Ͽ� ������ ���
        Collider _collider = _item.GetComponent<Collider>();                                  //
        _item.transform.SetParent(null);                                                      //
        _itemRb.isKinematic = false;                                                          //
        _collider.enabled = true;                                                             //
        _collider.isTrigger = true;                                                           // 
        _itemRb.AddForce(_throwDirection * _data.ThrowPower, ForceMode.Impulse);               //

        _data.HasItem = false;
    }

    Coroutine throwRoutine;
    IEnumerator ThrowRoutine() // AddForce�� �ִϸ��̼� ��ũ ���߱� ���� �ڷ�ƾ
    {
        WaitForSeconds dealy = new(0.5f);

        _animator.SetTrigger("Throw");
        yield return dealy;
        ThrowItem();
        throwRoutine = null;
    }
}
