using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject asteroid;

    [SerializeField] AudioSource explosionSound;

    [SerializeField] int asteroidScore;

    MeshRenderer renderer;
    Collider asteroidCollider;

    public bool destroyed = false;

    private void Awake() {
        renderer = asteroid.GetComponent<MeshRenderer>();
        asteroidCollider = GetComponent<Collider>();
    }

    private void OnEnable() {
        destroyed = false;
        renderer.enabled = true;
        asteroidCollider.enabled = true;
        explosion.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == (int)Layers.Player) {
            destroyed = true;
            ShipLife.Instance.ApplyDamage();
            DestroyAsteroid(false);
        }
    }

    public void DestroyAsteroid(bool score) {
        destroyed = true;
        StartCoroutine(Explosion());
        if (score) {
            ScoreManager.Instance.AddScore(asteroidScore);
        }
    }

    private IEnumerator Explosion() {
        if (destroyed) {
            explosionSound.Play();
            renderer.enabled = false;
            asteroidCollider.enabled = false;
            explosion.SetActive(true);
            yield return new WaitForSeconds(5);
        }
        gameObject.SetActive(false);
    }
}
