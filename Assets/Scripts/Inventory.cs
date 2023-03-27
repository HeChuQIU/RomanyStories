using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using System.Reflection;
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