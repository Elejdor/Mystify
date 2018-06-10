using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPscript : MonoBehaviour
{
    [SerializeField]
    Image currentImage;
    [SerializeField]
    Sprite[] images;
    [SerializeField]
    GameObject _player;
    float magicalNumber;

    // Use this for initialization
    void Start ()
    {
        currentImage = GetComponent<Image>();
        magicalNumber = _player.GetComponent<PlayerStats>()._maxHP / 18;
    }
	
	// Update is called once per frame
	void Update ()
    {                                                                             
        ChangeImage();                        
	}

    void ChangeImage()
    {
        int index = (int)(_player.GetComponent<PlayerStats>()._hp / magicalNumber) - 1;
        if(index > 17)
            index = 17;
        currentImage.sprite = images[index]; 
    }

}
