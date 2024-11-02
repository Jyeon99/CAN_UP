using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class CsvParser : MonoBehaviour
{
    [SerializeField] private GameObject _objects;

    private StringBuilder _sb = new StringBuilder();

    private string _savePath;

    private void Awake()
    {
        // ������ user/appdata/LocalLow/Can_Up/Save
        _savePath = Application.persistentDataPath + "/Save";
    }

    [ContextMenu("Save")]
    private void CreateCsv()
    {

        IObjectPosition[] objectPositions = _objects.GetComponentsInChildren<IObjectPosition>();

        _sb.Append("Name,x,y,z\n");
        //csv�������� stringbuilder�� ����.
        for (int i = 0; i < objectPositions.Length; i++)
        {
            IObjectPosition _objectPosition = objectPositions[i];

            StringBuilder _tempSb = new StringBuilder();

            _tempSb.Append(_objectPosition.Name);
            _tempSb.Append(",");
            _tempSb.Append(_objectPosition.Position.x);
            _tempSb.Append(",");
            _tempSb.Append(_objectPosition.Position.y);
            _tempSb.Append(",");
            _tempSb.Append(_objectPosition.Position.z);
            _tempSb.Append("\n");

            _sb.Append(_tempSb);
        }

        // �����ΰ� ���������ʴٸ� ����. �ִٸ� ������ ���.
        if (Directory.Exists(_savePath) == false)
        {
            Directory.CreateDirectory(_savePath);
        }

        File.WriteAllText(_savePath + "/Save.csv", string.Empty);

        // WRite �ۼ�.
        File.WriteAllText(_savePath + "/Save.csv", string.Join("\n", _sb));

    }


}