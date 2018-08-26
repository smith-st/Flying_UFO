using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	Rigidbody2D rb2d;
	public float power;
	public float speed;
	Vector2 acceleration = Vector2.zero;

	void Awake(){
		rb2d = gameObject.GetComponent<Rigidbody2D>	();
	}

	void FixedUpdate(){
		rb2d.AddRelativeForce (acceleration * power, ForceMode2D.Force);
		if (Vector2.Distance (Vector2.zero, rb2d.velocity) > speed) {
			rb2d.velocity = Vector2.ClampMagnitude (rb2d.velocity, speed);
		}
	}

	public void SetPower(float value){
		power = value;
	}

	public void SetSpeed(float value){
		speed = value;
	}

	public void Acceleration(Vector2 acc){
		acceleration = acc;
	}

	public void Acceleration(float x, float y){
		acceleration = new Vector2(x,y);
	}

}
