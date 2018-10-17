using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpDrop : MonoBehaviour,IDropHandler
{

	public int gridID;

	public static ItemModel.Item pickItem;

	private void Start()
	{
		pickItem = new ItemModel.Item("", null);
	}

	public static void SwapItem(int gridID)
	{
		ItemModel.Item temp = pickItem;
		pickItem = ItemModel.Items[gridID];
		ItemModel.Items[gridID] = temp;
		
		GameObject.Find("Bag").GetComponent<BagView>().ShowItems();
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (gridID != DragEvent.lastID)
		{
			SwapItem(gridID);
		}
	}
}
