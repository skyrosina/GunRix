using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;

    LineRenderer laserline;

    private Animator anim;

    //public AudioClip laserSound;  // Müzik dosyasýný burada atayacaðýz
    //private AudioSource audioSource;

    private void Awake()
    {
        laserline = GetComponent<LineRenderer>();
    }

   

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate ) 
        {
            
            fireTimer = 0;
            laserline.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit raycastHit;
            if (Physics.Raycast(rayOrigin,playerCamera.transform.forward,out raycastHit,gunRange))
            {
                laserline.SetPosition(1,raycastHit.point);
                GameObject hitObject = raycastHit.collider.gameObject;
                Animator animator = hitObject.GetComponent<Animator>();
                //Eðer hedef objede Animasyon bileþeni varsa
                if (animator != null)
                {
                     animator.SetBool("isShoot", true); //Animasyon çalýþtýr , isShoot parametresi
                     Destroy(hitObject, 4f);
                }
                // Eðer Etiket-tagi- "Enemy" ise nesneyi yok et
               /* if (raycastHit.collider.CompareTag("Enemy")) {
                    Destroy(raycastHit.transform.gameObject);
                }*/
            }
            else
            {
                laserline.SetPosition(1,rayOrigin+(playerCamera.transform.forward*gunRange));
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
