using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle01 : MonoBehaviour
{
    [SerializeField] PlayerData _data;

    public void AddJumpForce(PlayerController player)
    {
        // �׽�Ʈ�� �� �����غ� ��

        // �÷��̾� ������Ʈ�� null�̰ų� �÷��̾ StoneCharacter�� ��� ����ó��
        if (player == null || player.gameObject.name == "StoneCharacter")
            return;

        // OnTriggerStay ���� JumpPower�� 2�� ����
        _data.JumpPower *= 2;
    }
}
