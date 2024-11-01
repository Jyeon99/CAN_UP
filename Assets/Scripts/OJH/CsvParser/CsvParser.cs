using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class CsvParser : MonoBehaviour
{

    [SerializeField] private GameObject[] _gameObjects;

    //�ӽÿ�
    //private Vector3[] _positions = { new Vector3(1, 1, 0), new Vector3(1, 1, 2) };
    //private string[] _names = { "OBstacle1", "Obstacle2" };

    private StringBuilder _sb = new StringBuilder();

    private string _savePath;

    private void Awake()
    {
        // ������ user/appdata/LocalLow/Can_Up/Save
        _savePath = Application.persistentDataPath + "/Save";
        CreateCsv();
    }

    [ContextMenu("Save")]
    private void CreateCsv()
    {
        //csv�������� stringbuilder�� ����.
        for (int i = 0; i < _gameObjects.Length; i++)
        {
            IObjectPosition _obejctPosition = _gameObjects[i].GetComponent<IObjectPosition>();

            StringBuilder _tempSb = new StringBuilder();

            _tempSb.Append(_obejctPosition.Name);
            _tempSb.Append(",");
            _tempSb.Append(_obejctPosition.Position.x);
            _tempSb.Append(",");
            _tempSb.Append(_obejctPosition.Position.y);
            _tempSb.Append(",");
            _tempSb.Append(_obejctPosition.Position.z);
            _tempSb.Append("\n");

            _sb.Append(_tempSb);
        }

        // �����ΰ� ���������ʴٸ� ����. �ִٸ� ������ ���.
        if (Directory.Exists(_savePath) == false)
        {
            Directory.CreateDirectory(_savePath);
        }

        // WRite �ۼ�.
        File.WriteAllText(_savePath + "/Save.csv", string.Join("\n", _sb));





    }


}