using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �޸���
// 2023.09.14 �� �̱���
public class SampleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Singleton.Instance.InscreaseScore(10);
        GameManager.Instance.InscreaseScore(15);
    }

   
}
