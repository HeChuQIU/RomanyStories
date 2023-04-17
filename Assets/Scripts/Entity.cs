using System;
using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private EntityData entityData;
    [SerializeField] private HitBox hitBox;
    [SerializeField] private Move move;

    public virtual EntityData EntityData
    {
        get => entityData;
        private set => entityData = value;
    }

    protected HitBox HitBox
    {
        get => hitBox;
        set => hitBox = value;
    }

    protected Move Move
    {
        get => move;
        set => move = value;
    }

    protected virtual void CheckRequire()
    {
        if (HitBox == null)
            HitBox = GetComponentInChildren<HitBox>();
        if (HitBox == null)
            throw new Exception("Entity needs HitBox on child gameObject");
        if (Move == null)
            Move = GetComponent<Move>();
        if (Move == null)
            throw new Exception("Entity needs Move on gameObject");
    }

    protected virtual void Awake()
    {
        CheckRequire();
        HitBox.OnBeHit += OnBeHit;
    }

    protected abstract void OnBeHit(HitBox hitBox);
}