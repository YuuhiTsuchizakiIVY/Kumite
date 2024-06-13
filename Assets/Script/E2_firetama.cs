using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_firetama : MonoBehaviour
{
    public GameObject EnemyTamaPrefab;
    GameObject EnemyTama;
    Rigidbody2D EnemyTamaRb;
    private GameObject Target;
    public float Speed;
    private int TimeCount = 0;
    Vector3 TargetCorrection;
    float Delta = 0;
    void Start()
    {
        TargetCorrection = new Vector3(0, 1, 0);
        Target = GameObject.Find("HeroKnight");
    }

    void Update()
    {
        TimeCount += 1;
        this.Delta += Time.deltaTime;
        transform.LookAt(Target.transform.position + TargetCorrection);  //HeroKnightの方向を向く　TargetCorrectionでHeroKnightの頭の高さを狙うように調整
        if (this.Delta >= 3)
        {
            this.Delta = 0;
            // 敵の弾を生成する
            EnemyTama = Instantiate(EnemyTamaPrefab, transform.position, Quaternion.identity);
            EnemyTamaRb = EnemyTama.GetComponent<Rigidbody2D>();

            //弾を飛ばす方向を決める。
            EnemyTamaRb.AddForce(transform.forward * Speed);
            
            // 10秒後に敵の弾を削除する。
            Destroy(EnemyTama, 10);
        }
    }
}
