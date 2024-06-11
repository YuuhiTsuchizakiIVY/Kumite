using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Generator : MonoBehaviour
{
    
    public GameObject Sword_Prefab;
    public GameObject SCon;
    GameObject Sword;
    GameObject Player;
    Sword_Controller SwordCon_Script;
    GameDirector Director_Script;
    Vector3 P_pos;
    private List<GameObject> swords = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RotateCenter");
        Director_Script = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
        P_pos = Player.transform.position;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Director_Script.SkillOK)
            {
                SwordGene();
                Director_Script.DecreaseSkillGauge();
                Debug.Log("test");
            }           
        }
        
    }

    void SwordGene()
    {
        StartCoroutine(Gene());
        Debug.Log("swordGene");
    }

    public IEnumerator Gene()
    {
        for(int cnt = 0; cnt < 6; cnt++)
        {
            Sword = Instantiate(Sword_Prefab);
            Sword.transform.position = new Vector3(P_pos.x, P_pos.y, 0);
            Debug.Log("Gene");
            swords.Add(Sword);
            yield return new WaitForSeconds(0.34f);
        }
        ShootAllSwords();
    }

    private void ShootAllSwords()
    {
        foreach (GameObject sword in swords)
        {
            sword.GetComponent<Sword_Controller>().ShootStart();
        }
        swords.Clear(); // リストをクリア
    }
}
