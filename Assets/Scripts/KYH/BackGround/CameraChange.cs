using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;

public class CameraChange : MonoBehaviour
{
    // GameSceneManager Ŭ���� ������
    [SerializeField] private GameSceneManager _gameSceneManager;

    // �������� �� ��� ��ī�̹ڽ� ���͸��� ����� �迭
    [SerializeField] private Material[] _skyMaterials;

    Coroutine _cameraRoutine;

    private void Start()
    {
        // ���� ī�޶� 0��° VirtualCamera�� ����
        _gameSceneManager.Cameras[0].gameObject.SetActive(true);

        // ù��° ī�޶� �̿��� VirtualCamera Priority ���� 0���� �����Ͽ� 0��° ī�޶�� �����ϰ� ����
        for (int i = 0; i < _gameSceneManager.Cameras.Length - 1; i++)
        {
            _gameSceneManager.Cameras[i + 1].gameObject.SetActive(false);
        }

        // CharacterNum �������� 0��° �׸��� ���� ���� ó��
        if ((int)DataManager.Instance.SaveData.GameData.CharacterNum == 0)
            return;

        // ó�� ��ī�̹ڽ��� ���͸��� ����
        RenderSettings.skybox = _skyMaterials[0];
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    int index = 0;
    //    float cameraHeight = Camera.main.orthographicSize;
    //
    //    if (collider.gameObject.tag == "Base" || collider.gameObject.tag == "Stone"
    //        || collider.gameObject.tag == "Jumper")
    //    {
    //        if (_gameSceneManager.CurrentPlayerPos.y > gameObject.transform.position.y)
    //        {
    //            _gameSceneManager.Cameras[index].Priority = 0;
    //            _gameSceneManager.Cameras[index + 1].Priority = 2;
    //            index++;
    //        }
    //        else if (_gameSceneManager.CurrentPlayerPos.y < gameObject.transform.position.y)
    //        {
    //            _gameSceneManager.Cameras[index].Priority = 2;
    //            _gameSceneManager.Cameras[index + 1].Priority = 0;
    //            index--;
    //        }
    //    }        
    //}

   //IEnumerator CameraRoutine()
   //{
   //
   //}

    private void LateUpdate()
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

                _gameSceneManager.Cameras[i].gameObject.SetActive(false);      // i��° ī�޶��� Priority���� 0���� �����Ͽ� �ļ����� ����
                _gameSceneManager.Cameras[i + 1].gameObject.SetActive(true);  // i + 1��° ī�޶��� Priority���� 2�� �����Ͽ� �켱 ������ ����
            }
            // �÷��̾��� y��ǥ���� i��° ī�޶��� ���� ��輱 ������ ���� ���
            else if (_gameSceneManager.CurrentPlayerPos.y <= _gameSceneManager.Cameras[i].transform.position.y + cameraHeight)
            {

                // i��° ī�޶��� Priority���� 1�� �����Ͽ� �켱 ������ ����
                _gameSceneManager.Cameras[i].gameObject.SetActive(true);

                // i�� (VirtualCamera ����� �迭�� - 1)�� �ƴ� ��쿡 ���� ���� ����
                if (i != _gameSceneManager.Cameras.Length - 1)
                {
                    // i + 1��° ī�޶��� Prioriy���� 0���� �����Ͽ� �ļ����� ����
                    _gameSceneManager.Cameras[i + 1].gameObject.SetActive(false);
                }
                break;
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

