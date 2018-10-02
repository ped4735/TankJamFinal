using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTankMoviment : MonoBehaviour {

	public Transform turret;
	public float speed,turnSpeed;

	public bool isTurretUnderControl;



	void Start () {
		turret = this.transform.GetChild(1);
		Debug.Log(turret.gameObject.name);
		
	}
	

	void Update () {
		 BasicMoviment();
		if (Input.GetKeyDown (KeyCode.Space)) {
			isTurretUnderControl = !isTurretUnderControl;
		}
	}

	void BasicMoviment(){
		/*
		if (Input.GetKeyDown(KeyCode.W)){
			this.transform.position += new Vector3(0f,speed,0f);
		}
		*/
		if (!isTurretUnderControl) {
			float moveVertical = Input.GetAxis ("Vertical") * speed * Time.deltaTime;

			transform.Translate (Vector3.left * moveVertical);
			transform.Rotate (0, 0, -Input.GetAxis ("Horizontal") * turnSpeed);

		} else {
			turret.transform.Rotate (0, 0, -Input.GetAxis ("Horizontal") * turnSpeed);

		}
			
	}
}
