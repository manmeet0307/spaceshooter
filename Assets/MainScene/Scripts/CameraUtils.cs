using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Camera))]
public class CameraUtils : MonoBehaviour {
	
	private void Awake(){
		mycam = GetComponent<Camera>();
		
	}

	public float getCamRightBound(){
		return transform.position.x+mycam.orthographicSize * mycam.aspect;
		
	}
	public float getCamLeftBound(){
		return transform.position.x-mycam.orthographicSize * mycam.aspect;
    		
	}
    	
	public float getCameraWidth(){
		return mycam.orthographicSize * 2 * mycam.aspect;		
	}
	
	public float getCameraHeight(){
		return mycam.orthographicSize * 2;
	}
	
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private Camera mycam;
}
