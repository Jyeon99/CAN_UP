using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObstacle : MonoBehaviour
{
    // ��ȹ�� �� �Ǳ׸� ���� ������� �ν�����â�� ���̵��� ���� ����.
    public void TouchPlayer(PlayerController player)
    {
        Transform playerTransform = player.GetComponent<Transform>();
        Debug.Log(playerTransform.position);
    }
}
