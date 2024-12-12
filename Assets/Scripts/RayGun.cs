using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class RayGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange;
    public float fireRate = 0.02f;
    public float laserDuration = 0.5f;

    LineRenderer laserLine;
    float fireTimer;
    public bool rbControl;

    LineRenderer laserline;

    private Animator anim;

    //public AudioClip laserSound;  // Müzik dosyasini burada atayacağız
    //private AudioSource audioSource;

    private void Awake()
    {
        laserline = GetComponent<LineRenderer>();
    }



    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {

            fireTimer = 0.01999f;
            laserline.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit raycastHit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out raycastHit, gunRange))
            {
                laserline.SetPosition(1, raycastHit.point);
                GameObject hitObject = raycastHit.collider.gameObject; // Raycastin değdiği gameObject
                Animator animator = hitObject.GetComponent<Animator>();
                NavMeshAgent navMeshAgent = hitObject.GetComponent<NavMeshAgent>();
                Rigidbody rb = hitObject.GetComponent<Rigidbody>(); 
                
                //Eğer hedef objede Animasyon bileşeni varsa
                if (animator != null)
                {
                    animator.SetBool("isShoot", true);  //Animasyon �al��t�r , isShoot parametresi
                    
                    //navMeshAgent.enabled = false;
                    //rb.gameObject.SetActive(false);
                    Destroy(hitObject,2f);
                    rb.detectCollisions = false; // Collision algılamayı kapat.

                    //navMeshAgent.enabled = true;
                }
                // Eğer Etiket-tagi- "Enemy" ise nesneyi yok et
                /* if (raycastHit.collider.CompareTag("Enemy")) {
                     Destroy(raycastHit.transform.gameObject);
                 }*/
            }
            else
            {
                laserline.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());

        }
    }

    IEnumerator ShootLaser()
    {
        laserline.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserline.enabled = false;
    }
}

