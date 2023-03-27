using Assets.Classes;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IItemStack
{
	IItemData Item { get; set; }
	int Amount { get; set; }
	bool IsCanMergeWith(IItemStack item);
	bool TryMergeWith(IItemStack itemStack);
	void Clear();
}

public class ItemStack : IItemStack
{
	public IItemData Item { get; set; }

	public int Amount { get; set; }

	public bool IsCanMergeWith(IItemStack itemStack)
	{
		if (Item == null || itemStack.Item == null)
			return true;
		if (Item.Id != itemStack.Item.Id)
			return false;
		if (Amount + itemStack.Amount <= GameManager.Instance.ItemSystem
			.ItemRegisterDatas[itemStack.Item.Id].MaxStackSize)
			return true;
		return false;
	}

	public static bool IsCanMerge(IItemStack itemStack1,IItemStack itemStack2)
	{
		return itemStack1.IsCanMergeWith(itemStack2);
	}

	public bool TryMergeWith(IItemStack itemStack)
	{
		if(!IsCanMergeWith(itemStack))
			return false;
		if (Item == null)
		{
			Item = itemStack.Item;
			return true;
		}
		if (itemStack.Item == null)
			return true;
		Amount += itemStack.Amount;
		return true;
	}

	public void Clear()
	{
		Item = null;
		Amount = 0;
	}
}
