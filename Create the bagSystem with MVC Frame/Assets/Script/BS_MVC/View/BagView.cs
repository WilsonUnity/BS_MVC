using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

//MVC_View
//添加在Canvas的空对象Bag上
//该类用于控制背包的显示
//2018_10_15

public class BagView : MonoBehaviour
{

	public static int row = 9; //行
	public static int col = 9; //列

	public int Space = 10;

	public GameObject grid; //格子预制体
	
	private float _width; //格子的宽度
	private float _height; //格子的高度

	private void Awake()
	{
		//获取格子宽高
		_width = grid.GetComponent<RectTransform>().rect.width + Space;
		_height = grid.GetComponent<RectTransform>().rect.height + Space;
	}

	private void Start()
	{
		for (int x = 0; x < row; x++)
		{
			for (int y = 0; y < col; y++)
			{
				//计算每个格子的ID值
				int id = y + x * col;
				
				//生成格子
				GameObject go = Instantiate(grid, GetCenterPosition(y,x), Quaternion.identity);

				go.name = "Item" + (id + 1);
				
				//格子置于父对象Bag
				go.transform.SetParent(this.transform);

				ShowItem(go, id);

				go.transform.GetComponent<PickUpDrop>().gridID = id;
			}
		}
	}

	
	
	//将生成的格子整体居中
	private Vector2 GetCenterPosition(int x, int y)
	{
		return new Vector2((transform.position.x - row * 0.5f * _width) + x * _width,
			(transform.position.y + col * 0.5f * _height) - y * _height);
	}

	//显示每个格子的图片
	public void ShowItem(GameObject go, int id)
	{
		Text ItemText = go.GetComponentInChildren<Text>();
		ItemText.text = ItemModel.Items[id].name;

		Image ItemImg = go.transform.GetChild(0).GetComponent<Image>();

		
		if (ItemModel.Items[id].img != null){
			ItemImg.color = Color.white;
		}else{
			ItemImg.color = Color.clear;
		}

		ItemImg.sprite = ItemModel.Items[id].img;

	}
	
	//交换后刷新背包
	public void ShowItems()
	{
		for (int i = 0; i < col * row; i++)
		{
			GameObject tempGo = this.transform.GetChild(i).gameObject;
			ShowItem(tempGo, i);
		}
	}

	//重新整齐排列，按钮触发，先立个Flag,这段代码以后要优化
	public void ReArrange()
	{
		List<Sprite> sprites = new List<Sprite>();
		for (int i = 0; i < row * col; i++)
		{
			if (ItemModel.Items[i].img!=null)
			{
				sprites.Add(ItemModel.Items[i].img);
			}
			Debug.Log(sprites.Count);
		}

		for (int i = 0; i < row * col; i++)
		{
			GameObject tempObject = transform.GetChild(i).gameObject;
			Image img = tempObject.transform.GetChild(0).GetComponent<Image>();

			if (i < sprites.Count)
			{
				img.sprite = sprites[i];
				img.color = Color.white;
				ItemModel.Items[i].img = sprites[i];
			}
			else
			{
				img.sprite = null;
				img.color = Color.clear;
				ItemModel.Items[i].img = null;
			}
			
		}
		
	}
}
