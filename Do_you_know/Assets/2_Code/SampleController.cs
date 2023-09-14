using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ∏ﬁ∏¿Â
// 2023.09.14 ∏Ò ΩÃ±€≈Ê
public class SampleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Singleton.Instance.InscreaseScore(10);
        GameManager.Instance.InscreaseScore(15);
    }

   
}
