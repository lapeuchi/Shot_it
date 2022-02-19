using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float hp;
    public float speed;

    public bool ui;

    public bool isHit = false;

    private void Start()
    {
        if (GameMode.tracking == true)
            StartCoroutine(RotateCool());
    }

    private void Update()
    {
        if (GameMode.tracking == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);       
        }
    }

    IEnumerator RotateCool()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        speed = Random.Range(1.0f, 5.0f);
        yield return new WaitForSecondsRealtime(Random.Range(0.3f, 1.2f));
        StartCoroutine(RotateCool());
    }

    public void OnHit(float damage)
    {
        isHit = true;
     
        if (ui == true)   
            return;

        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject, 0.1f);
        }    
    }
}
