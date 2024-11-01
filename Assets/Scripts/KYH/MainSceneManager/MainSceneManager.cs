using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneManager : UIBInder
{
    // SceneChanger Ŭ���� ������
    [SerializeField] private SceneChanger _sceneChanger;

    // ���۹� ����� �̹��� ������Ʈ
    [SerializeField] private GameObject _explainImage;

    // ���۹� ����� �̹��� Ȱ��ȭ ���� üũ
    [SerializeField] private bool _isImageActive;

    [SerializeField] private ECharacterNum _characterNum;

    private void Awake()
    {
        BindAll();
    }

    private void Start()
    {
        //GetUI<Image>("CharacterText").gameObject.SetActive(false);

        // ���� �÷��� ��ư Ŭ�� �̺�Ʈ
        AddEvent("NewPlay Button", EventType.Click, NewGameStart);

        // ���� �÷��� ��ư Ŭ�� �̺�Ʈ
        AddEvent("LoadPlay Button", EventType.Click, LastGameStart);

        // ĳ���� ����(������) ��ư Ŭ�� �̺�Ʈ
        AddEvent("Character_Right", EventType.Click, NextCharacter);

        // ĳ���� ����(����) ��ư Ŭ�� �̺�Ʈ
        AddEvent("Character_Left", EventType.Click, PreviousCharacter);

        // ���۹� ���� ��ư Ŭ�� �̺�Ʈ
        AddEvent("Explain Button", EventType.Click, ShowHowToPlay);

        // ������ ��ư Ŭ�� �̺�Ʈ
        AddEvent("Exit Button", EventType.Click, QuitGame);
    }

    private void Update()
    {
        // ���۹� ���� �̹����� Ȱ��ȭ �Ǿ��ִ� ���¿��� ESC Ű�� �Է����� ���
        if (_isImageActive = true && Input.GetKeyDown(KeyCode.Escape))
        {
            // ���۹� ���� �̹��� ������Ʈ ��Ȱ��ȭ
            GetUI<Image>("ExplainImage").gameObject.SetActive(false);
            // �̹��� Ȱ��ȭ üũ ���� false�� ����
            _isImageActive = false;
        }
    }

    // �� ���� ���� ��ư
    public void NewGameStart(PointerEventData eventData)
    {
        DataManager.Instance.ResetData();       // ����� ���� ���� ������ ����
        DataManager.Instance.SaveData.GameData.CharacterNum = (int)_characterNum;
        _sceneChanger.ChangeScene("GameScene"); // ȭ���� GameScene���� ��ȯ
    }

    // ����� ���� ���۹�ư
    public void LastGameStart(PointerEventData eventData)
    {
        DataManager.Instance.Load();
        _sceneChanger.ChangeScene("GameScene"); // ȭ���� GameScene���� ��ȯ
    }

    // ���� ���۹� �ȳ� ��ư
    public void ShowHowToPlay(PointerEventData eventData)
    {
        GetUI<Image>("ExplainImage").gameObject.SetActive(true);
        //_explainImage.SetActive(true);  // ���۹� ���� �̹��� ������Ʈ�� Ȱ��ȭ
        _isImageActive = true;          // �̹��� Ȱ��ȭ ���θ� true�� üũ
    }

    // ���� ĳ���� ���� ��ư
    public void NextCharacter(PointerEventData eventData)
    {
        if (_characterNum == ECharacterNum.Length - 1)
            return;

        _characterNum++;

        switch (_characterNum)
        {
            case ECharacterNum.Base:
                Debug.Log("Base");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Base";
                break;

            case ECharacterNum.Stone:
                Debug.Log("Stone");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Stone";
                break;

            case ECharacterNum.Jump:
                Debug.Log("Jump");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Jump";
                break;
        }
    }

    // ���� ĳ���� ���� ��ư
    public void PreviousCharacter(PointerEventData eventData)
    {
        if (_characterNum == ECharacterNum.Base)
            return;

        _characterNum--;

        switch (_characterNum)
        {
            case ECharacterNum.Base:
                Debug.Log("Base");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Base";
                break;

            case ECharacterNum.Stone:
                Debug.Log("Stone");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Stone";
                break;

            case ECharacterNum.Jump:
                Debug.Log("Jump");
                GetUI<TextMeshProUGUI>("CharacterText").text = "Jump";
                break;
        }
    }

    // ���� ���̵� ���� ��ư
    public void NextDifficulty(PointerEventData eventData)
    {
        // ���� ���̵� ���ߵǸ� �߰� �ۼ�
    }

    // ���� ���̵� ���� ��ư
    public void PreviousDifficulty(PointerEventData eventData)
    {
        // ���� ���̵� ���ߵǸ� �߰� �ۼ�
    }

    // ���� ���� ��ư
    public void QuitGame(PointerEventData eventData)
    {
        _sceneChanger.QuitGame();   // SceneChanger���� ���� ���� �Լ� ȣ��
    }
}
