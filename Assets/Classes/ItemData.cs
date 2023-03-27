using System.Collections.Generic;
using UnityEngine;
using System;

public interface IItemData
{
	public string Id { get; set; }
	public string Name { get; set; }
	public int MaxStackSize { get; set; }
	public Sprite Sprite { get; set; }
}

public struct ItemData : IItemData
{

	public string Id { get; set; }

	public string Name { get; set; }

	public int MaxStackSize { get; set; }

	public Sprite Sprite { get; set; }

	public ItemData(string id, string name, int maxStackSize, Sprite sprite)
	{
		Id = id;
		Name = name;
		MaxStackSize = maxStackSize;
		Sprite = sprite;
	}



	public override bool Equals(object obj)
	{
		return obj is ItemData other &&
			   Id == other.Id &&
			   Name == other.Name &&
			   MaxStackSize == other.MaxStackSize &&
			   EqualityComparer<Sprite>.Default.Equals(Sprite, other.Sprite);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Id, Name, MaxStackSize, Sprite);
	}

	public void Deconstruct(out string id, out string name, out int maxStackSize, out Sprite sprite)
	{
		id = this.Id;
		name = this.Name;
		maxStackSize = this.MaxStackSize;
		sprite = this.Sprite;
	}

	public static implicit operator (string id, string name, int maxStackSize, Sprite sprite)(ItemData value)
	{
		return (value.Id, value.Name, value.MaxStackSize, value.Sprite);
	}

	public static implicit operator ItemData((string id, string name, int maxStackSize, Sprite sprite) value)
	{
		return new ItemData(value.id, value.name, value.maxStackSize, value.sprite);
	}
}