using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �޸���
// 2023.09.14 �� �̱���

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }      // �ν��Ͻ��� ������ ����

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);                  // ���� ������Ʈ�� Scene�� ��ȯ�ǰ� �ı����� ����
        }

        else
        {
            Destroy(gameObject);                                         // 1���� ������Ű�� ���� ������ ��ü�� �ı� �Ѵ�
        }

    }

    public int playerScore = 0;                                           // ������ �÷��̾� ���ھ�

    public void InscreaseScore(int amount)                 // �Լ��� ���ؼ� ���ھ ������Ų��
    {
        playerScore += amount;
    }







}
