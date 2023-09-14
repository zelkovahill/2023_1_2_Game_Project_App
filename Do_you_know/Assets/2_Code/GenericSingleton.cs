using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �޸���
// 2023.09.14 �� �̱���


public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = FindObjectOfType<T>();          // �ν��Ͻ� ������Ʈ�� ã�´�
                if(_instance==null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();      // �����ϰ� ������Ʈ ���δ�.
                }
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance == null)                                                  // Instance�� NULL�϶�
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);                  // ���� ������Ʈ�� Scene�� ��ȯ�ǰ� �ı����� ����
        }

        else if(_instance!=null)
        {
            Destroy(gameObject);                                         // 1���� ������Ű�� ���� ������ ��ü�� �ı� �Ѵ�
        }

    }






}
