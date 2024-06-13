using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float Span = 3.0f;
    float delta = 0;
    float NowTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        this.delta += Time.deltaTime;
        this.NowTime += Time.deltaTime;
        if(this.NowTime < 20)
        {
            Span = 8.0f;
            if (this.delta > this.Span)
            {
                this.delta = 0;
                EnemyGanerate();
            }
        }
        else if (this.NowTime < 30)
        {
            Span = 5.0f;
            if (this.delta > this.Span)

            {
                this.delta = 0;
                EnemyGanerate();
            }
        }
        else if (this.NowTime < 50)
        {
            Span = 4.0f;
            if (this.delta > this.Span)
            {
                this.delta = 0;
                EnemyGanerate();
            }
        }
        else
        {
            Span = 3.0f;
            if (this.delta > this.Span)
            {
                this.delta = 0;
                EnemyGanerate();
            }
        }
    }

    public void EnemyGanerate()
    {
        GameObject Orb = Instantiate(EnemyPrefab);
        Orb.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
    }
}
