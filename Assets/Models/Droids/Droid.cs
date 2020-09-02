using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.10f;
    [SerializeField] private float catchRate = 0.10f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defence = 0;
    [SerializeField] private int hp = 10;

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
        foreach (PocketDroidsSceneManager pocketDroidsSceneManager in managers)
        {
            if (pocketDroidsSceneManager.gameObject.activateSelf)
            {
                pocketDroidsSceneManager.droidTapped(this.gameObject);
            }
        }
    }
}
