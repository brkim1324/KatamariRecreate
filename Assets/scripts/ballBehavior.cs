using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehavior : MonoBehaviour {

	public GameObject collector;
	public GameObject collector2;
	public float speed;
	public float turn;
	public Rigidbody rbObject;
	private float volume;
	

	private Rigidbody rb;

	void Start ()
	{
		volume = collector.transform.localScale.x * collector.transform.localScale.y * collector.transform.localScale.z;
		rb = GetComponent<Rigidbody>();
	}

	

	void FixedUpdate ()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
		rb.AddTorque(transform.up * turn * moveHorizontal);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "collectable")
         		{
         			rb.mass += col.rigidbody.mass;
         		    Destroy(col.rigidbody);
                     col.transform.parent = transform;
         			
         		}
		if (col.gameObject.tag == "collectable2")
		{
			rb.mass += col.rigidbody.mass;
			Destroy(col.rigidbody);
			col.transform.parent = transform;
         			
		}
	}
	
	
	
}
