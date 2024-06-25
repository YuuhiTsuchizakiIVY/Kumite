using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    GameObject Enemy2;
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
        delta += Time.deltaTime;
        NowTime += Time.deltaTime;
        if(NowTime < 20)
        {
            Span = 10.0f;
            if (delta > Span)
            {
                delta = 0;
                EnemyGanerate();
            }
        }
        else if (NowTime < 30)
        {
            Span = 7.0f;
            if (delta > Span)
            {
                delta = 0;
                EnemyGanerate();
            }
        }
        else if (NowTime < 50)
        {
            Span = 5.0f;
            if (delta > Span)
            {
                delta = 0;
                EnemyGanerate();
            }
        }
        else
        {
            Span = 4.0f;
            if (delta > Span)
            {
                delta = 0;
                EnemyGanerate();
            }
        }
    }

    public void EnemyGanerate()
    {
        Enemy2 = Instantiate(EnemyPrefab);
        Enemy2.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
