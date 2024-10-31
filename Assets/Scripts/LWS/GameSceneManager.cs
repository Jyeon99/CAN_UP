using Cinemachine;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSceneManager : UIBInder
{
    private StringBuilder _sb = new StringBuilder();

    // ���̺� ����Ʈ �迭
    [SerializeField] private Vector3[] _savePoints;
    public Vector3[] SavePoints { get { return _savePoints; } set { _savePoints = value; } }

    // �������� ���� �迭
    [SerializeField] private float[] _stageHight;
    public float[] StageHight { get { return _stageHight; } set { _stageHight = value; } }

    // ī�޶� �迭
    [SerializeField] private CinemachineVirtualCamera[] _cameras;
    public CinemachineVirtualCamera[] Cameras { get { return _cameras; } set { _cameras = value; } }

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

    // �ó׸ӽ� �극�� �̺�Ʈ �Լ��� Ȱ���� �ó׸ӽ� �극��
    [SerializeField] private CinemachineBrain _brain;
    public CinemachineBrain Brain { get { return _brain; } set { _brain = value; } }

    // esc ���� �� ���� �г�
    [SerializeField] private GameObject _escPanel;

    public GameObject EscPanel { get { return _escPanel; } set { _escPanel = value; } }

    // ��ü����
    [SerializeField] private SceneChanger _sceneChanger;

    public SceneChanger SceneChanger { get { return _sceneChanger; } set { _sceneChanger = value; } }

    private void Awake()
    {
        _brain = Camera.main.GetComponent<CinemachineBrain>();
        BindAll();
    }

    private void OnEnable()
    {
        DataManager.Instance.SaveData.GameData.OnJumpTimeChange += UpdateJumpTime;
        DataManager.Instance.SaveData.GameData.OnFallTimeChange += UpdateFallTime;
        DataManager.Instance.SaveData.GameData.OnPlayTimeChange += UpdatePlayTime;
    }

    private void OnDisable()
    {
        DataManager.Instance.SaveData.GameData.OnJumpTimeChange -= UpdateJumpTime;
        DataManager.Instance.SaveData.GameData.OnFallTimeChange -= UpdateFallTime;
        DataManager.Instance.SaveData.GameData.OnPlayTimeChange -= UpdatePlayTime;
    }

    private void Start()
    {
        AddEvent("ResumeButton", EventType.Click, ResumeGame);
        AddEvent("SaveExitButton", EventType.Click, SaveAndQuitGame);
        AddEvent("MainButton", EventType.Click, GiveUpGame);

        SetGame(DataManager.Instance);
    }



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _escPanel.SetActive(true);
        }

        CheckState(DataManager.Instance);
    }

   

    private void SetGame(DataManager dataManager)
    {
        // 0. �ʱ�ȭ �Ǿ�� �ϴ� �⺻ ����
        _item.transform.position = _savePoints[1];

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
        // 0. ��� ���ŵǾ�� �ϴ� �⺻ ����
        // ���� ������
        _currentPlayerPos = _players[dataManager.SaveData.GameData.CharacterNum].transform.position;

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
        if (_currentSaveStage > _currentStage)
        {
            _currentSaveStage = _currentStage;
        }

        // 3. CheckResetObject
        CheckResetObject();

        // 4. Item��ġ üũ �� ����
        if (!dataManager.SaveData.GameData.HasItem)
        {
            if (_item.transform.position.y < _stageHight[_currentStage])
            {
                _item.transform.position = _savePoints[_currentStage];
            }
        }
    }

    private void ResumeGame(PointerEventData eventData)
    {
        Time.timeScale = 1;
        _escPanel.SetActive(false);
    }

    private void SaveAndQuitGame(PointerEventData eventData)
    {
        DataManager.Instance.SaveData.GameData.IsClear = false;
        DataManager.Instance.SaveData.GameData.PlayerStage = _currentStage;
        DataManager.Instance.SaveData.GameData.HasItem = false;
        DataManager.Instance.SaveData.GameData.ItemStage = _currentStage;
        //DataManager.Instance.SaveData.GameData.PlayTime;
        Application.Quit();
    }

    private void GiveUpGame(PointerEventData eventData)
    {
        _sceneChanger.ChangeScene("MainScene");
        _escPanel.SetActive(false);
    }

    // �ó׸ӽ� �극�� �̺�Ʈ �Լ� �����ؼ� ī�޶� ����� �� ���� Reset()
    private void CheckResetObject()
    {
        _brain.m_CameraActivatedEvent.AddListener(Reset1);

        void Reset1(ICinemachineCamera forecamera, ICinemachineCamera toCamera)
        {
            for (int i = 0; i < _resetObjects.Length; i++)
            {
                foreach (IResetObject j in _resetObjects)
                {
                    j.Reset();
                }
            }
        }
    }

    // ���� ĳ���Ͱ� Base�� �ƴ� ���, Replace�� �ʿ��� Obstacle�� ��ü ����
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

    private void UpdateJumpTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.JumpTime);
        GetUI<TextMeshProUGUI>("JumpTime").SetText(_sb);
    }
    private void UpdateFallTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.FallTime);
        GetUI<TextMeshProUGUI>("FallTime").SetText(_sb);
    }
    private void UpdatePlayTime()
    {
        _sb.Clear();
        _sb.Append(DataManager.Instance.SaveData.GameData.PlayTime);
        GetUI<TextMeshProUGUI>("PlayTime").SetText(_sb);
    }
}
