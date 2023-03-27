using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Classes
{
	public interface IItemSystem : ISingleton<ItemSystem>
	{
		IDictionary<string, IItemData> ItemRegisterDatas { get; }
		void RegisterItem(IItemData itemRegisterData);
		void RegisterItems(IEnumerable<IItemData> itemRegisterDatas);
		void UnRegisterItem(string id);
		void UnRegisterItems(IEnumerable<string> ids);
		IItemData GetItemRegisterData(string id);
		IEnumerable<IItemData> GetItemRegisterDatasByName(string itemName);
	}

	public class ItemSystem : IItemSystem
	{
		private static ItemSystem instance;
		public static ItemSystem Instance
		{
			get
			{
				instance ??= new ItemSystem();
				return instance;
			}
		}

		public IDictionary<string, IItemData> ItemRegisterDatas => itemRegisterDatas;

		private Dictionary<string, IItemData> itemRegisterDatas = new();

		public void RegisterItem(IItemData itemRegisterData)
		{
			ItemRegisterDatas.Add(itemRegisterData.Id, itemRegisterData);
		}

		public void RegisterItems(IEnumerable<IItemData> itemRegisterDatas)
		{
			foreach (var item in itemRegisterDatas)
				RegisterItem(item);
		}

		public IItemData GetItemRegisterData(string id)
		{
			return ItemRegisterDatas[id];
		}

		public IEnumerable<IItemData> GetItemRegisterDatasByName(string itemName)
		{
			return from pair in ItemRegisterDatas
				   where pair.Value.Name == itemName
				   select pair.Value;
		}

		public void UnRegisterItem(string id)
		{
			ItemRegisterDatas.Remove(id);
		}

		public void UnRegisterItems(IEnumerable<string> ids)
		{
			foreach (var id in ids)
			{
				UnRegisterItem(id);
			}
		}
	}
}