using UnityEngine;

public class Gun : MonoBehaviour
{
   
    public GameObject plunger;
    public GameObject player;

    [SerializeField] Transform barrel;

    public float plungerSpeed;

    Transform plungerPos;

    Rigidbody plungerRB;

    Plunger plungerScript;

    LineRenderer rope;



    public bool hasBeenShot { get; set; }

    public void Start()
    {
        plungerPos = plunger.transform;
        plungerRB = plunger.GetComponent<Rigidbody>();
        plungerScript = plunger.GetComponent<Plunger>();

        rope = GetComponent<LineRenderer>();
        rope.positionCount = 2;
    }

   public void Update()
    {
        if (!hasBeenShot)
        {
            plungerPos.position = barrel.position;
            plungerPos.forward = barrel.forward;
        }

        if (hasBeenShot)
        {
            rope.enabled = true;
            rope.SetPosition(0, barrel.position);
            rope.SetPosition(1, plunger.transform.position);
        }
        else
        {
            rope.enabled = false;
        } 

    }

    public void Fire()
   {
        hasBeenShot = true;
        plungerPos.position = barrel.position;
        plungerRB.linearVelocity = barrel.forward * plungerSpeed;

   }

   public void CancelFire()
   {
        hasBeenShot = false;
        plungerScript.DestroyJoint();

   } 
}
