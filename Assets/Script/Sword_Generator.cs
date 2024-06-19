using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Generator : MonoBehaviour
{
    
    public GameObject SwordPrefab;
    GameObject Sword;
    GameObject Player;
    GameDirector DirectorScript;
    Vector3 _PlayerPosition;
    Transform PlayerTransform;
    private List<GameObject> SwordList = new List<GameObject>();

    public AudioClip SwordSE;
    AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RotateCenter");
        DirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        PlayerTransform = Player.transform;
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        _PlayerPosition = PlayerTransform.position;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (DirectorScript.SkillOK)
            {
                SwordGenerate();
                DirectorScript.DecreaseSkillGauge();
                
            }           
        }
        
    }

    void SwordGenerate()
    {
        StartCoroutine(Gene());
    }

    public IEnumerator Gene()
    {
        for(int cnt = 0; cnt < 6; cnt++)
        {
            Sword = Instantiate(SwordPrefab);
            Sword.transform.position = new Vector3(_PlayerPosition.x, _PlayerPosition.y, 0);
            SwordList.Add(Sword);
            AudioSource.PlayOneShot(SwordSE);
            yield return new WaitForSeconds(0.34f);
        }
        ShootAllSwordList();
    }

    private void ShootAllSwordList()
    {
        foreach (GameObject sword in SwordList)
        {
            sword.GetComponent<Sword_Controller>().ShotStart();
        }
        SwordList.Clear(); // リストをクリア
    }
}
