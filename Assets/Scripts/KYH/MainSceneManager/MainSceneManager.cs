using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    // SceneChanger Ŭ���� ������
    [SerializeField] private SceneChanger _sceneChanger { get; }

    // SaveData Ŭ���� ������
    [SerializeField] private GameData _gameData { get; set; }

    // DataManager Ŭ���� ������
    [SerializeField] private DataManager _dataManager { get; }

    // ���۹� ����� �̹��� ������Ʈ
    [SerializeField] private GameObject _explainImage;

    // ���۹� ����� �̹��� Ȱ��ȭ ���� üũ
    [SerializeField] private bool _isImageActive;

    // ���� ���̵� ǥ�� �ؽ�Ʈ ���� �迭
    [SerializeField] private GameObject[] _difficultyTexts;

    // ���� ĳ���� ǥ�� �ؽ�Ʈ ���� �迭
    [SerializeField] private GameObject[] _characterTexts;

    private void Start()
    {
        _difficultyTexts[0].SetActive(false);
        _difficultyTexts[1].SetActive(true);
        _difficultyTexts[2].SetActive(false);
        _explainImage.SetActive(false); // ���۹� ���� �̹��� ������Ʈ�� ��Ȱ��ȭ
        _isImageActive = false;         // �̹��� Ȱ��ȭ ���θ� false�� üũ
    }

    private void Update()
    {
        // ���۹� �̹����� Ȱ��ȭ �Ǿ� �����鼭 ESC Ű�� �Է����� ���
        if (_isImageActive == true && Input.GetKeyDown(KeyCode.Escape))
        {
            _explainImage.SetActive(false); // ���۹� ���� �̹��� ������Ʈ�� ��Ȱ��ȭ
            _isImageActive = false;         // �̹��� Ȱ��ȭ ���θ� false�� üũ
        }
    }

    // �� ���� ���� ��ư
    public void NewGameStart()
    {
        _dataManager.ResetData();               // ����� ���� ���� ������ ����
        _sceneChanger.ChangeScene("GameScene"); // ȭ���� GameScene���� ��ȯ
    }

    // ���� ���� ���� ���� ��ư
    public void LastGameStart()
    {
        // ����� ������ �ҷ��;� �ϱ� ������ ������ ���� ���ʿ�
        _sceneChanger.ChangeScene("GameScene"); // ȭ���� GameScene���� ��ȯ
    }

    // ���� ���۹� �ȳ� ��ư
    public void ShowHowToPlay()
    {
        _explainImage.SetActive(true);  // ���۹� ���� �̹��� ������Ʈ�� Ȱ��ȭ
        _isImageActive = true;          // �̹��� Ȱ��ȭ ���θ� true�� üũ
    }

    // ���� ĳ���� ���� ��ư
    public void NextCharacter()
    {
        if (_gameData.IsClear == false)
            return;


    }

    // ���� ĳ���� ���� ��ư
    public void PreviousCharacter()
    {

    }

    // ���� ���̵� ���� ��ư
    public void NextDifficulty()
    {

    }

    // ���� ���̵� ���� ��ư
    public void PreviousDifficulty()
    {

    }

    // ���� ���� ��ư
    public void QuitGame()
    {
        _sceneChanger.QuitGame();   // SceneChanger���� ���� ���� �Լ� ȣ��
    }
}
