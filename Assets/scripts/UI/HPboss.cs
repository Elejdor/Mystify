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
        GameObject _treead;
    Treead treead;

    public float magicalNumber;

    // Use this for initialization
    void Start()
    {
        _treead = GameObject.Find("Treead");
        currentImage = GetComponent<Image>();
        treead = _treead.GetComponent<Treead>();
        magicalNumber = treead._hpMax / 18;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeImage();
    }

    void ChangeImage()
    {
        int index = (int)(treead._hp / magicalNumber) - 1;
        if(index > 17)
            index = 17;
        currentImage.sprite = images[index];
    }

}