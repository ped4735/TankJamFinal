using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSript : MonoBehaviour {

	public GameObject exp;


	public void StartExplosion(){
		GameObject obj = Instantiate(exp,this.transform.position,Quaternion.identity);
	}
}
