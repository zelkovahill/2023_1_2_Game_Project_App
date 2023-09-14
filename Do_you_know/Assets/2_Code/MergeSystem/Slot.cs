using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SLOTSTATE // ���� ���°�
    {
        EMPTY,
        FULL
    }

    public int id;
    public Item itemObject;                                             // ������ ������ ����(Ŀ���� Class)
    public SLOTSTATE state = SLOTSTATE.EMPTY;     // ���°� �����Ѱ� ���� �� EMPTY �Է�

    private void ChangeStateTo(SLOTSTATE targetState) // �ش� ������ ���°��� ��ȯ�����ִ� �Լ�
    {
        state = targetState;
    }

    public void ItemGrabbed()                       // ������ RatCast�� ���ؼ� �������� ����� ��
    {
        Destroy(itemObject.gameObject);      // �������� �������� ����
        ChangeStateTo(SLOTSTATE.EMPTY); // ������ �� ����(State)
    }


    public void CreateItem(int id)
    {
        string itemPath = "Prefabs/Item_" + id.ToString("000"); // ������ ������ ��� (Resources/Prefabs/Item_000)���� ����
        var itemGo = (GameObject)Instantiate(Resources.Load(itemPath)); // ������ ��ο� �ִ� �������� ����

        // ������ ���� ������Ʈ �ʱ�ȭ
        itemGo.transform.SetParent(this.transform);         // Slot ������Ʈ ������ ����
        itemGo.transform.localPosition = Vector3.zero;      // ���� ��ġ�� Vector3(0,0,0)
        itemGo.transform.localScale = Vector3.one;            // ���� Scale�� Vector3(1,1,1)

        // ���� Item ������Ʈ ������ �Է�
        itemObject = itemGo.GetComponent<Item>();   // ������ ���� ������Ʈ�� Item Class��
        itemObject.Init(id, this);                                         // �Լ��� ���� �� �Է�

        ChangeStateTo(SLOTSTATE.FULL);                      // �����ؼ� ������ ������ ���ִ�



    }



}
