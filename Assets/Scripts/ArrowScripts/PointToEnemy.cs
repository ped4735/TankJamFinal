using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToEnemy : MonoBehaviour {

	public GameObject enemy;
	private SpriteRenderer arrowSpriteRenderer;
	public float distToChangeAlpha = 20f;
	public float baseAlpha;

	[Header("COLOR CONFIG")]
	[Range(0,1)]
	public float alphaMultiplier = 0.6f;

	[Range(0,5)]
	public float greenMultiplier = 3.7f;

	void Start () {
		arrowSpriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		baseAlpha = arrowSpriteRenderer.color.a;

		distToChangeAlpha = 20f;
		alphaMultiplier = 0.6f;
		greenMultiplier = 3.7f;


	}
	
	// Update is called once per frame
	void Update () {
		if (enemy == null){
			Destroy(this.gameObject);
		}else{
			this.transform.right = enemy.transform.position - this.transform.position;
			changeAlpha(this.transform.position,enemy.transform.position);
		}
		
	}

	public void SetEnemy(GameObject enemy){
		this.enemy = enemy;
	}
	
	public void changeAlpha(Vector3 thisPosition, Vector3 enemyPosition){
		float dist = Vector3.Distance(thisPosition,enemyPosition);

		float alpha =  alphaMultiplier*Mathf.Clamp(
			baseAlpha +alphaMultiplier + ((- dist)/(distToChangeAlpha)),
			baseAlpha,
			1f);
		// Debug.Log(dist + " " + ((distToChangeAlpha - dist)/distToChangeAlpha) + " " + ((distToChangeAlpha - dist)/distToChangeAlpha) + " " + alpha +" "+ baseAlpha);
		
		float green =  1f - greenMultiplier*Mathf.Clamp(baseAlpha + ((distToChangeAlpha - dist)/(2*distToChangeAlpha)),0,1f);

		Color c = arrowSpriteRenderer.color;
		c.a = alpha;
		if (dist<distToChangeAlpha){
			c.g=0f;
		}else{
			c.g = green; //so becomes yellow
		}
		arrowSpriteRenderer.color = c;
		
		
	}

	// private void setBaseAlpha(float alpha){
	// 	Color c = arrowSpriteRenderer.color;
	// 	c.a = alpha;
	// 	arrowSpriteRenderer.color = c;
	// }

	// public void setDistToChangeAlpha(float d){
	// 	distToChangeAlpha = d;
	// }

}
