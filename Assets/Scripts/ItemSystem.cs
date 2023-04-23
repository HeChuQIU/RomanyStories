using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Classes;

namespace Assets.Scripts
{
	public interface IItemSystem : ISingleton<ItemSystem>
	{
		IDictionary<string, IItemInfo> ItemInfos { get; }
		void RegisterItem(IItemInfo itemInfo);
		void RegisterItems(IEnumerable<IItemInfo> itemInfo);
		void UnRegisterItem(string id);
		void UnRegisterItems(IEnumerable<string> ids);
		IItemInfo GetItemRegisterData(string id);
		IEnumerable<IItemInfo> GetItemRegisterDatasByName(string itemName);
	}

	public class ItemSystem :MonoBehaviour, IItemSystem
	{
		private static ItemSystem instance;
		public static ItemSystem Instance
		{
			get
			{
				return instance;
			}
		}

		public IDictionary<string, IItemInfo> ItemInfos => itemInfos;

		private Dictionary<string, IItemInfo> itemInfos;

		public void RegisterItem(IItemInfo itemInfo)
		{
			ItemInfos.Add(itemInfo.Id, itemInfo);
		}

		public void RegisterItems(IEnumerable<IItemInfo> itemInfos)
		{
			foreach (var itemInfo in itemInfos)
				RegisterItem(itemInfo);
		}

		public IItemInfo GetItemRegisterData(string id)
		{
			return ItemInfos[id];
		}

		public IEnumerable<IItemInfo> GetItemRegisterDatasByName(string itemName)
		{
			return from pair in ItemInfos
				   where pair.Value.Name == itemName
				   select pair.Value;
		}

		public void UnRegisterItem(string id)
		{
			ItemInfos.Remove(id);
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