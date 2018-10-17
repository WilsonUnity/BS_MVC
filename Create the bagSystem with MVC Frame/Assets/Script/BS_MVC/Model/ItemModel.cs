using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ItemModel : MonoBehaviour {

	public class Item
	{
		public string name;
		public Sprite img;

		public Item(string name,Sprite img)
		{
			this.name = name;
			this.img = img;
		}
	}

	public static List<Item> Items;
	public int size = 18;
	private Sprite[] sprite;
	
	private void Awake()
	{
		sprite = new Sprite[size];
		Items = new List<Item>();

		for (int x = 0; x < BagView.row; x++)
		{
			for (int y = 0; y < BagView.col; y++)
			{
				Items.Add(new Item("", null));
			}
		}

		for (int i = 0; i < size; i++)
		{
			string name = i < 9 ? "0" + (i + 1) : "" + (i + 1);
			sprite[i] = Resources.Load(name,typeof(Sprite)) as Sprite;
			Items[i] = new Item("", sprite[i]);
		}
	}
	
}
