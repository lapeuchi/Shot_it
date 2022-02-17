using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Text ammo_Text;
    GameObject gun;

    void Awake()
    {
        gun = GameObject.FindWithTag("Gun");
        ammo_Text = GameObject.Find("Ammo_Text").GetComponent<Text>();
    }

    void Update()
    {
        ammo_Text.text = $"{gun.GetComponent<GunController>().curAmmo} / {gun.GetComponent<GunController>().maxAmmo}";
    }
}
