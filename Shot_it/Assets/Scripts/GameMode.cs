using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public int maxLife = 3;
    GameObject target;
    Vector3 vec;
    GameObject go;
    public static bool tracking;

    private void Awake()
    {
        target = Resources.Load<GameObject>("Prefabs/Target");        
    }

    private void Start()
    {
        StartCoroutine(Game());
    }

    void PickPos()
    {
        vec.x = Random.Range(-8.0f, 8.0f);
        vec.y = Random.Range(1.5f, 6.0f);
        vec.z = Random.Range(16.0f, 28.0f);       
    }

    IEnumerator SimpleMode()
    {
        PickPos();
        go = Instantiate(target, vec, Quaternion.Euler(Vector3.zero), transform);
        yield return new WaitUntil(() => go.GetComponent<TargetController>().hp <= 0);
        if (GameManager.instance.life > 0)
            StartCoroutine(SimpleMode());
    }

    IEnumerator TrackingMode()
    {
        tracking = true;
        PickPos();
        go = Instantiate(target, vec, Quaternion.Euler(Vector3.zero), transform);
        yield return new WaitUntil(() => go.GetComponent<TargetController>().hp <= 0);
        if (GameManager.instance.life > 0)
            StartCoroutine(TrackingMode());
    }

    IEnumerator Game()
    {
        yield return new WaitUntil(() => GameManager.instance.isGaming == true);
        GameManager.instance.life = maxLife;
        switch (GameManager.instance.curMode)
        {
            case Define.Mode.Simple:
                Debug.Log("SimpleMode");
                StartCoroutine(SimpleMode());
                break;

            case Define.Mode.Tracking:
                Debug.Log("TrackingMode");
                StartCoroutine(TrackingMode());
                break;
        }

        yield return new WaitUntil(() => GameManager.instance.life <= 0);
        GameManager.instance.curMode = Define.Mode.None;
        GameManager.instance.isGaming = false;
        tracking = false;
        Destroy(go);
        StartCoroutine(Game());
    }
}
