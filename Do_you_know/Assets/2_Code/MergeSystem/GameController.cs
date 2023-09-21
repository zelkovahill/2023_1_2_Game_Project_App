using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Slot[] slots;

    private Vector3 _target;
    private ItemInfo carryingItem;          //�̵� ��Ű�� �ִ� ������ ����

    private Dictionary<int, Slot> slotDictionary; //���� ������ �����ϴ� �ڷᱸ��

    void Start()
    {
        slotDictionary = new Dictionary<int, Slot>();   //���� ��ųʸ� �ʱ�ȭ

        for (int i = 0; i < slots.Length; i++)           //�� ������ ID�� �����ϰ� ��ųʸ��� �߰� 
        {
            slots[i].id = i;
            slotDictionary.Add(i, slots[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                 //���콺 ��ư�� ������ ��
        {
            SendRayCast();
        }

        if (Input.GetMouseButton(0) && carryingItem) // ���콺 ��ư ���� ���¿��� ������ ���� �� �̵� ó��
        {
            OnItemSelected();
        }

        if (Input.GetMouseButtonUp(0))                   //���콺 ��ư ���� �̺�Ʈ ó��
        {
            SendRayCast();
        }

        if (Input.GetKeyDown(KeyCode.Space))            //������ũ Ű�� ������ �� ���� ������ ��ġ
        {
            PlaceRandomItem();
        }
    }

    void SendRayCast()  //���콺 Ŭ�� �� Ray �߻�
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        //ȭ���� ���콺 ��ǥ�� ���ؼ� ���� ���� �����ɽ��� 
        RaycastHit hit;                                                     //hit ���� ����

        if (Physics.Raycast(ray, out hit))                                  //hit �� ���� ���� ���
        {
            var slot = hit.transform.GetComponent<Slot>();                  //hit �� slot Component �� �����´�.
            if (slot.state == Slot.SLOTSTATE.FULL && carryingItem == null)   //������ ���Կ��� �������� ��� �̵� �ϴ� ���
            {
                string itemPath = "Prefabs/Item_Grabbed_" + slot.itemObject.id.ToString("000");     //���� ������ ����
                var itemGO = (GameObject)Instantiate(Resources.Load(itemPath));                     //�ش� ��θ� ���ؼ� ����
                itemGO.transform.position = slot.transform.position;                                //Slot ��ġ�� �����ϰ� ����
                itemGO.transform.localScale = Vector3.one * 2;                                      //ũ��� 2��� 
                carryingItem = itemGO.GetComponent<ItemInfo>();                                     //���� �������� carryingItem�� �Է�
                carryingItem.InitDummy(slot.id, slot.itemObject.id);                                //������ ���� ����
                slot.ItemGrabbed();                                                                 //���� �������� ������. 
            }
            else if (slot.state == Slot.SLOTSTATE.EMPTY && carryingItem != null) //�� ���Կ� ������ ��ġ
            {
                slot.CreateItem(carryingItem.itemId);                           //��� �ִ� ������ ���̵� �����ͼ� ���Կ� �����ϰ�
                Destroy(carryingItem.gameObject);                               //��� �ִ� ������ ����    
            }
            else if (slot.state == Slot.SLOTSTATE.FULL && carryingItem != null)  //�����۳��� ���� ���� ���� ������
            {
                if (slot.itemObject.id == carryingItem.itemId)                   //���� �����ִ� ������ id�� ��� �ִ� �������� ���� ���
                {
                    OnItemMergedWithTarget(slot.id);                            //������ ����
                }
                else
                {
                    OnItemCarryFail();  //������ ��ġ ����
                }
            }
        }
        else // hit �� �������
        {
            if (!carryingItem)   //��� �ִ� �����۵� �������
            {
                return;
            }
            OnItemCarryFail();  //������ ��ġ ����
        }
    }


    void OnItemSelected()  //�������� �����ϰ� ���콺 ��ġ�� �̵�
    {
        _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //���� ��ǥ���� ���콺 ������ ���� �����ͼ� _target�Է�
        _target.z = 0;                                                  //2D 

        var delta = 10 * Time.deltaTime;                                //�̵� �ӵ� ����
        delta *= Vector3.Distance(transform.position, _target);
        carryingItem.transform.position = Vector3.MoveTowards(carryingItem.transform.position, _target, delta); //�Լ��� �̵�
    }
    void OnItemMergedWithTarget(int targetSlotId)   //�������� ���԰� ���� �� �� �Լ�
    {
        var slot = GetSlotById(targetSlotId);           //���� ���Կ� �ִ� ������Ʈ�� �����ͼ� �ı�
        Destroy(slot.itemObject.gameObject);
        slot.CreateItem(carryingItem.itemId + 1);       //���� �Ǿ����Ƿ� ���� ������Ʈ�� ����
        Destroy(carryingItem.gameObject);               //����ִ� ���� ������Ʈ�� �ı�
    }
    void OnItemCarryFail()                          //������ ��ġ ���� �� ���� 
    {
        var slot = GetSlotById(carryingItem.slotId);            //��� �ִ� �������� ���� ���� ��ġ
        slot.CreateItem(carryingItem.itemId);                   //�ش� ���Կ� �ٽ� ����
        Destroy(carryingItem.gameObject);                       //��� �ִ� ���� �������� ���� 
    }

    void PlaceRandomItem()                          //������ ���Կ� ������ ��ġ
    {
        if (AllSlotsOccupied())
        {
            Debug.Log("������ �� ������ => ���� �Ұ� ");
            return;
        }
        var rand = UnityEngine.Random.Range(0, slots.Length);               //���� ������ ���� ���� ��ȣ�� rand�� �Է�
        var slot = GetSlotById(rand);                                       //Rand ���� index���� ���ؼ� slot ��ü�� �����´�.
        while (slot.state == Slot.SLOTSTATE.FULL)                           //���� ���°� FULL�� �ƴҶ����� ���� ��ȣ�� ã�Ƽ� ����
        {
            rand = UnityEngine.Random.Range(0, slots.Length);               //���� ������ ���� ���� ��ȣ�� rand�� �Է�
            slot = GetSlotById(rand);                                       //Rand ���� index���� ���ؼ� slot ��ü�� �����´�.
        }
        slot.CreateItem(0);                                                 //�� ������ �߰��ϸ� 0��° �������� ����
    }

    bool AllSlotsOccupied()                         //������ ä���� �ִ��� Ȯ�� �ϴ� �Լ�
    {
        foreach (var slot in slots)                      //���� �迭�� �ϳ��� Ȯ���ϸ鼭 foreach �� �ݺ�
        {
            if (slot.state == Slot.SLOTSTATE.EMPTY)          //���� �迭�� �� �ڸ��� ������ 
            {
                return false;                               //�߰��� false�� ����
            }
        }
        return true;                                        //�� �������Ƿ� true�� ����
    }

    Slot GetSlotById(int id)  //���� ID�� ������ �˻� 
    {
        return slotDictionary[id];          //��ųʸ��� ����ִ� Slot Class ��ȯ (��ȣ�� ���ؼ�)
    }
}