using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TargetShot : MonoBehaviour
{
    [SerializeField] GameObject ShootParticles;
    [SerializeField] Camera mainCamera;
    [SerializeField] Image fill;
    [SerializeField] float chargeTime = 1f;
    [SerializeField] float range;

    [SerializeField] AudioSource shotSound;

    [SerializeField] GameObject player; // TODO change for script to shot

    float t = 0;
    RaycastHit hit;
    GameObject currentTarget;

    private void FixedUpdate() {
        
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range)) {
            if(hit.collider.gameObject.layer == (int)Layers.Asteroid && !IsSameTarget(hit.collider.gameObject, currentTarget)) {
                if (t < 1) {
                    t += Time.fixedDeltaTime / chargeTime;
                }
                else {
                    t = 0;
                    currentTarget = hit.collider.gameObject;
                    StartCoroutine(ShootAndDestroy());
                }
            }
            else {
                t = 0;
            }
        } else {
            t = 0;
        }
        fill.fillAmount = t;
    }
    private bool IsSameTarget(GameObject go1, GameObject go2) {
        return GameObject.ReferenceEquals(go1, go2);
    }

    private IEnumerator ShootAndDestroy() {
        AsteroidController asteroid = hit.collider.gameObject.GetComponent<AsteroidController>();
        shotSound.Play();
        ShootParticles.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ShootParticles.SetActive(false);
        asteroid.DestroyAsteroid(true);
    }

}
