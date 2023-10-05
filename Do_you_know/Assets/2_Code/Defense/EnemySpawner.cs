using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public EnemyController[] enemiesToSpawn;    // ���� ���� �迭 ��

    public Transform spawnPoint;

    public float timeBetweenSpawns = 0.5f; // ���� ���� �ð�
    private float spawnCounter;     // ���ڸ� ī���� �ϴ� ����

    public int amountToSpawn = 15;      // ������ �� ���� ����


    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

 
    void Update()
    {
        if(amountToSpawn>0) // ���� �ִ� ���� �� ���ڰ� ���� ��
        {
            spawnCounter -= Time.deltaTime;     // �����Ӹ��� �ð��� ���� ��Ŵ
            if(spawnCounter<=0)                 // spawnCount 0�����϶�
            {
                spawnCounter = timeBetweenSpawns;   // ������ ���� ���� ���� �ð��� �ٽ� ����

                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position
                    , spawnPoint.rotation);

                // Random.Range(0, enemiesToSpawn.Length) �迭���� ������ ���ؼ� �������� ���� , ��ġ�� �����̼� ��


                amountToSpawn--;       // ������ ���ڸ� ���ش�.
            }
        }
    }
}
