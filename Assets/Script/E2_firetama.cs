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
            // 敵のミサイルを生成する
            enemyTama = Instantiate(enemyTamaPrefab, transform.position, Quaternion.identity);
            enemyTamaRb = enemyTama.GetComponent<Rigidbody2D>();

            // ミサイルを飛ばす方向を決める。「forward」は「z軸」方向をさす（ポイント）
            //enemyTamaRb.AddForce(transform.right * speed);
            this.enemyTamaRb.velocity = new Vector3(oyaScript.P_pos.x - oyaScript.E_pos.x, -2, 2);

            // ３秒後に敵のミサイルを削除する。

        }
    }
}
