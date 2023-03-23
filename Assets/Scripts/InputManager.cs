using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField]
	private Move move;
	private void Awake()
	{
		move = GetComponent<Move>();
	}
	private void Update()
	{
		move.move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}
