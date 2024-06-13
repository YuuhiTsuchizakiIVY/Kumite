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
        transform.LookAt(Target.transform.position + TargetCorrection);  //HeroKnight‚Ì•ûŒü‚ğŒü‚­@TargetCorrection‚ÅHeroKnight‚Ì“ª‚Ì‚‚³‚ğ‘_‚¤‚æ‚¤‚É’²®
        if (this.Delta >= 3)
        {
            this.Delta = 0;
            // “G‚Ì’e‚ğ¶¬‚·‚é
            EnemyTama = Instantiate(EnemyTamaPrefab, transform.position, Quaternion.identity);
            EnemyTamaRb = EnemyTama.GetComponent<Rigidbody2D>();

            //’e‚ğ”ò‚Î‚·•ûŒü‚ğŒˆ‚ß‚éB
            EnemyTamaRb.AddForce(transform.forward * Speed);
            
            // 10•bŒã‚É“G‚Ì’e‚ğíœ‚·‚éB
            Destroy(EnemyTama, 10);
        }
    }
}
