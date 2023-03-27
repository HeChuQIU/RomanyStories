using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using System.Reflection;
<<<<<<< HEAD
using Assets.Classes;

namespace Assets.Scripts
{

	public class Inventory : MonoBehaviour
	{
		[SerializeField]
		private IInventoryData inventoryData;
		public IInventoryData InventoryData { get => inventoryData; set => inventoryData = value; }
	}
}
=======

public interface IInventory
{
	IList<IItemStack> ItemStacks { get; }
	void AddItemStack(IItemStack itemStack);
	void AddItemStacks(IEnumerable<IItemStack> itemStacks);
	void RemoveItemStack(IItemStack itemStack);
	void RemoveItemStacks(IEnumerable<IItemStack> itemStacks);
	bool HasSpaceFor(IItemStack itemStack);
}

public class Inventory : MonoBehaviour, IInventory
{
	[SerializeField]
	private List<IItemStack> itemStacks = new();
	public IList<IItemStack> ItemStacks => itemStacks;

	public void AddItemStack(IItemStack itemStack)
	{
		for (int i = 0; i < itemStacks.Count; i++)
		{
			if (this.ItemStacks[i].TryMergeWith(itemStack))
				return;
		}
	}

	public void AddItemStacks(IEnumerable<IItemStack> itemStacks)
	{
		foreach (var itemStack in itemStacks)
		{
			AddItemStack(itemStack);
		}
	}

	public bool HasSpaceFor(IItemStack item)
	{
		throw new NotImplementedException();
	}

	public void RemoveItemStack(IItemStack item)
	{
		throw new NotImplementedException();
	}

	public void RemoveItemStacks(IEnumerable<IItemStack> items)
	{
		throw new NotImplementedException();
	}

	private bool TryFindSpaceFor(IItemStack itemStack, out int index)
	{
		for (int i = 0; i < itemStacks.Count; i++)
		{
			index = i;
			if (this.ItemStacks[i].TryMergeWith(itemStack))
				return true;
		}
		index = -1;
		return false;
	}
}
>>>>>>> 9f759adf2544746a3cd60c2dd764fd92512c8d28
