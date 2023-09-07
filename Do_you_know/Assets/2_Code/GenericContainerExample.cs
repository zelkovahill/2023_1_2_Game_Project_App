using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GenericContainerExample : MonoBehaviour
{
    private GenericContainer<int> intContainer;         // int 컨테이너
    private GenericContainer<string> stringContainer; // string 컨테이너

    private void Start()
    {
        intContainer = new GenericContainer<int>(10);            // 10칸 초기화
        stringContainer = new GenericContainer<string>(5);  // 5칸 초기화
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))    //키보드 1 입력 하면
        {
            intContainer.Add(Random.Range(0, 100)); // 0~100 랜덤 출력
            DisplayContainerItems(intContainer);        // 디버그에 보여줌
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))  // 키보드 2 입력 하면
        {
            string randomSting = "Item " + Random.Range(0, 100);
            stringContainer.Add(randomSting);       // 컨테이너에 더한다.
            DisplayContainerItems(stringContainer);  // 디버그에 보여줌
        }
    }


    private void DisplayContainerItems<T>(GenericContainer<T> container)
    {
        T[] item = container.GetItems();
        string temp = "";

        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] != null)                                   // 값이 NULL이 아닐경우
            {
                temp += item[i].ToString() + " - "; //string 형식으로 보여준다
            }
            else
            {
                temp += "Empty - ";                     //NULL일 경우에는 Empty 표현 해준다
            }
        }
        Debug.Log(temp);
    }
}