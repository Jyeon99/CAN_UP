using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle10 : MonoBehaviour, IResetObject
{
    // reset()�� ����ϱ� ���� ���� ��ġ ���� ����
    [SerializeField] Vector3 _startPos;

    // ������ ��������� ���� Ȯ�ο� ����
    [SerializeField] bool _isPlatformDestroyed;

    [SerializeField] private int _stageNum;
    public int StageNum { get; set; }

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

    private void DestroyPlatform()
    {
        gameObject.SetActive(false);
        _isPlatformDestroyed = true;
    }

    public void Reset()
    {
        transform.position = _startPos;
        gameObject.SetActive(true);
        _isPlatformDestroyed= false;
    }
}