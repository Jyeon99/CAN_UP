using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] EnviromentManager _manager;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        StartCoroutine(CoBlendSkies());
    }

    // ��ī�̹ڽ� ���� �ڷ�ƾ
    // ����� ������Ÿ�� ������ ���� ���尡 �ƴ� �ܼ� ��ü�� �����
    private IEnumerator CoBlendSkies()
    {
        // �÷��̾��� y��ǥ���� ������ �̻��� ���
        // _manager.BlendEnviroment("������ �̸�", ��ȯ �ð�)
        if (_player.transform.position.y <= 15)
        {
            _manager.BlendEnviroment("Stage01", 2.0f);
        }
        else if (_player.transform.position.y <= 30)
        {
            _manager.BlendEnviroment("Stage02", 2.0f);
        }
        else if (_player.transform.position.y <= 45)
        {
            _manager.BlendEnviroment("Stage03", 2.0f);
        }
        else if (_player.transform.position.y <= 60)
        {
            _manager.BlendEnviroment("Stage04", 2.0f);
        }
        else if (_player.transform.position.y <= 75)
        {
            _manager.BlendEnviroment("Stage05", 2.0f);
        }
        yield return null;
    }
}
