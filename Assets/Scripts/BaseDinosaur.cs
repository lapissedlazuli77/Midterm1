using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseDinosaur : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nav;

    bool hunting = false;

    float timer = 0;
    float timertime;

    public float posx;
    public float posz;

    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        timertime = Random.Range(4f, 10f);

        posx = Random.Range(-100f, 100f);
        posz = Random.Range(-100f, 100f);
        destination.Set(posx, 0, posz);
    }

    // Update is called once per frame
    void Update()
    {
        if (hunting)
        {
            nav.destination = player.position;
        }
        else
        {
            nav.destination = destination;
            if (timer >= timertime)
            {
                posx = Random.Range(-100f, 100f);
                posz = Random.Range(-100f, 100f);
                destination.Set(posx, 0, posz);

                timertime = Random.Range(4f, 10f);
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    }
}
