using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle10 : MonoBehaviour
{
    // reset()�� ����ϱ� ���� ���� ��ġ ���� ����
    [SerializeField] Vector3 _startPos;

    // ������ ��������� ���� Ȯ�ο� ����
    [SerializeField] bool _isPlatformDestroyed;

    [SerializeField] float _respawnDelay;

    private void Start()
    {
        _startPos = transform.position;
        _isPlatformDestroyed = false;
    }

    public void Disappear(PlayerController player)
    {
        if (!_isPlatformDestroyed)
        {
            Invoke(nameof(DestroyPlatform), 1f);
        }
    }
    public void Disappear(Item item)
    {
        if (!_isPlatformDestroyed)
        {
            Invoke(nameof(DestroyPlatform), 1f);
        }
    }

    private void DestroyPlatform()
    {
        gameObject.SetActive(false);
        _isPlatformDestroyed = true;

        Invoke(nameof(ResetPlatform), _respawnDelay);
    }

    private void ResetPlatform()
    {
        gameObject.SetActive(true);
        _isPlatformDestroyed = false;
    }
}