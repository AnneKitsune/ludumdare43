using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WeaponScript:NetworkBehaviour {
    private Animator animator;

    public enum WeaponMode { MANUAL, SEMI, BURST, AUTO };
    public float damage = 20;
    public WeaponMode weaponMode = WeaponMode.SEMI;
    public int burstShootCount = 3;
    public float fireRate = 1;
    public int clipContent = 5;
    public int clipSize = 5;
    public int totalBulletCount = 20;

    public float normalFireRadius = 5;//in degree
    public float maxFireRadius = 20;//in degree

    public float reloadTime = 5;//automatic animation ajustement
    public float recoil = 3;//in degree (use animations OR use this value to create the animation from it?)

    public float maxDistance = 200;//in unity units
    public float bulletSpeed = 200;

    public AnimationClip reloadAnimation;
    public GameObject gunEnd;
    public GameObject bullet;



    private float timeSinceLastShot;
    private bool reloading = false;

    private bool burstFiring = false;
    private int burstShotsLeft = 3;


    // Use this for initialization
    void Start() {
        animator = this.GetComponentInParent<Animator>();
    }
    // Update is called once per frame
    void Update() {
        /*if (!isLocalPlayer)
        {
            return;
        }*/
        timeSinceLastShot += Time.deltaTime;

        if(reloading) {
            if(timeSinceLastShot>=reloadTime) {//reloading done
                if(totalBulletCount>=0) {
                    if(totalBulletCount<clipSize) {//not enough ammo to fill all the clip
                        clipContent = totalBulletCount;
                        totalBulletCount = 0;
                    } else {//we have enough bullets to fill the clip
                        totalBulletCount -= clipSize - clipContent;
                        clipContent = clipSize;
                    }
                }
                reloading = false;
                timeSinceLastShot = 999999;//We set a big time since last shot so we are able to shoot right after reloading(because reloading use timeSinceLastShot as timer).
            }
        }
        if(burstFiring) {
            Debug.Log("BurstFiring update");
            if(burstShotsLeft>0) {
                if(timeSinceLastShot>=1/fireRate/burstShootCount && clipContent>0) {
                    Debug.Log("BurstShoot");
                    animator.Play("Shoot",0);
                    CreateAndMoveBullet();
                    clipContent--;
                    burstShotsLeft--;
                    timeSinceLastShot = 0;
                } else if(clipContent<=0) {
                    burstFiring = false;
                }
            } else {
                burstFiring = false;
            }
        }
    }
    public void Shoot(bool keptPressed) {
        if(timeSinceLastShot >= (1 / fireRate)) {
            if(reloading) {
                return;
            }
            if(clipContent<=0) {//No bullets to shoot
                //animator.Play("EmptyShoot",0);
                Debug.Log("Empty clip");
                return;
            }
            if(weaponMode == WeaponMode.SEMI) {
                if(keptPressed == false) {
                    animator.Play("Shoot",0);
                    CreateAndMoveBullet();
                    clipContent--;
                }
            }else if(weaponMode == WeaponMode.MANUAL) {
                if(keptPressed == false) {
                    animator.Play("Shoot",0);
                    CreateAndMoveBullet();
                    clipContent--;
                }
            } else if(weaponMode == WeaponMode.BURST) {
                if(keptPressed==false) {
                    burstFiring = true;
                    burstShotsLeft = burstShootCount;

                    animator.Play("Shoot",0);//Shot first bullet here and the n-1 others in the update loop
                    CreateAndMoveBullet();
                    clipContent--;
                    burstShotsLeft--;
                }
            } else if(weaponMode == WeaponMode.AUTO) {
                animator.Play("Shoot",0);
                CreateAndMoveBullet();
                clipContent--;
            }
            timeSinceLastShot = 0;
        }
    }
    public void Reload() {
        if(clipContent<clipSize) {//Clip not full
            if(reloading==false) {//If we are not reloading, we start to do it
                reloading = true;
                timeSinceLastShot = 0;
                animator.Play("Reload",0);
                //animator.SetFloat("ReloadMultiplier",(animator.GetCurrentAnimatorStateInfo(0).length/reloadTime));//We set the animation to be done at the same time that reloadTime is done
                animator.SetFloat("ReloadMultiplier",(reloadAnimation.length/reloadTime));//We set the animation to be done at the same time that reloadTime is done
            }
        }
    }
    public void CreateAndMoveBullet() {
        GameObject Clone = (GameObject)Instantiate(bullet,gunEnd.transform.position,gunEnd.transform.rotation);

        //Here we put the bullet dispersion system
        Clone.GetComponent<Rigidbody>().velocity = gunEnd.transform.forward.normalized * bulletSpeed;
        NetworkServer.Spawn(Clone);
        Destroy(Clone,10f);
    }
}
