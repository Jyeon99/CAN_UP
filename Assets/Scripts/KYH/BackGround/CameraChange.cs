using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    // GameSceneManager Ŭ���� ������
    [SerializeField] private GameSceneManager _gameSceneManager;

    // �������� �� ��� ��ī�̹ڽ� ���͸��� ����� �迭
    [SerializeField] private Material[] _skyMaterials;

    private void Start()
    {
        // ���� ī�޶� 0��° VirtualCamera�� ����
        _gameSceneManager.Cameras[0].Priority = 2;

        // ù��° ī�޶� �̿��� VirtualCamera Priority ���� 0���� �����Ͽ� 0��° ī�޶�� �����ϰ� ����
        for (int i = 0; i < _gameSceneManager.Cameras.Length - 1; i++)
        {
            _gameSceneManager.Cameras[i + 1].Priority = 0;
        }

        // CharacterNum �������� 0��° �׸��� ���� ���� ó��
        if ((int)DataManager.Instance.SaveData.GameData.CharacterNum == 0)
            return;

        // ó�� ��ī�̹ڽ��� ���͸��� ����
        RenderSettings.skybox = _skyMaterials[0];
    }

    private void Update()
    {
        // ī�޶��� ����/2 ���� ������ ����
        float cameraHeight = Camera.main.orthographicSize;
        Debug.Log($"Height : {cameraHeight}");

        // VirtualCamera ����� �ݺ���
        for (int i = 0; i < _gameSceneManager.Cameras.Length; i++)
        {
            // �÷��̾��� y��ǥ���� i��° ī�޶��� ���� ��輱���� ���� ���
            if (_gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.Cameras[i].transform.position.y + cameraHeight)
            {
                // i�� VirtualCamera ����� �迭������ Ŭ ��� ���� ó��
                if (i > _gameSceneManager.Cameras.Length)
                    return;

                _gameSceneManager.Cameras[i].Priority = 0;      // i��° ī�޶��� Priority���� 0���� �����Ͽ� �ļ����� ����
                _gameSceneManager.Cameras[i + 1].Priority = 2;  // i + 1��° ī�޶��� Priority���� 2�� �����Ͽ� �켱 ������ ����
            }
            // �÷��̾��� y��ǥ���� i��° ī�޶��� ���� ��輱 ������ ���� ���
            else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.Cameras[i].transform.position.y + cameraHeight)
            {

                // i��° ī�޶��� Priority���� 1�� �����Ͽ� �켱 ������ ����
                _gameSceneManager.Cameras[i].Priority = 2;

                // i�� (VirtualCamera ����� �迭�� - 1)�� �ƴ� ��쿡 ���� ���� ����
                if (i != _gameSceneManager.Cameras.Length - 1)
                {
                    // i + 1��° ī�޶��� Prioriy���� 0���� �����Ͽ� �ļ����� ����
                    _gameSceneManager.Cameras[i + 1].Priority = 0;
                }
                return;
            }
        }

        // ��ī�̹ڽ� ���͸��� ��ü�� �ݺ���
        for (int i = 0; i < _skyMaterials.Length; i++)
        {
            // ���� �÷��̾��� y��ǥ���� �������� ���氪���� ���� ���
            if (_gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.StageHight[i + 1]
                && _gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.StageHight[i + 2])
            {
                Debug.Log("sadgasdge");
                // i��°(���� ��������) ��ī�̹ڽ� ���͸���� ��ī�̹ڽ��� ����
                RenderSettings.skybox = _skyMaterials[i + 1];
                return;
            }
            //// ���� �÷��̾��� y��ǥ���� �������� ���氪 ������ ���
            //else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.StageHight[i + 1]
            //    && _gameSceneManager.CurrentPlayerPos.y > _gameSceneManager.StageHight[i + 2])
            //{
            //    // i - 1��°(���� ��������) ��ī�̹ڽ� ���͸���� ��ī�̹ڽ��� ����
            //    RenderSettings.skybox = _skyMaterials[i];
            //}
        }
    }
}

