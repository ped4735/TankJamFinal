using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float velocity;
	public float range;
	private float contador;

	private bool _changeSide;

	void Start ()
	{
		
	}
	
	
	void Update ()
	{
		contador += Time.deltaTime;
		
		
		if(contador<=range)
		{
			transform.Translate(transform.up*velocity*Time.deltaTime,Space.World);

		}
		else
		{
			
		}
		
		
	}
}
