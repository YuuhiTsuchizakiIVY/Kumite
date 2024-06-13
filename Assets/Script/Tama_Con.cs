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
        if (collision.gameObject.tag == "Player")   //ƒvƒŒƒCƒ„[‚ÉG‚ê‚½‚çƒ_ƒ[ƒW‚ğ—^‚¦‚é
        {
            GameDirector.DecreaseHp_Tama();
        }

        if (collision.gameObject.tag == "DEF")      //–hŒä”»’è‚ÉG‚ê‚½‚ç”jŠü‚·‚é
        {
            Destroy(this.gameObject);
        }
    }


}
