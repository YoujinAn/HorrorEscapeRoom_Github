using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EyeColliderMovement : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        gameObject.transform.rotation = cameraTransform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!CompareTag("Player"))
            Debug.Log(other.name);
    }
}
