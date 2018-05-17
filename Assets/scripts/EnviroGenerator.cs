using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroGenerator : MonoBehaviour {

    public List<GameObject> down;
    public List<GameObject> mid;
    //public List<GameObject> up;
    public GameObject InstDown;
    public GameObject InstMid;
    //public GameObject InstUp;
    public GameObject InstGround;
    public GameObject Ground;
    
    bool flagDown = true;
    bool flagMid = true;
    bool flagUp = true;
    bool flagGround = true;
    GameObject go;
    float randPos;
    int randPref;
    int randFlip = 1;
    Vector3 local;
    void Start () {
		
	}
	
	void Update () {
        if ((InstDown.transform.position.x <= (transform.position.x + 12)) && flagDown==true)
        {
            do
            {
                randFlip = Random.Range(-1, 2);
            }
            while (randFlip == 0);
                
            randPref = Random.Range(0, 5);
            go = Instantiate(down[randPref], InstDown.transform.position, Quaternion.identity);
            go.transform.localScale = new Vector3(go.transform.localScale.x*randFlip, go.transform.localScale.y, go.transform.localScale.z);


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
       /* if ((InstUp.transform.position.x <= (transform.position.x + 12)) && flagUp == true)
        {
            while (randFlip == 0) randFlip = Random.Range(-1, 2);
            randPref = Random.Range(0, 5);
            go = Instantiate(down[randPref], InstUp.transform.position, Quaternion.identity);
            local = go.transform.localScale;
            local.x *= randFlip;
            go.transform.localScale = local;


            randPos = Random.Range(5f, 20f);
            InstUp.transform.position = new Vector3(InstUp.transform.position.x + randPos, InstUp.transform.position.y, InstUp.transform.position.z);
            flagUp = false;
        }*/
        if ((InstGround.transform.position.x <= (transform.position.x + 27)) && flagGround == true)
        {
            Instantiate(Ground, InstGround.transform.position, Quaternion.identity);
            InstGround.transform.position = new Vector3(InstGround.transform.position.x + 25.5f, InstGround.transform.position.y, InstGround.transform.position.z);
            flagGround = false;
        }
        flagDown = true;
        flagMid = true;
        flagUp = true;
        flagGround = true;
    }
}
