using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroGenerator : MonoBehaviour
{

    [SerializeField] Vector2 downRange;
    [SerializeField] Vector2 midRange;
    [SerializeField] Vector2 upRange;
    [SerializeField] Vector2 stalagnatsRange;

    [SerializeField] List<GameObject> down;
    [SerializeField] List<GameObject> mid;
    [SerializeField] List<GameObject> up;
    [SerializeField] List<GameObject> stalagnats;
    [SerializeField] GameObject InstDown;
    [SerializeField] GameObject InstMid;
    [SerializeField] GameObject InstUp;
    [SerializeField] GameObject InstGround;
    [SerializeField] GameObject InstStal;
    [SerializeField] GameObject InstFogg;
    [SerializeField] GameObject Ground;
    [SerializeField] GameObject Fogg;
    [SerializeField] GameObject _golire;         
    [SerializeField] GameObject _breeze;  

    bool flagDown = true;
    bool flagMid = true;
    bool flagUp = true;
    bool flagGround = true;
    bool flagStal = true;
    bool flagFogg = true;         
    GameObject go;      
    float randPos;
    int randPref;
    int randFlipX = 1;
    int randFlipY = 1;
    int randRot;
    Vector3 local;

    GameObject layer_0;
    GameObject layer_1;
    GameObject layer_2;
    GameObject layer_3;
    void Start()
    {                                       
        layer_0 = GameObject.Find("layer_0");
        layer_1 = GameObject.Find("layer_1");
        layer_2 = GameObject.Find("layer_2");
        layer_3 = GameObject.Find("layer_3");
    }

    void sort(GameObject go)
    {
        if(go.GetComponent<SpriteRenderer>().sortingOrder == 2)
            go.transform.parent = layer_0.transform;

        else if(go.GetComponent<SpriteRenderer>().sortingOrder == -1)
            go.transform.parent = layer_1.transform;

        else if(go.GetComponent<SpriteRenderer>().sortingOrder == -2)
            go.transform.parent = layer_2.transform;

        else if(go.GetComponent<SpriteRenderer>().sortingOrder == -3)
            go.transform.parent = layer_3.transform;
    }

    void getRand(bool flipY, List<GameObject> prefabs, int rot, Vector2 range)
    {
        randFlipX = Random.Range(0, 2);
        if(randFlipX == 0)
            randFlipX = -1;
        if(flipY == true)
        {
            randFlipY = Random.Range(0, 2);
            if(randFlipY == 0)
                randFlipY = -1;
        }
        randPref = Random.Range(0, prefabs.Count);
        randRot = Random.Range(-rot, rot + 1);
        randPos = Random.Range(range.x, range.y + 1);
    }

    void Generate(List<GameObject> prefabs, int rot, GameObject InstPoint, Vector2 range, bool flag, bool flipY, bool up)
    {
        getRand(flipY, prefabs, rot, range);
        go = Instantiate(prefabs[randPref], InstPoint.transform.position, Quaternion.identity);
        if(up == false)
            go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y, go.transform.localScale.z);

        else
            go.transform.localScale = new Vector3(go.transform.localScale.x * randFlipX, go.transform.localScale.y * -1, go.transform.localScale.z);

        go.transform.Rotate(Vector3.forward * randRot);
        sort(go);
        InstPoint.transform.position = new Vector3(InstPoint.transform.position.x + randPos, InstPoint.transform.position.y, InstPoint.transform.position.z);
        flag = false;
    }

    void Update()
    {   
        if((InstDown.transform.position.x <= (transform.position.x + 30)) && flagDown == true) //down
            Generate(down, 10, InstDown, downRange, flagDown, false, false);

        if((InstMid.transform.position.x <= (transform.position.x + 30)) && flagMid == true) //mid
            Generate(mid, 10, InstMid, midRange, flagMid, false, false);

        if((InstUp.transform.position.x <= (transform.position.x + 30)) && flagUp == true) //up
            Generate(up, 10, InstUp, upRange, flagUp, false, true);

        if((InstStal.transform.position.x <= (transform.position.x + 30)) && flagStal == true) //stalagnats
            Generate(stalagnats, 0, InstStal, stalagnatsRange, flagStal, true, false);

        if((InstGround.transform.position.x <= (transform.position.x + 35)) && flagGround == true) //ground
        {
            Instantiate(Ground, InstGround.transform.position, Quaternion.identity);  
            InstGround.transform.position = new Vector3(InstGround.transform.position.x + 25.5f, InstGround.transform.position.y, InstGround.transform.position.z);
            flagGround = false;
        }
        if(InstFogg && (InstFogg.transform.position.x <= (transform.position.x + 80)) && flagFogg == true)  //fogg
        {
            Instantiate(Fogg, InstFogg.transform.position, Quaternion.identity);
            InstFogg.transform.position = new Vector3(InstFogg.transform.position.x + 102.4f, InstFogg.transform.position.y, InstFogg.transform.position.z);
            flagFogg = false;
        }
        flagDown = true;
        flagMid = true;
        flagUp = true;
        flagStal = true;
        flagGround = true;
        flagFogg = true;
    }
}
