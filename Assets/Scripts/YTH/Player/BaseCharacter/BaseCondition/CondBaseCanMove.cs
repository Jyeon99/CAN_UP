using Unity.VisualScripting;
using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Rigidbody _rigidbody;

    public override bool DoCheck()
    {
        Debug.Log("�۵� ��");

        if (_data.IsStiff == true || _data.IsGrounded == false) //���������� ������ ����
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _data.IsGrounded = true;
        }
    }
}
