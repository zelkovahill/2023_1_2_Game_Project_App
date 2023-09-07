using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���ʸ� �������� Class ����
public class GenericContainer <T>
{
    private T[] items;                                           // Ŀ���� �迭
    private int currentIndex = 0;                      // item ���� ��ȣ

    public GenericContainer(int capacity)   // ���� �� �� �迭 ���� ����
    {
        items = new T[capacity];                        // �Լ��� ���ؼ� �޾ƿͼ� �迭 ����

    }

    public void Add(T item) 
    {
        // �迭�� ���� ���� �� �̻� ���� ����
        if (currentIndex < items.Length)
        {
            items[currentIndex] = item;             //  ���� �������� ��ȣ�� ���ؼ� �迭�� �ִ´�
            currentIndex++;                                  // ������ ��ȣ�� ������Ų��

        }
    }
    public T[] GetItems() 
    {
                                                                            // �������� �迭�� return ��
        return items;
    }
}
