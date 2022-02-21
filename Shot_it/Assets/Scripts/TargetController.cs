using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float hp;
    public float speed;

    public bool ui;

    public bool isHit = false;

    public static float reaction;
    public static float best;

    private void Awake()
    {
        if (ui == false)
            gameObject.name = "Target";
        reaction = 0f;
        if (GameMode.tracking == true)
            StartCoroutine(RotateCool());
       
    }

    private void Update()
    {
        if(isHit==false)
        reaction += Time.deltaTime;
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
            if (reaction <= best)
                best = reaction;
            UI.best_Text.text = $"reaction : {TargetController.reaction.ToString("F2")}";
            UI.reaction_Text.text = $"best : {TargetController.best.ToString("F2")}";
            AudioManager.instance.PlayHit();
            Destroy(gameObject, 0.1f);
        }

        isHit = false;
    }
}
