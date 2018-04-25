using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroGenerator : MonoBehaviour {

    public List<GameObject> down;
    public List<GameObject> mid;
    public GameObject InstDown;
    public GameObject InstMid;
    public GameObject InstGround;
    public GameObject Ground;
    
    bool flagDown = true;
    bool flagMid = true;
    bool flagGround = true;
    GameObject go;
    float randPos;
    int randPref;
    int randFlip;
    Vector3 local;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((InstDown.transform.position.x <= (transform.position.x + 12)) && flagDown==true)
        {
            while (randFlip == 0) randFlip = Random.Range(-1, 2);
            randPref = Random.Range(0, 5);
            go = Instantiate(down[randPref], InstDown.transform.position, Quaternion.identity);
            local = go.transform.localScale;
            local.x *= randFlip;
            go.transform.localScale = local;
            randPos = Random.Range(5f, 20f);
            InstDown.transform.position = new Vector3(InstDown.transform.position.x + randPos, InstDown.transform.position.y, InstDown.transform.position.z);
            flagDown = false;
        }
        if ((InstMid.transform.position.x <= (transform.position.x + 12)) && flagMid == true)
        {
            while (randFlip == 0) randFlip = Random.Range(-1, 2);
            randPref = Random.Range(0, 2);
            go = Instantiate(mid[randPref], InstMid.transform.position, Quaternion.identity);
            local = go.transform.localScale;
            local.x *= randFlip;
            go.transform.localScale = local;
            randPos = Random.Range(34f, 62f);
            InstMid.transform.position = new Vector3(InstMid.transform.position.x + randPos, InstMid.transform.position.y, InstMid.transform.position.z);
            flagMid = false;
        }
        if ((InstGround.transform.position.x <= (transform.position.x + 27)) && flagGround == true)
        {
            Instantiate(Ground, InstGround.transform.position, Quaternion.identity);
            InstGround.transform.position = new Vector3(InstGround.transform.position.x + 25.5f, InstGround.transform.position.y, InstGround.transform.position.z);
            flagGround = false;
        }
        flagDown = true;
        flagMid = true;
        flagGround = true;
    }
}
