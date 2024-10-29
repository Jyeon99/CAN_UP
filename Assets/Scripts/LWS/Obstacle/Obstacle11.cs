using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle11 : MonoBehaviour
{
    // X��� Y�� �߽ɱ��� �̵��� ����
    [SerializeField] private float _moveOffsetX;
    [SerializeField] private float _moveOffsetY;

    // �̵��ӵ�
    [SerializeField] private float _moveSpeed;

    // �̵��ֱ�
    [SerializeField] private float _moveInterval;

    // �⺻ ��ġ
    [SerializeField] private Vector3 _startPos;

    // �̵� ���� ���� ����
    [SerializeField] private bool _movingPositive;

    private void Start()
    {
        _startPos = transform.position;
        _movingPositive = true;

        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            // ��ǥ ��ġ ���� (offset����)
            Vector3 targetPosition = _movingPositive
                ? _startPos + new Vector3(_moveOffsetX, _moveOffsetY, 0)
                : _startPos - new Vector3(_moveOffsetX, _moveOffsetY, 0);

            // ���� �� �̵�
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed*Time.deltaTime);
                yield return null;
            }

            // �ݴ� ���� �̵�
            _movingPositive = !_movingPositive;

            // �ֱ⸸ŭ ���
            yield return new WaitForSeconds(_moveInterval);
        }
    }
}
