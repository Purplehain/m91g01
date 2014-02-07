using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour {
	
	public int size;
	public int height;
	public bool created = false;
	public Material mat;
	public GameObject block;
	public Dictionary<Vector3, Transform> blocks = new Dictionary<Vector3, Transform>();
	
	void Awake(){
		/*GameObject ccube = new GameObject("Block");
		ccube.AddComponent<MeshCube>();
		ccube.renderer.material = mat;*/
		CreateWorld();
	}
	
	public void CreateWorld(){
		if(!created)
		{
			GameObject newWorld = new GameObject("World");
			for(int x = -size/2; x < size/2; x++){
				for(int y = 0; y < height; y++){
					for(int z = -size/2; z < size/2; z++){
						GameObject newBlock = GameObject.Instantiate(block,new Vector3(x,y,z), Quaternion.identity) as GameObject;
						blocks.Add(new Vector3(x, y, z), newBlock.transform);
						if(y > height * 0.8f){
							newBlock.GetComponent<Block>().blockType = BlockType.air;
						} else {
							newBlock.GetComponent<Block>().blockType = BlockType.dirt;
						}
					}
				}
			}
			created = true;
		}
	}
}
