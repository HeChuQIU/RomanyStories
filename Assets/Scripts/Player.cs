using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour/* : Entity*/
{
	[SerializeField]
	private EntityData entityData;
	public EntityData EntityData { get => entityData; set => entityData = value; }
}
