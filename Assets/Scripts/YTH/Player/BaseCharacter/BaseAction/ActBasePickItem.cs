using System.Collections;
using UnityEngine;

public class ActBasePickItem : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] Transform _handPosition; // �������� �� ��ġ(��)

    [SerializeField] GameObject _item;

    [SerializeField] Animator _animator;

    public override BTNodeState DoAction()
    {
        float distance = Vector3.Distance(transform.position, _item.transform.position);

        if (Input.GetKeyDown(KeyCode.Mouse0) && distance <= _data.PickUpRange) // ĳ���Ϳ� �������� ����� �� ��Ŭ�� �Է� ��
        {
            pickRoutine = StartCoroutine(PickRoutine());                       // �������� �ֿ�
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    Coroutine pickRoutine;
    IEnumerator PickRoutine()
    {
        WaitForSeconds dealy = new(0.4f);
        _animator.SetTrigger("PickItem");
        yield return dealy;

        //������ �ֿ��� �� ���̰� �ٴϴ� ���
        _item.transform.position = _handPosition.position;
        _item.transform.SetParent(_handPosition);
        _item.transform.localPosition = Vector3.zero;
        pickRoutine = null;

        yield return dealy;
        _data.HasItem = true;
    }
}
