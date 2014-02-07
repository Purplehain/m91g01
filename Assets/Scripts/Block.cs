using UnityEngine;
using System.Collections;

public enum BlockType{
	air,
	dirt,
	grass,
	stone
}

public class Block : MonoBehaviour {
	
	public BlockType blockType;
	public Material mat;
	public Transform[] neighbours;
	
	public void Start(){
		foreach(Transform child in transform){
			CheckForNeighbors(child);
		}
	}
	
	public void CheckForNeighbors(Transform ch)
	{
		if(Physics.Raycast(ch.position, (ch.position-transform.position).normalized, 1f)){
			//Block block = hit.transform.GetComponent<Block>();
			//if(block.blockType != BlockType.air)
			//{
				ch.gameObject.SetActive(false);
			//}
			
			
		}
	}
}
