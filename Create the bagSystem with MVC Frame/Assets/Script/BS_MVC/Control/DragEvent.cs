using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragEvent : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
	private int gridID;
	[HideInInspector]public static int lastID;

	private void Start()
	{
		gridID = GetComponentInParent<PickUpDrop>().gridID;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		lastID = gridID;
		PickUpDrop.SwapItem(gridID);
		Debug.Log("Begin");
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("Draging");
		//Do nothing,but the function hava to exit
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("EnDDrag");
		PickUpDrop.SwapItem(gridID);
	}
}
