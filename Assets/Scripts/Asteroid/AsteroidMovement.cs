using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : PoolableObject
{
    [SerializeField] float speed;
    [SerializeField] AsteroidController controller;

    private Vector3 direction;
    [SerializeField] private float limit;

    public void Init(Vector3 asteroidDirection, float zLimit) {
        limit = zLimit;
        direction = asteroidDirection;
    }

    private void Update() {
        if (MustDissable()) {
            this.gameObject.SetActive(false);
        }
        if (!controller.destroyed) {
            transform.position = transform.position - direction * Time.deltaTime * speed;
        }
    }

    private bool MustDissable() {
        return transform.position.z <= limit; 
    }
}
