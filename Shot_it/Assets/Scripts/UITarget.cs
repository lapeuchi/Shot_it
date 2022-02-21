using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITarget : MonoBehaviour
{
    public Define.Mode mode;

    public bool startButton;

    private void Start()
    {

    }

    private void Update()
    {
        SelctMode();
    }

    void SelctMode()
    {
        if (gameObject.GetComponent<TargetController>().isHit)
        {
            if (startButton && GameManager.instance.curMode == Define.Mode.None)
            {
                Debug.Log("모드 선택");
                StartCoroutine(UI.Notice("시작 전 모드를 선택해 주세요."));
            }
               

            if (startButton && GameManager.instance.curMode != Define.Mode.None)
            {
                Debug.Log("GameStart");
                GameManager.instance.isGaming = true;
                return;
            }
            else
            {
                GameManager.instance.curMode = mode;
                gameObject.GetComponent<TargetController>().isHit = false;
            }           
        }
        
        // color
        if (startButton == false)
        {
            if (GameManager.instance.curMode == mode)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }     
    }
}
