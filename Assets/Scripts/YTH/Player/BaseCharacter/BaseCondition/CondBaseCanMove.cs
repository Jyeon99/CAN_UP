using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Rigidbody _rigidbody;

    public override bool DoCheck()
    {
        Debug.Log("�۵� 1");
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _data.GroundCheckDistance))
        {
            if (hitInfo.collider.CompareTag("Ground"))
            {
                Debug.Log(_data.IsGrounded);
                _data.IsGrounded = false;
                return true;
            }
        }

        if (_data.IsStiff == true || _data.IsGrounded == false) //������ ����   //�׳� ���߿� �ִ� ���µ� üũ �ʿ�
        {
            Debug.Log("���� �Ұ� ! ");
            return false;
        }
        else
        {
            Debug.Log("���� ���� ! ");
            return true;
        }
    }
}
