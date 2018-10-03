using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyScript : MonoBehaviour {

	public void EndAnimation(){
		Destroy(this.gameObject);
	}
}
