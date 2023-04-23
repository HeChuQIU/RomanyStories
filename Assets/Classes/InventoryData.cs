using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Classes
{
	public interface IInventoryData
	{
		IList<IItemStack> ItemStacks { get; }
		void AddItemStack(IItemStack itemStack);
		void AddItemStacks(IEnumerable<IItemStack> itemStacks);
		void RemoveItemStack(IItemStack itemStack);
		void RemoveItemStacks(IEnumerable<IItemStack> itemStacks);
		bool HasSpaceFor(IItemStack itemStack);
	}

	[Serializable]
	public class InventoryData
	{

		[SerializeField]
		private List<IItemStack> itemStacks = new();
		public IList<IItemStack> ItemStacks => itemStacks;

		public void AddItemStack(IItemStack itemStack)
		{
			for (int i = 0; i < itemStacks.Count; i++)
			{
				if (ItemStacks[i].TryMergeWith(itemStack))
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

		public bool HasSpaceFor(IItemStack itemStack)
		{
			for (int i = 0; i < itemStacks.Count; i++)
			{
				if (ItemStacks[i].IsCanMergeWith(itemStack))
					return true;
			}
			return false;
		}

		public void RemoveItemStack(IItemStack item)
		{
			IEnumerable<IItemStack> targetItemStacks =
				from itemStack in itemStacks
				where itemStack.Item.Id == item.Item.Id
				select itemStack;
			int sumAmount = 0;
			foreach (var itemStack in targetItemStacks)
			{
				if (sumAmount >= item.Amount)
					break;
			}
			int remainAmount = item.Amount;
			foreach (var itemStack in targetItemStacks)
			{
				if (itemStack.Amount <= remainAmount)
				{
					remainAmount -= itemStack.Amount;
					itemStack.Clear();
				}
				else if (itemStack.Amount > remainAmount)
				{
					itemStack.Amount -= remainAmount;
					remainAmount = 0;
				}
			}
		}

		public void RemoveItemStacks(IEnumerable<IItemStack> itemStacks)
		{
			foreach (var itemStack in itemStacks)
			{
				RemoveItemStack(itemStack);
			}
		}

		private bool TryFindSpaceFor(IItemStack itemStack, out int index)
		{
			for (int i = 0; i < itemStacks.Count; i++)
			{
				index = i;
				if (ItemStacks[i].TryMergeWith(itemStack))
					return true;
			}
			index = -1;
			return false;
		}
	}
}
