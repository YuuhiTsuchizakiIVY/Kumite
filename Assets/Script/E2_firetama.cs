using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_firetama : MonoBehaviour
{
    public GameObject enemyTamaPrefab;
    GameObject enemyTama;
    Rigidbody2D enemyTamaRb;
    private GameObject target;
    public float speed;
    private int timeCount = 0;
    GameObject oya;
    Enemy2Controller oyaScript;
    Vector3 Targethosei;
    void Start()
    {
        oya = transform.parent.gameObject;
        oyaScript = oya.GetComponent<Enemy2Controller>();
        Targethosei = new Vector3(0, 1, 0);
        target = GameObject.Find("HeroKnight");
    }

    void Update()
    {
        timeCount += 1;

        transform.LookAt(target.transform.position + Targethosei);
        if (timeCount % 600 == 0)
        {
            // 敵の弾を生成する
            enemyTama = Instantiate(enemyTamaPrefab, transform.position, Quaternion.identity);
            enemyTamaRb = enemyTama.GetComponent<Rigidbody2D>();

            //弾を飛ばす方向を決める。
            enemyTamaRb.AddForce(transform.forward * speed);
            
            // 10秒後に敵の弾を削除する。
            Destroy(enemyTama, 10);
        }
    }
}
