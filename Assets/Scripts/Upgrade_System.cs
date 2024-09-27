using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade_System : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Attack_Upgrade;
    public GameObject Speed_Upgrade;
    public GameObject Defence_Upgrade;
    public GameObject Door;
    private GameObject clone1;
    private GameObject clone2;
    private GameObject clone3;
    public TMP_Text prompt;
    public Dialogue[] upgrades_explanation;
    public DIalogue_Manager Dialogue_manager;
    private GameObject player;
    private int box = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss == null && clone1 == null && clone2==null && clone3 == null)
        {
            prompt.gameObject.SetActive(true);
            clone1 = Instantiate(Attack_Upgrade, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
            clone2 = Instantiate(Speed_Upgrade, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
            clone3 = Instantiate(Defence_Upgrade, transform.GetChild(2).transform.position, transform.GetChild(2).transform.rotation);
        }
        else if (Boss == null)
        {
            if(Mathf.Abs(player.transform.position.x - clone1.gameObject.transform.position.x) <= 0.6f && box!=1)
            {
                Dialogue_manager.StartDialogue(upgrades_explanation[0]);
                box = 1;
            }
            if(Mathf.Abs(player.transform.position.x - clone2.gameObject.transform.position.x) <= 0.6f && box!=2)
            {
                Dialogue_manager.StartDialogue(upgrades_explanation[1]);
                box = 2;
            }
            if (Mathf.Abs(player.transform.position.x - clone3.gameObject.transform.position.x) <= 0.6f && box!=3)
            {
                Dialogue_manager.StartDialogue(upgrades_explanation[2]);
                box = 3;
            }
        }
        
        if(PlayerPrefs.GetInt("Upgrade" + PlayerPrefs.GetInt("Level").ToString()) != 0)
        {
            Dialogue_manager.dialogueText.gameObject.SetActive(false);
            prompt.gameObject.SetActive(false);
            Destroy(clone1);
            Destroy(clone2);
            Destroy(clone3);
            Door.GetComponent<Movable_Door>().Open_Door();
        }
    }
}
