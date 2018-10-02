using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

    public List<Transform> targets = new List<Transform>();
    public float moveSpeed;
    public float rotSpeed;

    private Transform currentTarget;
    private int count;

    private void Start()
    {
        currentTarget = targets[count];
    }

    void Update () {

        float time = Time.deltaTime;

        if(Vector3.Distance(currentTarget.position, transform.position) > 1f)
        {
            Vector3 distance = currentTarget.position - transform.position;
            transform.Translate(distance.normalized * time, Space.World);
            transform.up = Vector3.Lerp(transform.up, distance, time);
        }
        else
        {
            if(++count >= targets.Count)
                count = 0;            

            currentTarget = targets[count];
            
        }

	}

    private void OnDrawGizmos()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if(i == 0)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.yellow;
            }
           
            Gizmos.DrawSphere(targets[i].position, 0.5f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(targets[i].position, targets[i + 1 >= targets.Count ? 0 : i + 1].position);

        }


    }
}
