using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private static Text notice_Text;
    private static Text ammo_Text;
    private static Text life_Text;
    private GameObject gun;

    void Awake()
    {
        notice_Text = GameObject.Find("Notice_Text").GetComponent<Text>();
        notice_Text.text = null;
        gun = GameObject.FindWithTag("Gun");
        ammo_Text = GameObject.Find("Ammo_Text").GetComponent<Text>();
        life_Text = GameObject.Find("Life_Text").GetComponent<Text>();
    }

    void Update()
    {
        ammo_Text.text = $"{gun.GetComponent<GunController>().curAmmo} / {gun.GetComponent<GunController>().maxAmmo}";
        
        if(GameManager.instance.isGaming == true)
        {
            life_Text.text = $"Life: {GameManager.instance.life}";
        }
        else
        {
            life_Text.text = null;
        }
    }

    public static IEnumerator Notice(string say)
    {
        notice_Text.color = new Vector4(183, 163, 84, 255);
        notice_Text.text = say;
        yield return new WaitForSecondsRealtime(2f);
        for (float f = 1f; f >= 0; f -= 0.02f)
        {
            Color c = notice_Text.color;
            c.a = f;
            notice_Text.color = c;
            yield return null;
        }
        notice_Text.color = new Color(183, 163, 84, 0);
    }
}
