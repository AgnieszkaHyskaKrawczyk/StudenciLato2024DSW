using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int myInt;

    [SerializeField] private float myFloat;
    
    private MeshRenderer _meshRenderer;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        _meshRenderer.material.color = Color.blue;
    }

    void Update()
    {
        transform.Rotate(transform.up, myFloat * Time.deltaTime);
    }

    private void OnEnable()
    {
        Debug.Log("Enabled");
    }

    private void OnDisable()
    {
        Debug.Log("Disabled");
    }

    private void OnDestroy()
    {
        Debug.Log($"Destroyed: {name}");
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }
}
