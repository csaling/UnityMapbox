﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Droid : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.10f;
    [SerializeField] private float catchRate = 0.10f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defence = 0;
    [SerializeField] private int hp = 10;
    [SerializeField] private AudioClip crySound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(crySound);
    }

    private void start()
    {
        DontDestroyOnLoad(this);
    }
    
    public float SpawnRate
    {
        get { return spawnRate; }
    }
    
    public float Catchrate
    {
        get { return catchRate; }
    }
    
    public int Attack
    {
        get { return attack; }
    }
    
    public int Defence
    {
        get { return defence; }
    }
    
    public int Hp
    {
        get { return hp; }
    }

    private void OnMouseDown()
    {
        PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();
        audioSource.PlayOneShot(crySound);
        foreach (PocketDroidsSceneManager pocketDroidsSceneManager in managers)
        {
            if (pocketDroidsSceneManager.gameObject.activeSelf)
            {
                pocketDroidsSceneManager.droidTapped(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();
        foreach (PocketDroidsSceneManager pocketDroidsSceneManager in managers)
        {
            if (pocketDroidsSceneManager.gameObject.activeSelf)
            {
                pocketDroidsSceneManager.droidCollision(this.gameObject, other);
            }
        }
    }
}
