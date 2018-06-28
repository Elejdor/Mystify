using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPboss : MonoBehaviour
{
    [SerializeField]
        Image currentImage;
    [SerializeField]
        Sprite[] images;
    [SerializeField]
        GameObject _anger;
    Anger anger;

    public float magicalNumber;

    // Use this for initialization
    void Start()
    {
        _anger = GameObject.Find("Anger");
        currentImage = GetComponent<Image>();
        anger = _anger.GetComponent<Anger>();
        magicalNumber = anger._hpMax / 18;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeImage();
    }

    void ChangeImage()
    {
        int index = (int)(anger._hp / magicalNumber) - 1;
        if(index > 17)
            index = 17;
        currentImage.sprite = images[index];
    }

}