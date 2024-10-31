using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // ���̺� ����Ʈ �迭
    [SerializeField] private Vector3[] _savePoints;
    public Vector3[] SavePoints { get { return _savePoints; } set { _savePoints = value; } }

    // �������� ���� �迭
    [SerializeField] private float[] _stageHight;
    public float[] StageHight { get { return _stageHight; } set { _stageHight = value; } }

    // ī�޶� �迭
    [SerializeField] private CinemachineVirtualCamera[] _cameras;
    public CinemachineVirtualCamera[] Cameras { get { return _cameras; } set { _cameras = value; } }

    // ī�޶� ���� �ε���
    [SerializeField] private int _curCameraIndex;
    public int CurCameraIndex { get { return _curCameraIndex; } set { _curCameraIndex = value; } }

    // ī�޶� ���� �ε���
    [SerializeField] private int _preCameraIndex;
    public int PreCameraIndex { get { return _preCameraIndex; } set { _preCameraIndex = value; } }

    // ���� �÷��̾� ������
    [SerializeField] private Vector3 _currentPlayerPos;
    public Vector3 CurrentPlayerPos { get { return _currentPlayerPos; } set { _currentPlayerPos = value; } }

    // ���� ��������
    [SerializeField] private int _currentStage;
    public int CurrentStage { get { return _currentStage; } set { _currentStage = value; } }

    // ���� ����� ��������
    [SerializeField] private int _currentSaveStage;
    public int CurrentSaveStage { get { return _currentStage; } set { _currentStage = value; } }

    // ������
    [SerializeField] private GameObject _item;
    public GameObject Item { get { return _item; } set { _item = value; } }

    // ĳ���͵�
    [SerializeField] private GameObject[] _players;
    public GameObject[] Players { get { return _players; } set { _players = value; } }

    // ���� ��͵�
    [SerializeField] private IResetObject[] _resetObjects;
    public IResetObject[] ResetObjects { get { return _resetObjects; } set { _resetObjects = value; } }

    // ��ü ��͵�
    [SerializeField] private IReplaceObstacle[] _replaceObstacles;
    public IReplaceObstacle[] ReplaceObstacles { get { return _replaceObstacles; } set { _replaceObstacles = value; } }

    private void SetGame(DataManager dataManager)
    {
        // 1. ����� savestage ��������
        // ���� �������� �� ����� ���������� ����� playerStage�� ����
        _currentStage = dataManager.SaveData.GameData.PlayerStage;

        // ����� ĳ���͸� ���̺�����Ʈ�� ��ȯ
        _players[dataManager.SaveData.GameData.CharacterNum].transform.position = _savePoints[_currentSaveStage];

        // 2. Item ��ġ ��������
        if (dataManager.SaveData.GameData.CharacterNum == 1)
        {
            _item.transform.position = _players[dataManager.SaveData.GameData.CharacterNum].transform.position;
        }

        // 3. CheckReplaceObject ���� (?)
        CheckReplaceObstacle(dataManager);

        // 4. ĳ���� ��������
        _players[dataManager.SaveData.GameData.CharacterNum].SetActive(true);
    }
    private void CheckState(DataManager dataManager)
    {
        // 1. currentStage ����
        for (int i = 0; i < (int)EStage.Length; i++)
        {
            if (_stageHight[i] <= _players[dataManager.SaveData.GameData.CharacterNum].transform.position.y &&
                _players[dataManager.SaveData.GameData.CharacterNum].transform.position.y < _stageHight[i + 1])
            {
                _currentStage = i + 1;
                break;
            }
        }

        // 2. SavePoint ���� (?)
        if ( _currentSaveStage > _currentStage )
        {
            _currentSaveStage = _currentStage;
        }
        
        // 3. CheckResetObject
    }

    private void ResumeGame()
    {

    }

    private void SaveAndQuitGame()
    {

    }

    private void GiveUpGame()
    {

    }

    private void CheckResetObject()
    {

    }

    private void CheckReplaceObstacle(DataManager dataManager)
    {
        if (dataManager.SaveData.GameData.CharacterNum == 2 || dataManager.SaveData.GameData.CharacterNum == 3)
        {
            for (int i = 0; i < _replaceObstacles.Length; i++)
            {
                foreach (IReplaceObstacle j in _replaceObstacles)
                {
                    j.Replace();
                }
            }
        }
    }

    private void Awake()
    {

    }
}
