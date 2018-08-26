using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	float maxDistance;
	RectTransform parentTransform;
	RectTransform recTransform;
	RectTransform canvasTransform;

	public Spaceship spaceship;

	void Awake(){
		parentTransform = gameObject.transform.parent.GetComponent<RectTransform>();
		canvasTransform = parentTransform.gameObject.GetComponentInParent<Canvas>().GetComponent<RectTransform>();

		recTransform = gameObject.GetComponent<RectTransform>();
		maxDistance = parentTransform.rect.width / 2f - recTransform.rect.width / 2f;
	}

	void Start(){
		
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData){
//		throw new System.NotImplementedException ();

	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData){
//		throw new System.NotImplementedException ();
		//центр родителя относительно контейнера
		Vector2 parentCenter = new Vector2(
			parentTransform.anchorMax.x * canvasTransform.rect.width + parentTransform.anchoredPosition.x,
			parentTransform.anchorMax.y * canvasTransform.rect.height + parentTransform.anchoredPosition.y
		);
//		print (Screen.width + "\t" + cs.referenceResolution.x);


		float mx = Input.mousePosition.x / (float)Screen.width;
		float my = Input.mousePosition.y / (float)Screen.height;

		Vector2 pos = new Vector2 (
			              mx * canvasTransform.rect.width - parentCenter.x,
			              my * canvasTransform.rect.height - parentCenter.y
		              );

		float dist = Vector2.Distance (Vector2.zero, pos);
		if (dist > maxDistance) {
			pos = Vector2.ClampMagnitude (pos, maxDistance);
		}
		transform.localPosition = pos;



		spaceship.Acceleration (pos.x/maxDistance,pos.y/maxDistance);

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData){
//		throw new System.NotImplementedException ();
		transform.localPosition = Vector2.zero;
		spaceship.Acceleration (Vector2.zero);
	}

	#endregion
	

}
