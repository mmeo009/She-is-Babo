using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExCubePlayer : MonoBehaviour
{
    public TMP_Text TextUI = null;                      // 텍스트 UI
    public int Count = 0;                               // 마우스 클릭 카운터
    public int Power = 100;                             // 물리 힘 수치

    public int Point = 0;                               // 점수 수치
    public float checkTime = 0.0f;                      // 시간 체크 표시

    public Rigidbody m_Rigidbody;

    void Update()
    {
        checkTime += Time.deltaTime;                    // 시간을 누적해서 쌓는다.
        if(checkTime >= 1.0f)                           // 1초마다 어떤 행동을 한다.
        {
            Point += 1;                                 // 1초마다 점수 1점을 올린다.
            checkTime = 0.0f;                           // 시간을 초기화 한다.
        }
        if(Input.GetKeyDown(KeyCode.Space))             // 스페이스를 누를 때
        {
            Power = Random.Range(100, 200);             // 100~ 200 사이의 값의 힘을 준다.
            m_Rigidbody.AddForce(transform.up * Power); // Y축으로 설정한 힘을 준다.
        }
        TextUI.text = Point.ToString();                 // UI에 점수 표시를 한다.
    }

    void OnTriggerEnter(Collider other)                 // Trigger를 통한 충돌
    {
        if(other.gameObject.tag == "Items")             // 설정한 Tag로 Items와 충돌 했을 때
        {
            Point += 10;                                // point 10점을 올려준다.
            Destroy(other.gameObject);                  // 해당 오브젝트를 파괴 시켜준다.
        }
    }
}
