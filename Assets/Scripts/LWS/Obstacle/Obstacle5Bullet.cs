using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5Bullet : MonoBehaviour
{
    // �ε����� �� �÷��̾ �� ��
    [SerializeField] private float pushForce;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void PushPlayer(PlayerController player)
    {
        // �÷��̾��� rigid�� ������
        Rigidbody rigid = player.GetComponent<Rigidbody>();

        Vector3 pushDir = (rigid.transform.position - transform.position).normalized;
        rigid.AddForce(pushDir * pushForce, ForceMode.Impulse);
    }

    public void PushPlayer(Item item)
    {
        // �÷��̾��� rigid�� ������
        Rigidbody rigid = item.GetComponent<Rigidbody>();

        Vector3 pushDir = (rigid.transform.position - transform.position).normalized;
        rigid.AddForce(pushDir * pushForce, ForceMode.Impulse);
    }
}
