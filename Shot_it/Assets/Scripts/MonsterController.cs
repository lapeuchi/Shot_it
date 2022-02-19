using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform targetPos;
    bool active;
    float range = 10;
    Vector3 point;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        StartCoroutine(Cool());
    }

    void Update()
    {
        if (active == false)
        {
            if (RandomPoint(targetPos.position, range, out point))
            {
                active = true;
                targetPos.position = point;
            }
        }
        nav.SetDestination(targetPos.position);
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    IEnumerator Cool()
    {
        yield return new WaitForSecondsRealtime(Random.Range(0.5f, 2f));
        active = false;
    }
}
