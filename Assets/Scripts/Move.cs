using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    public Vector2 moveVector;

    [SerializeField] private new Rigidbody2D rigidbody;

    public Rigidbody2D Rigidbody
    {
        get => rigidbody;
        set => rigidbody = value;
    }

    [SerializeField] private Player entity;

    public Player Entity
    {
        get => entity;
        set => entity = value;
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Entity = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = Time.fixedDeltaTime * moveVector;
    }
}