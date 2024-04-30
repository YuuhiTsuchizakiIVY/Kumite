using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama_Con : MonoBehaviour
{
    GameDirector GameDirectorScript;
    // Start is called before the first frame update
    void Start()
    {
        GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameDirectorScript.DecreaseHp_Tama();
        }

        if (collision.gameObject.tag == "DEF")
        {
            Destroy(this.gameObject);
        }
    }


}
