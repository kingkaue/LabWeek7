using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class Camera : MonoBehaviour
{
    public Vector3 CamOffset = new Vector3(0f, 1.5f, -2.5f);
    private Transform _target;
	
	void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        this.transform.position = _target.TransformPoint(CamOffset);

        this.transform.LookAt(_target);
    }
}
