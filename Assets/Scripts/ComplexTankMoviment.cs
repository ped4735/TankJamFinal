using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTankMoviment : MonoBehaviour
{

    [SerializeField] private Transform turret;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private CommandController cmd;
    private bool isReloading;

    [SerializeField] private Vector3 vel;
    public float accelerationAmount = 0.05f;
    public float breakAmount = 1f;
    public float reverseAmount = 0.1f;
    public float rotationAmount = 0.1f;
    public float rotationTurretAngleAmount = 1f;

    //time amounts
    private float accelerateTime;
    private float rotateTimeRight;
    private float rotateTimeLeft;
    private float rotateTurretAngleLeft;    
    private float rotateTurretAngleRight;
    private float breakTime;
    private float reverseByTime;
    
    
    //rotation stats
    private Quaternion tankRotation;

    [SerializeField] private bool isTurretRotating;
    
    void Start()
    {
        turret = this.transform.GetChild(1);
        Debug.Log(turret.gameObject.name);

        
       
        //tankRotation = this.transform.rotation;

    }


    void Update()
    {

        this.transform.Translate(vel);

        if (accelerateTime > 0)
        {
            vel.x -= accelerationAmount * Time.deltaTime;
            accelerateTime -= Time.deltaTime;
        }

        if (breakTime > 0){
            if (vel.x < Mathf.Abs(breakAmount) ){
                vel.x = 0;
                breakTime = -10;
                StopAllBodyRotation();
            }else{
                vel.x += breakAmount * Time.deltaTime;
                breakTime -= Time.deltaTime;
            }
        }

        if (rotateTimeRight > 0) { 
            this.transform.Rotate(new Vector3(0f, 0f, -rotationAmount));
            rotateTimeRight -= Time.deltaTime;
        }

        if (rotateTimeLeft > 0){
            this.transform.Rotate(new Vector3(0f, 0f, rotationAmount));
            rotateTimeLeft -= Time.deltaTime;
        }

        if (reverseByTime > 0){
            vel.x += reverseAmount * Time.deltaTime;
            reverseByTime -= Time.deltaTime;
        }

        if (rotateTurretAngleLeft > 0){
            turret.transform.Rotate(new Vector3(0f, 0f, rotationTurretAngleAmount));
            rotateTurretAngleLeft -= rotationTurretAngleAmount;
        }
        if (rotateTurretAngleRight > 0){
            turret.transform.Rotate(new Vector3(0f, 0f, -rotationTurretAngleAmount));
            rotateTurretAngleRight -= rotationTurretAngleAmount;
        }


        //TestMoviment();
    }


    public void RotateTurretLeft(float angle){
        rotateTurretAngleLeft = angle;
    }
    
    public void RotateTurretRight(float angle){
        rotateTurretAngleRight =  angle;
    }
    
    public void AccByTime(float time){
        accelerateTime = time;
    }

    public void RotateRightByTime(float time){
        rotateTimeRight = time;
    }

    public void RotateLeftByTime(float time)
    {
        rotateTimeLeft = time;
    }
    
    public void BreakByTime(float time)
    {
        breakTime = time;
    }

    public void ReverseByTime(float time){
        if (vel.x > 0.1){
            //still moving
            BreakByTime(time);
        }else{
            reverseByTime = time;
        }
    }

    private void StopAllBodyRotation(){
        accelerateTime = 0f;
        reverseByTime = 0f;
        rotateTimeRight = 0f;
        rotateTimeLeft = 0f;
    }

    void TestMoviment(){
        if (Input.GetKeyDown(KeyCode.W)){
            AccByTime(2);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            RotateRightByTime(2);
        }
        if (Input.GetKeyDown(KeyCode.A)){
            RotateLeftByTime(2);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            BreakByTime(1);
        }
        if (Input.GetKeyDown(KeyCode.X)){
            ReverseByTime(2);
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            RotateTurretLeft(15f);
        }
        if (Input.GetKeyDown(KeyCode.E)){
            RotateTurretRight(15f);
        }
    }

    public void Shoot()
    {

        //PLACEHOLDER: Verify is reloading on the command, not here in here
        if (!isReloading)
        {
            RaycastHit2D hit = Physics2D.Raycast(muzzle.transform.position, muzzle.transform.up, 10);
            Debug.DrawRay(muzzle.transform.position, muzzle.transform.up * 10, Color.blue,1f);

            if (hit)
            {
                GameObject hitObject = hit.collider.gameObject;
                
                if (hitObject.tag == "Enemy") {
                    Destroy (hitObject.gameObject);
                }
                //Debug.Log("Hit something: "+ hitObject);
            }
            cmd.ReceiveCommand("SHOOT\n");
            StartCoroutine(ReloadCoroutine());
        }
        else
        {
            Debug.Log("I am reloading!!");
            cmd.ReceiveCommand("I am reloading!!\n");
        }

    }
    

    IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        isReloading = false;
       
    }
}
