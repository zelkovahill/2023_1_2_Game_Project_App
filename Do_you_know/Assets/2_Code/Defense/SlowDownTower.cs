using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTower : MonoBehaviour
{

    private Tower thisTower;
    

    void Start()
    {
        thisTower = GetComponent<Tower>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(thisTower.enemiesUpdate) // �� ����Ʈ�� ���� �Ǿ��� ��
        {
            if(thisTower.enemiesInRange.Count>0) // ���� �ȿ� ���� ������ ��
            {
                foreach(EnemyController enemy in thisTower.enemiesInRange)
                {
                    enemy.SetMode(thisTower.fireRate);  // ���ο� ����
                }
            }
        }
    }
}
