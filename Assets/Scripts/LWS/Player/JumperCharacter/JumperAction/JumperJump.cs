using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperJump : PlayerAction
{
    private JumperData _jumperData;
    private Rigidbody _rigidbody;


    // DoAction ������
    public override BTNodeState DoAction()
    {
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumperData.JumpPower, _rigidbody.velocity.z);
            Debug.Log("����!");
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }
}
