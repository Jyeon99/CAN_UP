using UnityEngine;

public class ActBaseThrow : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] GameObject _item;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            ThrowItem();
            return BTNodeState.Success;
        }
        else
        {
            Debug.Log("������ ��� ���� + ������ ���� Ȯ�� + ������ ���� �غ� �Ϸ�");
            return BTNodeState.Failure;
        }

    }

    private void ThrowItem()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // ���콺 ��ġ�� �������� Ray ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���� ���� ����
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.forward * 100f, Color.red);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log("����ĳ��Ʈ!");
        }

        // ������ ���콺 �������� ����
        Vector3 throwDirection = (hit.point - transform.position).normalized;

        // ��Ȱ��ȭ�� ���� �ۿ� Ȱ��ȭ�Ͽ� ����
        Rigidbody _itemRb = _item.GetComponent<Rigidbody>();
        Collider _collider = _item.GetComponent<Collider>();
        _item.transform.SetParent(null);
        _itemRb.isKinematic = false;
        _collider.enabled = true;
        _itemRb.AddForce(throwDirection * _data.ThrowPower, ForceMode.Impulse);
    }
}
