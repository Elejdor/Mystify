using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroGenerator : MonoBehaviour {

    [SerializeField]int downBottomRange;
    [SerializeField]int downUpperRange;
    [SerializeField]int midBottomRange;
    [SerializeField]int midUpperRange;
    [SerializeField]int upBottomRange;
    [SerializeField]int upUpperRange;
    [SerializeField]int stalagnatsBottomRange;
    [SerializeField]int stalagnatsUpperRange;

    [SerializeField]List<GameObject> down;
    [SerializeField]List<GameObject> mid;
    [SerializeField]List<GameObject> up;
    [SerializeField]List<GameObject> stalagnats;
    [SerializeField]GameObject InstDown;
    [SerializeField]GameObject InstMid;
    [SerializeField]GameObject InstUp;
    [SerializeField]GameObject InstGround;
    [SerializeField]GameObject InstStal;
    [SerializeField]GameObject Ground;
    
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

    GameObject layer_0;
    GameObject layer_1;
    GameObject layer_2;
    GameObject layer_3;
    void Start () {
        layer_0 = GameObject.Find("layer_0");
        layer_1 = GameObject.Find("layer_1");
        layer_2 = GameObject.Find("layer_2");
        layer_3 = GameObject.Find("layer_3");
	}
	
	void Update () {
        if ((InstDown.transform.position.x <= (transform.position.x + 30)) && flagDown==true)               //down
        {
            do
            {
                randFlipX = Random.Range(-1, 2);
            }
            while (randFlipX == 0);

            randPref = Random.Range(0, down.Count);
            randRot = Random.Range(-10, 11);
            go = Instantiate(down[randPref], InstDown.transform.position, Quaternion.identity);
            go.transform.localScale = new Vector3(go.transform.localScale.x*randFlipX, go.transform.localScale.y, go.transform.localScale.z);
            go.transform.Rotate(Vector3.forward * randRot);
            if (go.GetComponent<SpriteRenderer>().sortingOrder == 2)
                go.transform.parent = layer_0.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = layer_1.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = layer_2.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = layer_3.transform;

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

            randPref = Random.Range(0, mid.Count);
            randRot = Random.Range(-10, 11);
            go = Instantiate(mid[randPref], InstMid.transform.position, Quaternion.identity);
            go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y, go.transform.localScale.z);
            go.transform.Rotate(Vector3.forward * randRot);
            if (go.GetComponent<SpriteRenderer>().sortingOrder == 2)
                go.transform.parent = layer_0.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = layer_1.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = layer_2.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = layer_3.transform;

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

             randPref = Random.Range(0, up.Count);
             randRot = Random.Range(-10, 11);
             go = Instantiate(up[randPref], InstUp.transform.position, Quaternion.identity);
             go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y * -1, go.transform.localScale.z);
             go.transform.Rotate(Vector3.forward * randRot);
             if (go.GetComponent<SpriteRenderer>().sortingOrder == 2)
                 go.transform.parent = layer_0.transform;

             else if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = layer_1.transform;

             else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = layer_2.transform;

             else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = layer_3.transform;

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

            randPref = Random.Range(0, stalagnats.Count);
            //randRot = Random.Range(-5, 6);
            go = Instantiate(stalagnats[randPref], InstStal.transform.position, Quaternion.identity);
            go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y * randFlipY, go.transform.localScale.z);
            //go.transform.Rotate(Vector3.forward * randRot);
            if (go.GetComponent<SpriteRenderer>().sortingOrder == -1)
                go.transform.parent = layer_1.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -2)
                go.transform.parent = layer_2.transform;

            else if (go.GetComponent<SpriteRenderer>().sortingOrder == -3)
                go.transform.parent = layer_3.transform;

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
