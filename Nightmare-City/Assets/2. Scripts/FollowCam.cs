using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Tooltip("������ Ÿ�� ���ӿ�����Ʈ�� Transform ����")]
    [SerializeField] private Transform targetTr;
    [Tooltip("ī�޶���� ���� �Ÿ�")]
    [SerializeField] private float dist = 5.0f;
    [Tooltip("ī�޶��� ���� ����")]
    [SerializeField] private float height = 3.0f;
    [Tooltip("�ε巯�� ������ ���� ����")]
    [SerializeField] private float dampTrace = 20.0f;

    private Transform tr; // ī�޶� �ڽ��� Transform ����

    void Start()
    {
        // ī�޶� �ڽ��� Transform ������Ʈ�� tr�� �Ҵ�
        tr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // ī�޶��� ��ġ�� ���� ����� dist ���� ��ŭ �������� ��ġ�ϰ� height ���� ��ŭ ���� �ø�
        tr.position = Vector3.Lerp(tr.position, // ���� ��ġ
                                    targetTr.position - (targetTr.forward * dist) + (Vector3.up * height), // ���� ��ġ
                                    Time.deltaTime * dampTrace); // ���� �ð�
        // ī�޶� ŸŶ ���ӿ�����Ʈ�� �ٶ󺸰� ����
        tr.LookAt(targetTr.position);
    }
}
