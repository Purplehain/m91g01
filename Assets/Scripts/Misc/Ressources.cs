using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ressource
{	
	public int amount;
	public float basePrice;
	public float weight;
	public string name;
	public string desc;
	
	public Ressource(int a, float b, float w, string n, string d){
		amount = a;
		basePrice = b;
		weight = w;
		name = n;
		desc = d;
	}
	
	
}
