using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _data;

    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] float _dropRayPosY = 0.1f;
    public override bool DoCheck()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _dropRayPosY, transform.position.z);
        Ray ray = new Ray(pos, Vector3.down);

        Debug.Log("�����ɽ�Ʈ ����");
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            Debug.DrawRay(pos, Vector3.down * 0.3f, Color.red);
            if (hit.collider.CompareTag("Ground"))
            {
                _data.IsGrounded = true;
                return true;
            }
        }
        else
        {
            _data.IsGrounded = false;
        }


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
}
