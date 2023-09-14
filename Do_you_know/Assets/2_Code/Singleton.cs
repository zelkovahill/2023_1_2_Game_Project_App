using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 메모장
// 2023.09.14 목 싱글톤

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }      // 인스턴스를 전역에 선언

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);                  // 게임 오브젝트가 Scene이 전환되고 파괴되지 않음
        }

        else
        {
            Destroy(gameObject);                                         // 1개로 유지시키기 위해 생성된 객체를 파괴 한다
        }

    }

    public int playerScore = 0;                                           // 관리할 플레이어 스코어

    public void InscreaseScore(int amount)                 // 함수를 통해서 스코어를 증가시킨다
    {
        playerScore += amount;
    }







}
