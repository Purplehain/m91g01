using UnityEngine;
using System.Collections;

public class GroundClick : MonoBehaviour {
	
	public Material matRoad;
	
	void OnMouseDown()
	{
		GameObject road = new GameObject("road", typeof(MeshFilter), typeof(MeshRenderer));
		road.transform.position = new Vector3(0, 0.01f, 0);
		MeshFilter mesh_filter = road.GetComponent<MeshFilter>();
		MeshRenderer mesh_renderer = road.GetComponent<MeshRenderer>();

		Mesh newMesh = new Mesh();
		
		newMesh.vertices = new Vector3[]{
			new Vector3(0, 0, 0),
			new Vector3(1, 0, 0),
			new Vector3(1, 0, 1),
			new Vector3(0, 0, 1)
		};
		
		newMesh.triangles = new int[]{
			1,0,2,
			2,0,3
		};
		
		newMesh.uv = new Vector2[]{
			new Vector2(0,0),
			new Vector2(1,0),
			new Vector2(1,1),
			new Vector2(0,1)
		};
		newMesh.RecalculateNormals();
		
		mesh_filter.mesh = newMesh;
		mesh_renderer.material = matRoad;
		
	}
}
