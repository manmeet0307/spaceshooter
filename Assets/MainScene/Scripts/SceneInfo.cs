using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SceneInfo : MonoBehaviour{





	private float initHeight;
	private float initAspect;
	private void Awake(){

//		Camera.main.aspect = 16 / 9.0f;
		initHeight = 5;
		Camera.main.orthographicSize = initHeight;
//		initAspect = Camera.main.aspect;
//		Camera.main.ResetAspect();
		
	}

	private void Start (){

//		Camera.main.orthographicSize = (1/Camera.main.aspect);
	}
	
	private void Update (){		
	
//		Debug.Log("Screen width and height is "+Screen.width+" "+1.0f*Screen.height);
//		Debug.Log("cam aspect is "+Camera.main.aspect);
//		
//		Camera.main.orthographicSize = (initHeight*initAspect) / Camera.main.aspect;

	}
}
