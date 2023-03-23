using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IItemStack
{
	IItemData Item { get; set; }
	int Amount { get; set; }
}

public class ItemStack : IItemStack
{
	public IItemData Item { get; set; }

	public int Amount { get; set; }
}
