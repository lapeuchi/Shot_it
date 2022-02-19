using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        Init();
    }

    public bool isGaming;

    public Define.Mode curMode;

    GameObject gameZone;

    public int life;
    Transform target;
    private void Init()
    {
        target = GameObject.Find("Setting Target").transform;
        gameZone = GameObject.FindWithTag("GameZone");
        curMode = Define.Mode.None;
        isGaming = false;
    }

    private void Update()
    {
        if (isGaming)
        {
            target.gameObject.SetActive(false);
        }
        else
        {
            target.gameObject.SetActive(true);
        }
    }
}
