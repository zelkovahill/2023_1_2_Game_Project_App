using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyController : MonoBehaviour
{
    

    public float moveSpeed; // �� �̵��ӵ�

    private MonsterPath thePath;    // �н� ��ġ ���� ��
    private int currentPoint;       // �н� ��ġ Ŀ�� ��
    private bool reachedEnd;        // ���� �Ϸ� �˻� bool ��



    void Start()
    {
        if (thePath == null)  //������ �� Path �� ������
        {
            thePath = FindObjectOfType<MonsterPath>();  //Scene���� ã�´�
        }

    }


    void Update()
    {
        if (reachedEnd == false)   // ���� �Ϸᰡ �ƴ� ���
        {
            transform.LookAt(thePath.points[currentPoint]); // ���� ��ġ Ŀ������ ���ؼ� ����

            transform.position = Vector3.MoveTowards(transform.position,
                thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

            // ���� �н� ����Ʈ ��ġ�� �Ÿ��� ����ؼ� 0.01 �����ϰ�� ����
            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < 0.01f)
            {
                currentPoint += 1; // ���� ��ġ Ŀ���� �ű��

                if (currentPoint >= thePath.points.Length) // �� �������� ����
                {
                    reachedEnd = true;
                }

            }

        }
    }
}
