using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera mainCam;

    private Transform leftThighBone;
    private Transform rightThighBone;

    private Transform leftShinBone;
    private Transform rightShinBone;

    private Transform playerMain;

    private readonly float rotationFactor = 40f;

    private float thighRotation = 0f;
    private float leftShinRotation;
    private float rightShinRotation;

    private float xPos;
    //private float yPos;
    private float zPos;

    //private BoxCollider leftFoot;
    //private BoxCollider rightFoot;

    private void Awake()
    {
        //Transform root = transform.Find("MakeHuman default skeleton/root");

        //leftFoot = root.Find("pelvis.L/upperleg01.L/upperleg02.L/lowerleg01.L/lowerleg02.L/foot.L/toe5-1.L").GetComponent<BoxCollider>();
        //rightFoot = root.Find("pelvis.R/upperleg01.R/upperleg02.R/lowerleg01.R/lowerleg02.R/foot.R/toe5-1.R").GetComponent<BoxCollider>();

        //Debug.Log(leftFoot.);

        mainCam = Camera.allCameras[0];

        playerMain = gameObject.transform;

        xPos = playerMain.position.x;
        zPos = playerMain.position.z;

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

        float playerStrafe = Input.GetAxis("PlayerMove");

        if (playerStrafe < 0)
        {
            zPos += Time.deltaTime * 2f;
        }
        else if (playerStrafe > 0)
        {
            zPos -= Time.deltaTime * 2f;
        }

        zPos = Mathf.Clamp(zPos, -2f, 2.25f);

        playerMain.eulerAngles = new Vector3(0f, 90f, 0f);

        xPos = Mathf.Max(playerMain.position.x, xPos);

        playerMain.position = new Vector3(xPos, playerMain.position.y, zPos);

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
        //-1 = left back
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
