using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int curAmmo;
    public int maxAmmo;
    public float speed; // ���� �ӵ�
    public float reloadSpeed; // ���� �ӵ�
    public float damage;

    private bool isActive = false;

    Transform firePos;
    LineRenderer beam;

    private void Awake()
    {
        beam = gameObject.GetComponent<LineRenderer>();
        firePos = GameObject.Find("FirePos").transform;
        beam.startWidth = 0.05f;
        beam.endWidth = 0.001f;     //���� �β� ���� �ʱ�ȭ
        beam.enabled = false;
    }

    void Update()
    {
        InputKey();
    }

    void InputKey()
    {
        // ����
        if (Input.GetMouseButton(0) && curAmmo >= 0 && !isActive)
        {
            AudioManager.instance.PlayShot();
            Debug.Log("shot!");
            --curAmmo;

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);            
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Target"))
                {
                    Debug.Log("Hit!");
                    hitInfo.transform.gameObject.GetComponent<TargetController>().OnHit(damage);
                }
                else
                {
                    if(GameManager.instance.isGaming == true)
                    {
                        GameManager.instance.life--;
                        AudioManager.instance.PlayMiss();
                    }
                        
                }
                StartCoroutine(CoolDown(speed));
            }

            beam.SetPosition(1, hitInfo.point);
            StartCoroutine(Beam());
        }

        // ����
        else if (((Input.GetKeyDown(KeyCode.R) && curAmmo < maxAmmo) || curAmmo == 0) && !isActive)
        {
            AudioManager.instance.PlayReload();
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

    IEnumerator Beam()
    {
        beam.enabled = true;
        beam.SetPosition(0, firePos.position);    
        yield return new WaitForSecondsRealtime(0.5f);
        beam.enabled = false;
    }
}

