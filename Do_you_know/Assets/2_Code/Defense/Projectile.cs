using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody rb;       // ���ο��� ��� �� rb;

    public float moveSpeed;         // �̵� �ӵ�
    public float damagedAmount;     // ������ ��
    private bool hasDamaged;        // flag ����




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed ;    // rb�� ���� �������� �Ѿ� �̵� �ӵ��� �Է�
    }

    private void OnTriggerEnter( Collider col )
    {
        if ( col.tag == "Enemy" && !hasDamaged )
        {
            hasDamaged = true ;
        }

        Destroy ( gameObject ) ;        // Trigger �浹�� �Ͼ�� �ı�
    }

}
