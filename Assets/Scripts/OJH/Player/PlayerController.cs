using System.Collections.Generic;
using UnityEngine;

public enum EBTType { Sequence, Selector, Parallel, BTAction, BTCondition }

// Node ����
[System.Serializable]
public class NodeData
{
    // ��Ʈ���� Ȯ���ϴ� ����
    public bool IsRoot;

    // ��� Ÿ��
    public EBTType NodeType;

    // ��� �̸�
    public string NodeName;

    // Action ����� ��� �ʿ�
    public PlayerAction PlayerAction;

    // Condition ����� ��� �ʿ�
    public PlayerCondition PlayerCondition;
}

//���� ����
[System.Serializable]
public class EdgeData
{
    // �θ� �� ��� �̸�
    public string ParentName;

    // ������ �ڽĵ� �̸�
    public string[] ChildNames;
}


public class PlayerController : MonoBehaviour
{
    // ��Ʈ ���
    private BTNode _root;

    // ���Ŀ� ������Ƚ�� �� ���� Ƚ�� MVP������ ���� PlayerData ����
    [SerializeField] private PlayerData _playerData;

    // ������
    [SerializeField] private NodeData[] _nodeDatas;

    // ������
    [SerializeField] private EdgeData[] _edgeDatas;


    //��� �����ϴ� ����
    private Dictionary<string, BTNode> _nodes = new Dictionary<string, BTNode>();

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _root.Evaluate();
        CheckJumpTime();
        CheckFallTime();
    }

    //��� ���� �� Ʈ�� ����
    private void Init()
    {
        for (int i = 0; i < _nodeDatas.Length; i++)
        {
            BTNode btNode = new BTSelector();

            bool isRoot = _nodeDatas[i].IsRoot;

            EBTType btType = _nodeDatas[i].NodeType;

            string btString = _nodeDatas[i].NodeName;

            PlayerAction playerAction = _nodeDatas[i].PlayerAction;

            PlayerCondition playerCondition = _nodeDatas[i].PlayerCondition;

            // ��� ����
            switch (btType)
            {
                case EBTType.Sequence:
                    btNode = new BTSequence();
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.Selector:
                    btNode = new BTSelector();
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.Parallel:
                    btNode = new BTParallel();
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.BTAction:
                    btNode = new BTAction(playerAction.DoAction);
                    _nodes.Add(btString, btNode);
                    break;
                case EBTType.BTCondition:
                    btNode = new BTCondition(playerCondition.DoCheck);
                    _nodes.Add(btString, btNode);
                    break;
            }

            if (isRoot == true)
            {
                _root = btNode;
            }

        }

        //Ʈ�� ����
        for (int j = 0; j < _edgeDatas.Length; j++)
        {
            if (_nodes.ContainsKey(_edgeDatas[j].ParentName) == false)
            {
                Debug.Log($"Cant Find {_edgeDatas[j].ParentName} Node");
            }
            else
            {
                BTNode ParentNode = _nodes[_edgeDatas[j].ParentName];

                for (int k = 0; k < _edgeDatas[j].ChildNames.Length; k++)
                {
                    if (_nodes.ContainsKey(_edgeDatas[j].ChildNames[k]) == false)
                    {
                        Debug.Log($"Cant Find {_nodes[_edgeDatas[j].ChildNames[k]]} Node");
                    }
                    else
                    {
                        BTNode CHildNode = _nodes[_edgeDatas[j].ChildNames[k]];
                        ParentNode.AddChild(CHildNode);
                        Debug.Log(ParentNode);
                        Debug.Log(CHildNode);

                    }
                }
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleCol")
        {
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractColEnter(this);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleCol")
        {
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractColStay(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleCol")
        {
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractColExit(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ObstacleTri")
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractTriEnter(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ObstacleTri")
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractTriStay(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ObstacleTri")
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            interactable.TargetInteractTriExit(this);
        }
    }

    void CheckJumpTime() //���� Ƚ��
    {
        //Base ĳ����
        if (Input.GetKeyUp(KeyCode.Space) && _playerData.IsGrounded == true && DataManager.Instance.SaveData.GameData.CharacterNum == (int)ECharacterNum.Base)
        {
            DataManager.Instance.SaveData.GameData.JumpTime++;
            Debug.Log(DataManager.Instance.SaveData.GameData.JumpTime);
        }

        //Stone ĳ����
        else if (_playerData.IsGrounded == false && DataManager.Instance.SaveData.GameData.CharacterNum == (int)ECharacterNum.Stone)
        {
            DataManager.Instance.SaveData.GameData.JumpTime++;
            Debug.Log(DataManager.Instance.SaveData.GameData.JumpTime);
        }

        //Jump ĳ����
        else if (_playerData.IsGrounded == false && DataManager.Instance.SaveData.GameData.CharacterNum == (int)ECharacterNum.Jump)
        {
            DataManager.Instance.SaveData.GameData.JumpTime++;
            Debug.Log(DataManager.Instance.SaveData.GameData.JumpTime);
        }

        
    }



    void CheckFallTime() // ������ Ƚ��
    {
        float _faillingTime = 0;

        if (_playerData.IsGrounded == false)
        {
            _faillingTime += Time.deltaTime; //ü�� �ð� üũ
        }
        else if (_playerData.IsGrounded == true)
        {
            _faillingTime = _faillingTime;

            if (_faillingTime > _playerData.CheckedTimeBase)   // (�Ʒ��� �ִ� ��������)�ִ� ���������� ���� ���� ���� ü���ð����ٱ������ ���Ϸ� ���� 
            {
                DataManager.Instance.SaveData.GameData.FallTime++; // ���� Ƚ�� +1
                Debug.Log(DataManager.Instance.SaveData.GameData.FallTime);
            }
        }

       
    }
}
