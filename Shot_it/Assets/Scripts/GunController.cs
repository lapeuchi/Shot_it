using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int curAmmo;
    public int maxAmmo; 
    public float speed; // 연사 속도
    public float reloadSpeed; // 장전 속도

    private bool isActive = false;

    Transform firePos;
    private void Awake()
    {
        firePos = GameObject.Find("FirePos").transform;
    }

    void Update()
    {
        if(isActive == false)
            InputKey();
    }

    void InputKey()
    {
        if (Input.GetMouseButtonDown(0) && curAmmo >= 0)
        {
            Debug.Log("shot!");
            --curAmmo;
            Physics.Raycast(firePos.position, Vector3.forward);
            Debug.DrawRay(firePos.position, firePos.localPosition*4, Color.red, 0.5f);
            StartCoroutine(CoolDown(speed));
        }

        if ((Input.GetKeyDown(KeyCode.R) && curAmmo < maxAmmo) || curAmmo == 0)
        {
            Debug.Log("reload!");
            StartCoroutine(CoolDown(reloadSpeed));
            curAmmo = maxAmmo;
        }
    }

    IEnumerator CoolDown(float coolTime)
    {
        isActive = true;
        yield return new WaitForSecondsRealtime(coolTime);
        isActive = false;
    }
}
