using UnityEngine;
using System.Collections;
using UnityEditor;

public static class MeshPlane{
	
	public static void CreatePlane(){
	
		Mesh newMesh = new Mesh();
		newMesh.vertices = new Vector3[]{
			new Vector3(-.5f, -.5f, -.5f),
			new Vector3(.5f, -.5f, -.5f),
			new Vector3(.5f, -.5f, .5f),
			new Vector3(-.5f, -.5f, .5f),
			
			new Vector3(-.5f, .5f, -.5f),
			new Vector3(.5f, .5f, -.5f),
			new Vector3(.5f, .5f, .5f),
			new Vector3(-.5f, .5f, .5f)
		};
			
		newMesh.triangles = new int[]{
			
			
			//Bottom
			1,2,0,
			0,2,3,
			
			//Top
			5,4,6,
			6,4,7,
			
			//Right
			0,3,4,
			4,3,7,
			
			//Front
			0,4,1,
			1,4,5
			
		};
			
		newMesh.uv = new Vector2[]{
			new Vector2(0,0),
			new Vector2(1,0),
			new Vector2(1,1),
			new Vector2(0,1),

			new Vector2(0,0),
			new Vector2(1,0),
			new Vector2(1,1),
			new Vector2(0,1),
			
			
		};
		newMesh.RecalculateNormals();
		newMesh.Optimize();
		
		AssetDatabase.CreateAsset(newMesh, "Assets/MyPlane.asset");
	}
}