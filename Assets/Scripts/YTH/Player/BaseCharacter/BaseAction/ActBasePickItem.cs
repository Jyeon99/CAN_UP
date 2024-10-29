using UnityEngine;

public class ActBasePickItem : PlayerAction
{
    [SerializeField] BaseData _data;

    [SerializeField] public Transform _handPosition; // �������� �� ��ġ(��)

    [SerializeField] private GameObject _item;

    public override BTNodeState DoAction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // ��Ŭ�� �Է� ��
        {
            return BTNodeState.Success;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            _data.HasItem = true;

            //������ �ֿ��� �� �� ���̰� �ٴϴ� ���
            _item.transform.position = _handPosition.position;
            _item.transform.rotation = _handPosition.rotation;
            _item.transform.SetParent(_handPosition);
            _item.transform.localPosition = Vector3.zero;
            

        }
    }
}
