using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
	[SerializeField]
	private IEntityData entityData;
	public virtual IEntityData EntityData { get => entityData; private set => entityData = value; }
}
