using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExCubePlayer : MonoBehaviour
{
    public TMP_Text TextUI = null;                      // �ؽ�Ʈ UI
    public int Count = 0;                               // ���콺 Ŭ�� ī����
    public int Power = 100;                             // ���� �� ��ġ

    public int Point = 0;                               // ���� ��ġ
    public float checkTime = 0.0f;                      // �ð� üũ ǥ��

    public Rigidbody m_Rigidbody;

    void Update()
    {
        checkTime += Time.deltaTime;                    // �ð��� �����ؼ� �״´�.
        if(checkTime >= 1.0f)                           // 1�ʸ��� � �ൿ�� �Ѵ�.
        {
            Point += 1;                                 // 1�ʸ��� ���� 1���� �ø���.
            checkTime = 0.0f;                           // �ð��� �ʱ�ȭ �Ѵ�.
        }
        if(Input.GetKeyDown(KeyCode.Space))             // �����̽��� ���� ��
        {
            Power = Random.Range(100, 200);             // 100~ 200 ������ ���� ���� �ش�.
            m_Rigidbody.AddForce(transform.up * Power); // Y������ ������ ���� �ش�.
        }
        TextUI.text = Point.ToString();                 // UI�� ���� ǥ�ø� �Ѵ�.
    }

    void OnTriggerEnter(Collider other)                 // Trigger�� ���� �浹
    {
        if(other.gameObject.tag == "Items")             // ������ Tag�� Items�� �浹 ���� ��
        {
            Point += 10;                                // point 10���� �÷��ش�.
            Destroy(other.gameObject);                  // �ش� ������Ʈ�� �ı� �����ش�.
        }
    }
}
