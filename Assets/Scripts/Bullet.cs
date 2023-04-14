using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	private EntityData entityData;
	public EntityData EntityData { get => entityData; set => entityData = value; }

	[SerializeField]
	private Move move;

	private void Awake()
	{
		if (move == null)
			move = GetComponent<Move>();
	}
<<<<<<< HEAD

	private void OnCollisionEnter(Collision collision)
	{
		
	}
=======
>>>>>>> d18f1719caae2013240c94eda6dcc87912738200
}
