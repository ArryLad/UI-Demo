using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;
public class cameraMove : MonoBehaviour
{
    private Vector3 _newPosition;
    private Quaternion _newRotation;

    [SerializeField] private Vector2 min;

    [SerializeField] private Vector2 max;

    [SerializeField] private Vector2 xRotationRange;
    [SerializeField] private Vector2 yRotationRange;

    [SerializeField] [Range(0.01f, 0.5f)] private float lerpSpeed = 0.05f;
    // Start is called before the first frame update
    private void Awake()
    {
        _newPosition = transform.position;
        _newRotation = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * lerpSpeed);

        if(Vector3.Distance(transform.position, _newPosition) < 1f )
        {
            GetNewPosition();
        }
    }

    void GetNewPosition()
    {
        var xPos = Random.Range(min.x, max.x);
        //var yPos = Random.Range(min.y, max.y);
        var zPos = Random.Range(min.y, max.y);
        
        _newRotation = Quaternion.Euler(Random.Range(xRotationRange.x, xRotationRange.y), Random.Range(yRotationRange.x, yRotationRange.y), 0);
        _newPosition = new Vector3(xPos, transform.position.y, zPos);
    }
}
