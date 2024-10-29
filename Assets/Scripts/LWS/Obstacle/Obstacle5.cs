using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5 : MonoBehaviour
{
    // �ݺ� �ֱ� (��)
    [SerializeField] float moveInterval;

    // �ӵ�
    [SerializeField] float speed;

    // �̵� ����
    [SerializeField] Vector3 dir;

    // �ʱ� ��ġ
    [SerializeField] Vector3 startPos;

    // �÷��̾ �о ���� ũ��
    [SerializeField] float pushForce;

    [SerializeField] bool movingOut;

    private void Start()
    {
        startPos = transform.position;
        StartCoroutine(RoutineObstacle());
    }

    private IEnumerator RoutineObstacle()
    {
        while (true)
        {
            // ��ǥ ��ġ ���
            Vector3 targetPosition = movingOut ? startPos + dir : startPos;

            // ��ǥ ��ġ���� �̵�
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                yield return null;
            }

            movingOut = !movingOut;

            yield return new WaitForSeconds(moveInterval);
        }
    }

    public void PushPlayer(PlayerController player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            Vector3 pushDirection = (player.transform.position - transform.position).normalized;
            playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
