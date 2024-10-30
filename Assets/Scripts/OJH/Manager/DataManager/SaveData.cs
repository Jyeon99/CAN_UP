using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameData
{
    // Player�� Normal Level�� ������, ���ٸ� ĳ���� �ع��� ���� ����.
    [SerializeField] private bool _isClear;

    public bool IsClear { get {return _isClear;} set { _isClear = value; } }

    [SerializeField] private int _characterNum;

    public int CharacterNum { get { return _characterNum; } set { _characterNum = value; } }

    //���� �÷��̾ ��ġ�� Stage
    [SerializeField] private int _playerStage;

    public int PlayerStage {  get { return _playerStage; } set { _playerStage = value; } }

    //�������� �����ϰ� �ִ���
    [SerializeField] private bool _hasItem;

    public bool HasItem { get { return _hasItem; } set { _hasItem = value; } }

    //�������� ��� ���������� �����ϰ��ִ���
    // ���� �����ϰ����� �ʴ»��¿���, PlayerStage�� ItemStage�� �ٸ��ٸ� ������ ��ġ�� PlayerStage�� SavePOint�� �̵�
    // �����ϰ� �ִ� ���¸� Player��ġ�� ����.
    [SerializeField] private int _itemStage;

    public int ItemStage { get { return _itemStage; } set { _itemStage = value; } }

    //���� Ƚ�� mvp ���� ����
    [SerializeField] private int _jumpTime;

    public int JumpTime {  get { return _jumpTime; } set { _jumpTime = value; OnJumpTimeChange?.Invoke(); } }

    //������ Ƚ�� mvp ���� ����
    [SerializeField] private int _fallTime;

    public int FallTime { get { return _fallTime; } set { _fallTime = value; OnFallTimeChange?.Invoke(); } }

    //�÷��� �ð� ex) 00:00:00  mvp ���� ����
    [SerializeField] private float _playTime;

    public float PlayTime { get { return _playTime; } set { _playTime = value; OnPlayTimeChange?.Invoke(); } }

    public event UnityAction OnJumpTimeChange;

    public event UnityAction OnFallTimeChange;

    public event UnityAction OnPlayTimeChange;
}

[CreateAssetMenu(menuName = "ScriptableObjects/SaveData")]
public class SaveData : ScriptableObject
{
    [SerializeField] private GameData _gameData;
    public GameData GameData { get { return _gameData; } set { _gameData = value; } }
}