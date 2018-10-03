using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

    public List<Transform> targets = new List<Transform>();
    public float moveSpeed;
    public float rotSpeed;
    public float waitEveryWaypoint;

    private bool reachDestination;
    private Transform currentTarget;
    private int count;

    private void Start()
    {
        currentTarget = targets[count];
    }

    void Update () {

        float time = Time.deltaTime;
        Vector3 distance = currentTarget.position - transform.position;

       
        if(reachDestination)    
            return;
        

        if(Vector3.Distance(currentTarget.position, transform.position) > 1f)
        {
            transform.Translate(distance.normalized * time, Space.World);  
            transform.up = Vector3.Lerp(transform.up, distance, time);
        }
        else
        {
            if(++count >= targets.Count)
                count = 0;

            StartCoroutine(WaitToMove());
            currentTarget = targets[count];
            
        }

	}

    public IEnumerator WaitToMove()
    {
        reachDestination = true;
        yield return new WaitForSeconds(waitEveryWaypoint);
        reachDestination = false;
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
