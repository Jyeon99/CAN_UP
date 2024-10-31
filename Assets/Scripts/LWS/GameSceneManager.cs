using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // ���̺� ����Ʈ �迭
    [SerializeField] private Vector3[] _savePoints;

    // �������� ���� �迭
    [SerializeField] private float[] _stageHight;

    // ī�޶� �迭
    [SerializeField] private CinemachineVirtualCamera[] _camera;

    // ���� �÷��̾� ������
    [SerializeField] private Vector3 _currentPlayerPos;

    // ���� ��������
    [SerializeField] private int _currentStage;

    // ���� ����� ��������
    [SerializeField] private int _currentSaveStage;

    // ������
    [SerializeField] private GameObject _item;

    // ĳ���͵�
    [SerializeField] private GameObject[] _players;

    // ���� ��͵�
    [SerializeField] private IResetObject[] _resetObjects;

    // ��ü ��͵�
    [SerializeField] private IReplaceObstacle[] _replaceObstacles;


    private void CheckResetObject()
    {
        // checkstate int
        // int >> �̸� ���� _preCameraIndex;
        // int >> ��� ���� _curCameraIndex; 
    }
}
