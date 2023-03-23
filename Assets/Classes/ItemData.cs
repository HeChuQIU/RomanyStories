using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemData
{
	string ItemName { get; }
	int ItemID { get; }
	Sprite ItemSprite { get; }
}

public class ItemData : IItemData
{
	public string ItemName { get; private set; }

	public int ItemID { get; private set; }

	public Sprite ItemSprite { get; private set; }
}
