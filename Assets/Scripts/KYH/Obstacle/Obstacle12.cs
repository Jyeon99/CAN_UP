using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle12 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] Rigidbody _rigid;

    private Coroutine _upRoutine;

    //OnCollisionEnter하면
    public void PlatformDown(PlayerController player)
    {
        // 플랫폼이 아래로 일정 속도로 낙하
        _rigid.velocity = Vector3.down * _moveSpeed;
    }
    
    // OnCollisionExit하면
    public void PlatformReturn(PlayerController player)
    {
        // 플랫폼이 _startPos로 복귀
        _upRoutine = StartCoroutine(UpCoroutine());
    }

    // 플랫폼이 원래 자리로 돌아가는 기능 코루틴
    IEnumerator UpCoroutine() 
    {
        while (true)
        {
            // 플랫폼의 y좌표값이 _startPos의 y좌표값 이상일 때
            if (gameObject.transform.position.y >= _startPos.position.y)
            {
                _rigid.velocity = Vector3.zero;     // 이동값을 0으로 설정
                StopCoroutine(_upRoutine);          // 코루틴 정지
                _upRoutine = null;                  // 코루틴 값을 null로 비우기
            }
            // 플랫폼의 y좌표값이 _startPos의 y좌표값 이상이 아닌 경우 (아직 발판이 복귀 중인 경우)
            else
            {
                // 원래 위치로 원상복귀
                _rigid.velocity = Vector3.up * _moveSpeed;
            }
            
            // null값을 반환
            yield return null;
        }
    }
}
