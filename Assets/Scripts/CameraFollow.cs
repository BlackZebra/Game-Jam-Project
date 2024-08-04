using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float movingSpeed;
[SerializeField] private float rotationSpeed;

    private void Awake()
    {
        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 10
        };

        this.transform.rotation = new Quaternion()
        {
                x = this.playerTransform.rotation.x,
                y = this.playerTransform.rotation.y,
                z = this.playerTransform.rotation.z,
                w = this.playerTransform.rotation.w
        };
    }

    private void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10
            };
            Quaternion tRotation = new Quaternion()
            {
                x = this.playerTransform.rotation.x,
                y = this.playerTransform.rotation.y,
                z = this.playerTransform.rotation.z,
                w = this.playerTransform.rotation.w
            };


            Quaternion cRotation = Quaternion.Slerp(transform.rotation, tRotation, rotationSpeed * Time.deltaTime);
            Vector3 pos = Vector3.Lerp(transform.position, target, movingSpeed * Time.deltaTime);

            this.transform.position = pos;
            this.transform.rotation = cRotation;
        }
    }
}
