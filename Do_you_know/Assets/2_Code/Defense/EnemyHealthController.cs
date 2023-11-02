using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int totalHealth;     // ü�� ����

    public int moneyOnDeath = 50 ;  // ������ �� ���� ��������

    public void TakeDamage(int damagedAmount)        // �������� �޴� �Լ�
    {
        totalHealth -= damagedAmount;
        Debug.Log(totalHealth);

        if (totalHealth <= 0) 
        {
            totalHealth = 0;
            Destroy(gameObject);

            // �̱������� ���� �÷��ִ� ó�� �Լ�
            // ���� ���� ó�� ���� ���⼭ ���ش�.
        }
    }




}
