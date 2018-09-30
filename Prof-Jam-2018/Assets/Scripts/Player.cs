using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform leftThighBone;
    private Transform rightThighBone;

    private Transform leftShinBone;
    private Transform rightShinBone;

    private float rotationFactor = 20f;

    // Start is called before the first frame update
    void Start()
    {
        leftThighBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        rightThighBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightUpperLeg);

        leftShinBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        rightShinBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightLowerLeg);
    }

    // Update is called once per frame
    void Update()
    {

        float thighMovement = Input.GetAxis("Thighs");
        float shinMovement = Input.GetAxis("Shins");
        
        if (thighMovement != 0)
        {
            Vector3 lt_rotation = leftThighBone.eulerAngles;
            Vector3 rt_rotation = rightThighBone.eulerAngles;

            //Debug.Log(lt_rotation);

            // Q = -1
            // W = 1
            if (thighMovement < 0)
            {
                if (lt_rotation.x < 85 || lt_rotation.x > 260)
                {
                    Debug.Log(lt_rotation.x);

                    lt_rotation.x -= Time.deltaTime * rotationFactor;
                    rt_rotation.x += Time.deltaTime * rotationFactor;
                    leftThighBone.eulerAngles = lt_rotation;
                    rightThighBone.eulerAngles = rt_rotation;
                }
            }
            else
            {
                if (rt_rotation.x > 285)
                {
                    lt_rotation.x += Time.deltaTime * rotationFactor;
                    rt_rotation.x -= Time.deltaTime * rotationFactor;
                    leftThighBone.eulerAngles = lt_rotation;
                    rightThighBone.eulerAngles = rt_rotation;
                }
            }
            return;

            if (lt_rotation.x < 80 || lt_rotation.x > 275)
            {
                if (thighMovement > 0)
                {
                    lt_rotation.x += Time.deltaTime * rotationFactor;
                    rt_rotation.x -= Time.deltaTime * rotationFactor;
                    leftThighBone.eulerAngles = lt_rotation;
                    rightThighBone.eulerAngles = rt_rotation;
                    //leftThighBone.Rotate(Vector3.left * Time.deltaTime * rotationFactor);   
                    //rightThighBone.Rotate(-Vector3.left * Time.deltaTime * rotationFactor);
                }
                else
                {
                    lt_rotation.x -= Time.deltaTime * rotationFactor;
                    rt_rotation.x += Time.deltaTime * rotationFactor;
                    leftThighBone.eulerAngles = lt_rotation;
                    rightThighBone.eulerAngles = rt_rotation;
                }
            }

        }

        // Rotates knee
        if (shinMovement > 0)
        {
            leftShinBone.Rotate(Vector3.left * Time.deltaTime * rotationFactor);
            rightShinBone.Rotate(-Vector3.left * Time.deltaTime * rotationFactor);
        }
        else if (shinMovement < 0)
        {
            leftShinBone.Rotate(-Vector3.left * Time.deltaTime * rotationFactor);
            rightShinBone.Rotate(Vector3.left * Time.deltaTime * rotationFactor);
        }
    }

}
