using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_firetama : MonoBehaviour
{
    public GameObject enemyTamaPrefab;
    GameObject enemyTama;
    Rigidbody2D enemyTamaRb;
    public float speed;
    private int timeCount = 0;
    Enemy2Controller Ene2Con;
    GameObject oya;
    Enemy2Controller oyaScript;
    void Start()
    {
        oya = transform.parent.gameObject;
        oyaScript = oya.GetComponent<Enemy2Controller>();
        Ene2Con = GameObject.Find("Enemy2").GetComponent<Enemy2Controller>();
        
    }

    void Update()
    {
        timeCount += 1;
        

        if (timeCount % 600 == 0)
        {
            // �G�̃~�T�C���𐶐�����
            enemyTama = Instantiate(enemyTamaPrefab, transform.position, Quaternion.identity);
            enemyTamaRb = enemyTama.GetComponent<Rigidbody2D>();

            // �~�T�C�����΂����������߂�B�uforward�v�́uz���v�����������i�|�C���g�j
            //enemyTamaRb.AddForce(transform.right * speed);
            this.enemyTamaRb.velocity = new Vector3(oyaScript.P_pos.x - oyaScript.E_pos.x, -2, 2);

            // �R�b��ɓG�̃~�T�C�����폜����B

        }
    }
}
