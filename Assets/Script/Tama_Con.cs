using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama_Con : MonoBehaviour
{
    GameDirector GameDirector;
    // Start is called before the first frame update
    void Start()
    {
        GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")   //プレイヤーに触れたらダメージを与える
        {
            GameDirector.DecreaseHp_Tama();
        }

        if (collision.gameObject.tag == "DEF")      //防御判定に触れたら破棄する
        {
            Destroy(this.gameObject);
        }
    }


}
