using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid_Movement : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    float angle, obliqueAngle;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject viewPoint;
    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float deceleration = 2.0f;
    // [SerializeField] private float maximumVelocity = 1.0f;
    

    int VelocityZHash;
    int VelocityXHash;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();

        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }

    // Update is called once per frame
    private void Update()
    {
        rotationMovement();
        translationMovement();
    }

    private void rotationMovement()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            viewPoint.transform.position = raycastHit.point;
            // transform.position = Vector3.MoveTowards(transform.position, viewPoint.transform.point, Time.deltaTime * 5);
            transform.LookAt(new Vector3 (viewPoint.transform.position.x, transform.position.y, viewPoint.transform.position.z));
        }
    }

    private void translationMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // // Move forward
        // if(vertical > 0 && velocityZ < maximumVelocity){
        //     velocityZ += Time.deltaTime * acceleration;
        // }

        // // Move backward
        // if(vertical < 0 && velocityZ > -maximumVelocity){
        //     velocityZ -= Time.deltaTime * acceleration;
        // }

        // // Move left
        // if(horizontal < 0 && velocityX > -maximumVelocity){
        //     velocityX -= Time.deltaTime * acceleration;
        // }

        // // Move right
        // if(horizontal > 0 && velocityX < maximumVelocity){
        //     velocityX += Time.deltaTime * acceleration;
        // }

        // // Decreasen velocity forward
        // if(!(vertical > 0) && velocityZ > 0.0f){
        //     velocityZ -= Time.deltaTime * deceleration;
        // }

        // // Decreasen velocity backward
        // if(!(vertical < 0) && velocityZ < 0.0f){
        //     velocityZ += Time.deltaTime * deceleration;
        // }

        // // Reset velocity horizontal
        // if(vertical == 0 && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f)){
        //     velocityZ = 0.0f;
        // }

        // // Decreasen velocity right
        // if(!(horizontal > 0) && velocityX > 0.0f){
        //     velocityX -= Time.deltaTime * deceleration;
        // }

        // // Decreasen velocity left
        // if(!(horizontal < 0) && velocityX < 0.0f){
        //     velocityX += Time.deltaTime * deceleration;
        // }

        // // Reset velocity vertical
        // if(horizontal == 0 && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f)){
        //     velocityX = 0.0f;
        // }

        // // Move W
        angle = transform.eulerAngles.y * Mathf.Deg2Rad;
        obliqueAngle = (transform.eulerAngles.y - 45) * Mathf.Deg2Rad;
        // Debug.Log(transform.eulerAngles.y);
        
        if(vertical > 0 && horizontal > 0){
            if(transform.eulerAngles.y > 0  + 45 && transform.eulerAngles.y < 90 + 45){
                translationMovementHelper(Mathf.Cos(obliqueAngle), -Mathf.Sin(obliqueAngle));
                // velocityZ = Mathf.Cos(obliqueAngle);
                // velocityX = -Mathf.Sin(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 180 + 45){
                translationMovementHelper(Mathf.Cos(obliqueAngle), -Mathf.Sin(obliqueAngle));
                // velocityZ = Mathf.Cos(obliqueAngle);
                // velocityX = -Mathf.Sin(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 270 + 45){
                translationMovementHelper(Mathf.Cos(obliqueAngle), -Mathf.Sin(obliqueAngle));
                // velocityZ = Mathf.Cos(obliqueAngle);
                // velocityX = -Mathf.Sin(obliqueAngle);
            }
            else{
                translationMovementHelper(Mathf.Cos(obliqueAngle), -Mathf.Sin(obliqueAngle));
                // velocityZ = Mathf.Cos(obliqueAngle);
                // velocityX = -Mathf.Sin(obliqueAngle);
            } 
        }
        else if(vertical < 0 && horizontal < 0){
            if(transform.eulerAngles.y > 0  + 45 && transform.eulerAngles.y < 90 + 45){
                translationMovementHelper(-Mathf.Cos(obliqueAngle), Mathf.Sin(obliqueAngle));
                // velocityZ = -Mathf.Cos(obliqueAngle);
                // velocityX = Mathf.Sin(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 180 + 45){
                translationMovementHelper(-Mathf.Cos(obliqueAngle), Mathf.Sin(obliqueAngle));
                // velocityZ = -Mathf.Cos(obliqueAngle);
                // velocityX = Mathf.Sin(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 270 + 45){
                translationMovementHelper(-Mathf.Cos(obliqueAngle), Mathf.Sin(obliqueAngle));
                // velocityZ = -Mathf.Cos(obliqueAngle);
                // velocityX = Mathf.Sin(obliqueAngle);
            }
            else{
                translationMovementHelper(-Mathf.Cos(obliqueAngle), Mathf.Sin(obliqueAngle));
                // velocityZ = -Mathf.Cos(obliqueAngle);
                // velocityX = Mathf.Sin(obliqueAngle);
            }
            
        }
        else if(vertical < 0 && horizontal > 0){
            if(transform.eulerAngles.y > 0  + 45 && transform.eulerAngles.y < 90 + 45){
                translationMovementHelper(Mathf.Sin(obliqueAngle), Mathf.Cos(obliqueAngle));
                // velocityZ = Mathf.Sin(obliqueAngle);
                // velocityX = Mathf.Cos(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 180 + 45){
                translationMovementHelper(Mathf.Sin(obliqueAngle), Mathf.Cos(obliqueAngle));
                // velocityZ = Mathf.Sin(obliqueAngle);
                // velocityX = Mathf.Cos(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 270 + 45){
                translationMovementHelper(Mathf.Sin(obliqueAngle), Mathf.Cos(obliqueAngle));
                // velocityZ = Mathf.Sin(obliqueAngle);
                // velocityX = Mathf.Cos(obliqueAngle);
            }
            else{
                translationMovementHelper(Mathf.Sin(obliqueAngle), Mathf.Cos(obliqueAngle));
                // velocityZ = Mathf.Sin(obliqueAngle);
                // velocityX = Mathf.Cos(obliqueAngle);
            }
        }
        else if(vertical > 0 && horizontal < 0){
            if(transform.eulerAngles.y > 0  + 45 && transform.eulerAngles.y < 90 + 45){
                translationMovementHelper(-Mathf.Sin(obliqueAngle), -Mathf.Cos(obliqueAngle));
                // velocityZ = -Mathf.Sin(obliqueAngle);
                // velocityX = -Mathf.Cos(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 180 + 45){
                translationMovementHelper(-Mathf.Sin(obliqueAngle), -Mathf.Cos(obliqueAngle));
                // velocityZ = -Mathf.Sin(obliqueAngle);
                // velocityX = -Mathf.Cos(obliqueAngle);
            }
            else if(transform.eulerAngles.y < 270 + 45){
                translationMovementHelper(-Mathf.Sin(obliqueAngle), -Mathf.Cos(obliqueAngle));
                // velocityZ = -Mathf.Sin(obliqueAngle);
                // velocityX = -Mathf.Cos(obliqueAngle);
            }
            else{
                translationMovementHelper(-Mathf.Sin(obliqueAngle), -Mathf.Cos(obliqueAngle));
                // velocityZ = -Mathf.Sin(obliqueAngle);
                // velocityX = -Mathf.Cos(obliqueAngle);
            }
        }
        if(vertical > 0){
            if(transform.eulerAngles.y < 90){
                translationMovementHelper(Mathf.Cos(angle), -Mathf.Sin(angle));
                // velocityZ = Mathf.Cos(angle);
                // velocityX = -Mathf.Sin(angle);
            }
            else if(transform.eulerAngles.y < 180){
                translationMovementHelper(Mathf.Cos(angle), -Mathf.Sin(angle));
                // velocityZ = Mathf.Cos(angle);
                // velocityX = -Mathf.Sin(angle);
            }
            else if(transform.eulerAngles.y < 270){
                translationMovementHelper(Mathf.Cos(angle), -Mathf.Sin(angle));
                // velocityZ = Mathf.Cos(angle);
                // velocityX = -Mathf.Sin(angle);
            }
            else{
                translationMovementHelper(Mathf.Cos(angle), -Mathf.Sin(angle));
                // velocityZ = Mathf.Cos(angle);
                // velocityX = -Mathf.Sin(angle);
            }
            
        }
        else if(vertical < 0){
            if(transform.eulerAngles.y < 90){
                translationMovementHelper(-Mathf.Cos(angle), Mathf.Sin(angle));
                // velocityZ = -Mathf.Cos(angle);
                // velocityX = Mathf.Sin(angle);
            }
            else if(transform.eulerAngles.y < 180){
                translationMovementHelper(-Mathf.Cos(angle), Mathf.Sin(angle));
                // velocityZ = -Mathf.Cos(angle);
                // velocityX = Mathf.Sin(angle);
            }
            else if(transform.eulerAngles.y < 270){
                translationMovementHelper(-Mathf.Cos(angle), Mathf.Sin(angle));
                // velocityZ = -Mathf.Cos(angle);
                // velocityX = Mathf.Sin(angle);
            }
            else{
                translationMovementHelper(-Mathf.Cos(angle), Mathf.Sin(angle));
                // velocityZ = -Mathf.Cos(angle);
                // velocityX = Mathf.Sin(angle);
            }
            
        }
        else if(horizontal > 0){
            if(transform.eulerAngles.y < 90){
                translationMovementHelper(Mathf.Sin(angle), Mathf.Cos(angle));
                // velocityZ = Mathf.Sin(angle);
                // velocityX = Mathf.Cos(angle);
            }
            else if(transform.eulerAngles.y < 180){
                translationMovementHelper(Mathf.Sin(angle), Mathf.Cos(angle));
                // velocityZ = Mathf.Sin(angle);
                // velocityX = Mathf.Cos(angle);
            }
            else if(transform.eulerAngles.y < 270){
                translationMovementHelper(Mathf.Sin(angle), Mathf.Cos(angle));
                // velocityZ = Mathf.Sin(angle);
                // velocityX = Mathf.Cos(angle);
            }
            else{
                translationMovementHelper(Mathf.Sin(angle), Mathf.Cos(angle));
                // velocityZ = Mathf.Sin(angle);
                // velocityX = Mathf.Cos(angle);
            }
        }
        else if(horizontal < 0){
            if(transform.eulerAngles.y < 90){
                translationMovementHelper(-Mathf.Sin(angle), -Mathf.Cos(angle));
                // velocityZ = -Mathf.Sin(angle);
                // velocityX = -Mathf.Cos(angle);
            }
            else if(transform.eulerAngles.y < 180){
                translationMovementHelper(-Mathf.Sin(angle), -Mathf.Cos(angle));
                // velocityZ = -Mathf.Sin(angle);
                // velocityX = -Mathf.Cos(angle);
            }
            else if(transform.eulerAngles.y < 270){
                translationMovementHelper(-Mathf.Sin(angle), -Mathf.Cos(angle));
                // velocityZ = -Mathf.Sin(angle);
                // velocityX = -Mathf.Cos(angle);
            }
            else{
                translationMovementHelper(-Mathf.Sin(angle), -Mathf.Cos(angle));
                // velocityZ = -Mathf.Sin(angle);
                // velocityX = -Mathf.Cos(angle);
            }
        }
        else{
            if(velocityX > 0.0f){
                velocityX -= Time.deltaTime * deceleration;
            }
            if(velocityX < 0.0f){
                velocityX += Time.deltaTime * deceleration;
            }
            if(velocityZ < 0.0f){
                velocityZ += Time.deltaTime * deceleration;
            }
            if(velocityZ > 0.0f){
                velocityZ -= Time.deltaTime * deceleration;
            }
            if(velocityX > -0.05f && velocityX < 0.05f){
                velocityX = 0.0f;
            }
            if(velocityZ > -0.05f && velocityZ < 0.05f){
                velocityZ = 0.0f;
            }
        }

        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
    }

    private void translationMovementHelper(float valueZ, float valueX){
        if(velocityZ > valueZ){
            velocityZ -= Time.deltaTime * acceleration;
        }
        if(velocityZ < valueZ){
            velocityZ += Time.deltaTime * acceleration;
        }
        if(velocityX > valueX){
            velocityX -= Time.deltaTime * acceleration;
        }
        if(velocityX < valueX){
            velocityX += Time.deltaTime * acceleration;
        }
    }
}
