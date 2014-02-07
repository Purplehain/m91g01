using UnityEngine;
using System.Collections;

public class ShipProperties : MonoBehaviour 
{
	public string name;
	public string desc;
	
	public float maxSpeed;
	public float curSpeed;
	public float tarSpeed;
	
	public float accel;
	public float spinSpeed;
	
	public float weight;
	public float cargo;
	
	public bool docked;
	
	public void Update()
	{
		if(!docked){
			UpdateSpeed();
		}
		
	}
	
	public void UpdateSpeed()
	{
		if(curSpeed < tarSpeed)
		{
			curSpeed += accel * Time.deltaTime;
		}
		
		if(curSpeed > tarSpeed)
		{
			curSpeed -= (accel*2)*Time.deltaTime;
		}
	}
}
