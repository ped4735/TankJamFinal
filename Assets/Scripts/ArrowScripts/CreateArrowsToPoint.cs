using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArrowsToPoint : MonoBehaviour {

	GameObject[] enemies;
	public GameObject arrowPrefab;


	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach(GameObject enemie in enemies){
			GameObject obj = Instantiate(arrowPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<PointToEnemy>().SetEnemy(enemie);
			obj.transform.SetParent(this.transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
