using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform leftThighBone;
    private Transform rightThighBone;

    private Transform leftShinBone;
    private Transform rightShinBone;

    private readonly float rotationFactor = 40f;

    private float thighRotation = 0f;
    private float leftShinRotation;
    private float rightShinRotation;

    BoxCollider toe;
    BoxCollider heel;

    private void Awake()
    {
        //toe = gameObject.transform.Find("MakeHuman default skeleton/root/pelvis.L/upperleg01.L/upperleg02.L/lowerleg01.L/lowerleg02.L/foot.L/toe1-1.L").GetComponent<BoxCollider>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        leftThighBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        rightThighBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightUpperLeg);

        leftShinBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        rightShinBone = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightLowerLeg);

        leftShinRotation = leftShinBone.localEulerAngles.x;
        rightShinRotation = rightShinBone.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        float thighAxis = Input.GetAxis("Thighs");
        float shinAxis = Input.GetAxis("Shins");

        if (thighAxis != 0 || shinAxis != 0)
        {
            UpdateLowerBody(thighAxis, shinAxis);
        }
    }

    void UpdateLowerBody(float upperLegInput, float lowerLegInput)
    {
        if (upperLegInput != 0)
        {
            Vector3 lt_rotation = leftThighBone.eulerAngles;
            Vector3 rt_rotation = rightThighBone.eulerAngles;

            // Q = -1
            // W = 1
            if (upperLegInput < 0)
            {
                if (thighRotation == 60)
                {
                    return;
                }

                thighRotation += Time.deltaTime * rotationFactor;
                thighRotation = Mathf.Min(thighRotation, 60);

                lt_rotation.x -= Time.deltaTime * rotationFactor;
                rt_rotation.x += Time.deltaTime * rotationFactor;

                leftThighBone.eulerAngles = lt_rotation;
                rightThighBone.eulerAngles = rt_rotation;

            }
            else
            {
                if (thighRotation == -60)
                {
                    return;
                }

                thighRotation -= Time.deltaTime * rotationFactor;

                thighRotation = Mathf.Max(thighRotation, -60);

                lt_rotation.x += Time.deltaTime * rotationFactor;
                rt_rotation.x -= Time.deltaTime * rotationFactor;

                leftThighBone.eulerAngles = lt_rotation;
                rightThighBone.eulerAngles = rt_rotation;
            }

        }

        // Rotates knee
        if (lowerLegInput > 0)
        {
            Vector3 ls_rotation = leftShinBone.localEulerAngles;
            Vector3 rs_rotation = rightShinBone.localEulerAngles;

            ls_rotation.x += Time.deltaTime * rotationFactor;
            rs_rotation.x -= Time.deltaTime * rotationFactor;

            if (rs_rotation.x < rightShinRotation)
            {
                rs_rotation.x = rightShinRotation;
            }

            if (ls_rotation.x > 90)
            {
                ls_rotation.x = 90;
            }

            leftShinBone.localEulerAngles = ls_rotation;
            rightShinBone.localEulerAngles = rs_rotation;
        }
        else if (lowerLegInput < 0)
        {
            Vector3 ls_rotation = leftShinBone.localEulerAngles;
            Vector3 rs_rotation = rightShinBone.localEulerAngles;

            ls_rotation.x -= Time.deltaTime * rotationFactor;
            rs_rotation.x += Time.deltaTime * rotationFactor;

            if (ls_rotation.x < leftShinRotation)
            {
                ls_rotation.x = leftShinRotation;
            }

            if (rs_rotation.x > 90)
            {
                rs_rotation.x = 90;
            }

            leftShinBone.localEulerAngles = ls_rotation;
            rightShinBone.localEulerAngles = rs_rotation;
        }
    }
}
