using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Ihittable
{
    [SerializeField] private int reward;
    
    public int OnHit()
    {
        return reward;
    }
}
