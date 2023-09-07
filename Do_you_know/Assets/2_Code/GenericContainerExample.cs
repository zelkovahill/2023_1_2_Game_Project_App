using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GenericContainerExample : MonoBehaviour
{
    private GenericContainer<int> intContainer;         // int �����̳�
    private GenericContainer<string> stringContainer; // string �����̳�

    private void Start()
    {
        intContainer = new GenericContainer<int>(10);            // 10ĭ �ʱ�ȭ
        stringContainer = new GenericContainer<string>(5);  // 5ĭ �ʱ�ȭ
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))    //Ű���� 1 �Է� �ϸ�
        {
            intContainer.Add(Random.Range(0, 100)); // 0~100 ���� ���
            DisplayContainerItems(intContainer);        // ����׿� ������
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))  // Ű���� 2 �Է� �ϸ�
        {
            string randomSting = "Item " + Random.Range(0, 100);
            stringContainer.Add(randomSting);       // �����̳ʿ� ���Ѵ�.
            DisplayContainerItems(stringContainer);  // ����׿� ������
        }
    }


    private void DisplayContainerItems<T>(GenericContainer<T> container)
    {
        T[] item = container.GetItems();
        string temp = "";

        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] != null)                                   // ���� NULL�� �ƴҰ��
            {
                temp += item[i].ToString() + " - "; //string �������� �����ش�
            }
            else
            {
                temp += "Empty - ";                     //NULL�� ��쿡�� Empty ǥ�� ���ش�
            }
        }
        Debug.Log(temp);
    }
}