using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshCube : MonoBehaviour {
	
	Mesh mesh;
	public Material mat;
	List<Vector3> Points = new List<Vector3>();
	List<Vector3> Verts;
	List<Vector2> UVs;
	List<int> Tris;
	float size = 0.5f;
	GameObject gameObject;
	
	public bool visi_front = true;
	public bool visi_back = true;
	public bool visi_left = true;
	public bool visi_right = true;
	public bool visi_top = true;
	public bool visi_bottom = true;
	
	public void Awake()
	{
		Points = new List<Vector3>();
		Points.Add(new Vector3(-size,  size, -size));
		Points.Add(new Vector3( size,  size, -size));
		Points.Add(new Vector3( size, -size, -size));
		Points.Add(new Vector3(-size, -size, -size));
		
		Points.Add(new Vector3( size,  size, size));
		Points.Add(new Vector3(-size,  size, size));
		Points.Add(new Vector3(-size, -size, size));
		Points.Add(new Vector3( size, -size, size));
		
		Verts = new List<Vector3>();
		Tris = new List<int>();
		UVs = new List<Vector2>();
		gameObject = transform.gameObject;
		CreateMesh();
	}
	
	private void CreateMesh(){
		gameObject.AddComponent("MeshFilter");
		gameObject.AddComponent("MeshRenderer");
		gameObject.AddComponent("MeshCollider");
		
		mat = Resources.Load("Materials/Default") as Material;
		
		
		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
		mesh = meshFilter.sharedMesh;
		if(mesh == null)
		{
			meshFilter.mesh = new Mesh();
			mesh = meshFilter.sharedMesh;
		}
		
		MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
		mesh.Clear();
		UpdateMesh();
	}
	
	private void UpdateMesh()
	{
		//front plane
		Verts.Add(Points[0]); Verts.Add(Points[1]); Verts.Add (Points[2]); Verts.Add (Points[3]);
		
		if(visi_front){
			Tris.Add(0); Tris.Add(1); Tris.Add(2);
			Tris.Add(2); Tris.Add(3); Tris.Add(0);
			
			UVs.Add(new Vector2(0,1));
			UVs.Add(new Vector2(1,1));
			UVs.Add(new Vector2(1,0));
			UVs.Add(new Vector2(0,0));
		}
		
		//back plane
		Verts.Add(Points[4]); Verts.Add(Points[5]); Verts.Add (Points[6]); Verts.Add (Points[7]);
		
		if(visi_back){
			Tris.Add(4); Tris.Add(5); Tris.Add(6);
			Tris.Add(6); Tris.Add(7); Tris.Add(4);
			
			UVs.Add(new Vector2(0,1));
			UVs.Add(new Vector2(1,1));
			UVs.Add(new Vector2(1,0));
			UVs.Add(new Vector2(0,0));
		}
		
		//left plane
		Verts.Add(Points[5]); Verts.Add(Points[0]); Verts.Add (Points[3]); Verts.Add (Points[6]);
		
		if(visi_left){
			Tris.Add(8); Tris.Add(9); Tris.Add(10);
			Tris.Add(10); Tris.Add(11); Tris.Add(8);
			
			UVs.Add(new Vector2(0,1));
			UVs.Add(new Vector2(1,1));
			UVs.Add(new Vector2(1,0));
			UVs.Add(new Vector2(0,0));
		}
		
		//right plane
		Verts.Add(Points[1]); Verts.Add(Points[4]); Verts.Add (Points[7]); Verts.Add (Points[2]);
		
		if(visi_right){
			Tris.Add(12); Tris.Add(13); Tris.Add(14);
			Tris.Add(14); Tris.Add(15); Tris.Add(12);
			
			UVs.Add(new Vector2(0,1));
			UVs.Add(new Vector2(1,1));
			UVs.Add(new Vector2(1,0));
			UVs.Add(new Vector2(0,0));
		}
		
		//top plane
		Verts.Add(Points[5]); Verts.Add(Points[4]); Verts.Add (Points[1]); Verts.Add (Points[0]);
		
		if(visi_top){
			Tris.Add(16); Tris.Add(17); Tris.Add(18);
			Tris.Add(18); Tris.Add(19); Tris.Add(16);
			
			UVs.Add(new Vector2(0,1));
			UVs.Add(new Vector2(1,1));
			UVs.Add(new Vector2(1,0));
			UVs.Add(new Vector2(0,0));
		}
		//bottom plane
		Verts.Add(Points[3]); Verts.Add(Points[2]); Verts.Add (Points[7]); Verts.Add (Points[6]);
		
		if(visi_bottom){
			Tris.Add(20); Tris.Add(21); Tris.Add(22);
			Tris.Add(22); Tris.Add(23); Tris.Add(20);
			
			UVs.Add(new Vector2(0,1));
			UVs.Add(new Vector2(1,1));
			UVs.Add(new Vector2(1,0));
			UVs.Add(new Vector2(0,0));
		}
		
		
		mesh.vertices = Verts.ToArray();
		mesh.triangles = Tris.ToArray();
		mesh.uv = UVs.ToArray();
		
		Verts.Clear();
		Tris.Clear();
		UVs.Clear();
		
		MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		
		meshCollider.sharedMesh = null;
		meshCollider.sharedMesh = mesh;
		gameObject.renderer.material = mat;
		
		mesh.Optimize();
	}
}
