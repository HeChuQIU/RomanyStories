using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Classes;
using System.Linq;

public interface IItemData
{
	public string Id { get; set; }
	public string Name { get; set; }
	public Sprite Sprite { get; set; }
	public string this[string propertyName] { get;set; }
	public bool IsIdEqualWith(IItemInfo itemInfo)
	{
		return Id == itemInfo.Id;
	}
}

[Serializable]
public struct ItemData : IItemData
{

	public string Id { get; set; }

	public string Name { get; set; }

	public Sprite Sprite { get; set; }

	private Dictionary<string, string> properties;
	public string this[string propertyName] 
	{
		get 
		{
			return properties[propertyName];
		}
		set
		{ 
			properties.Add(propertyName, value);
		} 
	}

	public ItemData(string id, string name, Sprite sprite, IEnumerable<KeyValuePair<string, string>> properties)
	{
		Id = id;
		Name = name;
		Sprite = sprite;
		Dictionary<string, string> propertiesDictionary = new();
		properties.ToList().ForEach(p => { propertiesDictionary.Add(p.Key, p.Value); });
		this.properties = propertiesDictionary;
	}

	public ItemData(string id,string name,Sprite sprite,Dictionary<string,string> properties)
	{
		Id = id;
		Name = name;
		Sprite = sprite;
		this.properties = properties;
	}
}