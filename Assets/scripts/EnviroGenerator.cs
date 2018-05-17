using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroGenerator : MonoBehaviour {

    public int downBottomRange;
    public int downUpperRange;
    public int midBottomRange;
    public int midUpperRange;
    public int upBottomRange;
    public int upUpperRange;
    public int stalagnatsBottomRange;
    public int stalagnatsUpperRange;

    public List<GameObject> down;
    public List<GameObject> mid;
    public List<GameObject> up;
    public List<GameObject> stalagnats;
    public GameObject InstDown;
    public GameObject InstMid;
    public GameObject InstUp;
    public GameObject InstGround;
    public GameObject InstStal;
    public GameObject Ground;
    
    bool flagDown = true;
    bool flagMid = true;
    bool flagUp = true;
    bool flagGround = true;
    bool flagStal = true;
    GameObject go;
    int randPos;
    int randPref;
    int randFlipX = 1;
    int randFlipY = 1;
    int randRot;
    Vector3 local;
    void Start () {
		
	}
	
	void Update () {
        if ((InstDown.transform.position.x <= (transform.position.x + 30)) && flagDown==true)               //down
        {
            do
            {
                randFlipX = Random.Range(-1, 2);
            }
            while (randFlipX == 0);

            randPref = Random.Range(0, down.Count + 1);
            randRot = Random.Range(-10, 11);
            go = Instantiate(down[randPref], InstDown.transform.position, Quaternion.identity);
            go.transform.localScale = new Vector3(go.transform.localScale.x*randFlipX, go.transform.localScale.y, go.transform.localScale.z);
            go.transform.Rotate(Vector3.forward * randRot);
            if (go.GetComponent<SpriteRenderer>().sortingOrder == 2)
                go.transform.parent = GameObject.Find("layer_0").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = GameObject.Find("layer_1").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = GameObject.Find("layer_2").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = GameObject.Find("layer_3").transform;

            randPos = Random.Range(downBottomRange, downUpperRange + 1);
            InstDown.transform.position = new Vector3(InstDown.transform.position.x + randPos, InstDown.transform.position.y, InstDown.transform.position.z);
            flagDown = false;
        }
        if ((InstMid.transform.position.x <= (transform.position.x + 30)) && flagMid == true)               //mid
        {
            do
            {
                randFlipX = Random.Range(-1, 2);
            }
            while (randFlipX == 0);

            randPref = Random.Range(0, mid.Count + 1);
            randRot = Random.Range(-10, 11);
            go = Instantiate(mid[randPref], InstMid.transform.position, Quaternion.identity);
            go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y, go.transform.localScale.z);
            go.transform.Rotate(Vector3.forward * randRot);
            if (go.GetComponent<SpriteRenderer>().sortingOrder == 2)
                go.transform.parent = GameObject.Find("layer_0").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = GameObject.Find("layer_1").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = GameObject.Find("layer_2").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = GameObject.Find("layer_3").transform;

            randPos = Random.Range(midBottomRange, midUpperRange + 1);
            InstMid.transform.position = new Vector3(InstMid.transform.position.x + randPos, InstMid.transform.position.y, InstMid.transform.position.z);
            flagMid = false;
        }
         if ((InstUp.transform.position.x <= (transform.position.x + 30)) && flagUp == true)                //up
         {
             do
             {
                 randFlipX = Random.Range(-1, 2);
             }
             while (randFlipX == 0);

            randPref = Random.Range(0, up.Count + 1);
             randRot = Random.Range(-10, 11);
             go = Instantiate(down[randPref], InstUp.transform.position, Quaternion.identity);
             go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y * -1, go.transform.localScale.z);
             go.transform.Rotate(Vector3.forward * randRot);
             if (go.GetComponent<SpriteRenderer>().sortingOrder == 2)
                 go.transform.parent = GameObject.Find("layer_0").transform;

             else if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = GameObject.Find("layer_1").transform;

             else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = GameObject.Find("layer_2").transform;

             else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = GameObject.Find("layer_3").transform;

            randPos = Random.Range(upBottomRange, upUpperRange + 1);
             InstUp.transform.position = new Vector3(InstUp.transform.position.x + randPos, InstUp.transform.position.y, InstUp.transform.position.z);
             flagUp = false;
         }
        if ((InstStal.transform.position.x <= (transform.position.x + 30)) && flagStal == true)                //stalagnats
        {
            do
            {
                randFlipX = Random.Range(-1, 2);
            }
            while (randFlipX == 0);

            do
            {
                randFlipY = Random.Range(-1, 2);
            }
            while (randFlipY == 0);

            randPref = Random.Range(0, up.Count + 1);
            //randRot = Random.Range(-5, 6);
            go = Instantiate(stalagnats[randPref], InstStal.transform.position, Quaternion.identity);
            go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y * randFlipY, go.transform.localScale.z);
            //go.transform.Rotate(Vector3.forward * randRot);
            if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = GameObject.Find("layer_1").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = GameObject.Find("layer_2").transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = GameObject.Find("layer_3").transform;

            randPos = Random.Range(stalagnatsBottomRange, stalagnatsUpperRange + 1);
            InstStal.transform.position = new Vector3(InstStal.transform.position.x + randPos, InstStal.transform.position.y, InstStal.transform.position.z);
            flagStal = false;
        }
        if ((InstGround.transform.position.x <= (transform.position.x + 35)) && flagGround == true)             //ground
        {
            Instantiate(Ground, InstGround.transform.position, Quaternion.identity);
            InstGround.transform.position = new Vector3(InstGround.transform.position.x + 25.5f, InstGround.transform.position.y, InstGround.transform.position.z);
            flagGround = false;
        }
        flagDown = true;
        flagMid = true;
        flagUp = true;
        flagStal = true;
        flagGround = true;
    }
}
