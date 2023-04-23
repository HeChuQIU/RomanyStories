using UnityEngine;
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
