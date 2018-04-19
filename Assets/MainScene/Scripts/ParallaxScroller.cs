using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour{


	
	public float scrollSpeed = 5;


	private GameObject prev;
	private GameObject next;
	private Vector3 initPrevPositon;
	private Vector3 initNextPositon;


	void Start (){
		
		
		prev = transform.Find("Prev").gameObject;
		next = transform.Find("Next").gameObject;


		initNextPositon = next.transform.localPosition;
		initPrevPositon = prev.transform.localPosition;
		

	}
	
	void Update (){
		
		
		
		
		if (next.transform.localPosition.y <= initPrevPositon.y){
		
			
			//move prev to next pos

			prev.transform.localPosition = initNextPositon;
			next.transform.localPosition = initPrevPositon;

		
			//swap next and prev
			GameObject temp = next;
			next = prev;
			prev = temp;
		}
		
		Vector3 move = new Vector3(0,scrollSpeed * Time.deltaTime,0);
		prev.transform.localPosition -=move;
		next.transform.localPosition -=move;



	}
}
