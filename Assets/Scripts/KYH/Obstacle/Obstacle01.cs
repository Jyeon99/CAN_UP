using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle01 : MonoBehaviour, IObjectPosition
{
    // BaseCharacter�� ������
    [SerializeField] BaseData _baseData;

    // ��ü ĳ������ ������
    [SerializeField] PlayerData _playerData;

    // Item�� ������
    [SerializeField] Item _itemData;

    // ��ȭ�� ���� ��ġ
    [SerializeField] float _jumpForce;

    // ���� ��ġ�� �����ߴ��� üũ��
    [SerializeField] private bool _isIncrease;

    // �������� ƨ��� ��ġ
    [SerializeField] private float _itemJumpPower;

    // �̸� ����
    [SerializeField] string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    // ĳ������ ���� ��ġ ���� �Լ�
    public void ForcedJump(PlayerController player)
    {
        // �̹� ���� ��ġ�� �������� ��츦 ���� ó��
        if (_isIncrease == true)
            return;

        // �÷��̾ BaseCharacter�� ���
        if (player.gameObject.tag == "Base")
        {
            _baseData = player.GetComponent<BaseData>();    // BaseCharacter�� �����͸� ����
            _baseData.MaxJumpPower += _jumpForce;                    // BaseCharacter�� �ִ� ����ġ�� 2�� ����
            _isIncrease = true;                             // ���� ��ġ�� �����ƴٰ� üũ
        }
        // �÷��̾ ������ ĳ���� �� �ϳ��� ���
        else
        {
            _playerData = player.GetComponent<PlayerData>();    // �÷��̾��� �����͸� ����
            _playerData.JumpPower += _jumpForce;                         // �÷��̾��� �������� 2�� ����
            _isIncrease = true;                                 // ���� ��ġ�� �����ƴٰ� üũ
        }
    }

    // �������� ��ó�� ƨ������ �Լ�
    public void BounceItem(Item item)
    {
        Rigidbody itemRigid = item.gameObject.GetComponent<Rigidbody>();        // �������� Rigidbody ������Ʈ ���� 
        itemRigid.AddForce(Vector3.up * _itemJumpPower, ForceMode.Impulse);     // �����ۿ��� ���� ���� ���Ͽ� ���� ƨ��� ��ó�� ����
    }

    // ĳ������ ���� ��ġ�� �����·� �ǵ����� �Լ�
    public void CancelJump(PlayerController player)
    {
        // �̹� ĳ������ ���� ��ġ�� �����·� �ǵ��ȴٸ� ���� ó��
        if (_isIncrease == false)
            return;

        // �÷��̾ BaseCharacter�� ���
        if (player.gameObject.tag == "Base")
        {
            _baseData = player.GetComponent<BaseData>();    // BaseCharacter�� �����͸� ����
            _baseData.MaxJumpPower -= 2;                    // BaseCharacter�� �ִ� ����ġ�� 1/2�� ����
            _isIncrease = false;                            // ���� ��ġ�� �����·� �ǵ��ƿԴٰ� üũ
        }
        // �÷��̾ ������ ĳ���� �� �ϳ��� ���
        else
        {
            _playerData = player.GetComponent<PlayerData>();    // �÷��̾��� �����͸� ����
            _playerData.JumpPower -= 2;                         // �÷��̾��� �ִ� ����ġ�� 1/2�� ����
            _isIncrease = false;                                // ���� ��ġ�� �����·� �ǵ��ƿԴٰ� üũ
        }
    }
}
