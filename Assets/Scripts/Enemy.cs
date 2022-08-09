using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Ihittable
{
    [SerializeField] private int reward;

    [SerializeField] private AudioSource hitSound;
    
    public int OnHit()
    {
        hitSound.Play();
        
        return reward;
    }
}
