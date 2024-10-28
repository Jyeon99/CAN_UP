using UnityEngine;

public class CondBaseCanMove : PlayerCondition
{
    [SerializeField] BaseData _baseData;

    [SerializeField] Rigidbody _rigidbody;

    public LayerMask Ground;

    public float groundCheckDistance = 0.1f; // �ٴ� ���� �Ÿ�


    public override bool DoCheck()
    {
        if (_baseData.IsStiff == true /*|| isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer)*/)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
