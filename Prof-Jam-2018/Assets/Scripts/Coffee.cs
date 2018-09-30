using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{

    public Transform coffee;
    public Transform player;
    Vector3 inverseLastPosition;
    Vector3 lastPositions;
    Vector2 positionsDifference;
    Vector3 neutralPosition;
    readonly float MIN_SWAY = -30f;
    readonly float MAX_SWAY = 30f;
    readonly float MIN_MOVEMENT = -0.5f;
    readonly float MAX_MOVEMENT = 0.5f;
    bool didLastPositionsChange;
    float yRotation;
    public float rotationDampening;


    // Start is called before the first frame update
    void Start()
    {
        yRotation = coffee.eulerAngles.y;
        neutralPosition = coffee.eulerAngles;
        lastPositions.x = player.position.x;
        lastPositions.y = 0f;
        lastPositions.y = player.position.z;
        didLastPositionsChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetLastPositions();

        RotateCoffee();

        if (!didLastPositionsChange)
            inverseLastPosition = new Vector3(lastPositions.x * -0.5f, yRotation, lastPositions.z * -0.5f);
            DampenCoffee();
        
    }

    void SetLastPositions()
    {
        Vector3 prevPositions = lastPositions;
        didLastPositionsChange = true;

        positionsDifference.x = (Mathf.Clamp(player.position.x - lastPositions.x, MIN_MOVEMENT, MAX_MOVEMENT) / MAX_MOVEMENT) * MAX_SWAY;
        lastPositions.x = player.position.x;

        positionsDifference.y = (Mathf.Clamp(player.position.z - lastPositions.z, MIN_MOVEMENT, MAX_MOVEMENT) / MAX_MOVEMENT) * MAX_SWAY;
        lastPositions.z = player.position.z;
        if (!IsCloseEnough(prevPositions.x, lastPositions.x) && !IsCloseEnough(prevPositions.z, lastPositions.z))
            didLastPositionsChange = false;
    }

    void RotateCoffee()
    {
        Vector3 newCoffeeRotation = coffee.eulerAngles;
        newCoffeeRotation.x = Mathf.Clamp(newCoffeeRotation.x + positionsDifference.x, MIN_SWAY, MAX_SWAY);
        newCoffeeRotation.y = yRotation;
        newCoffeeRotation.z = Mathf.Clamp(newCoffeeRotation.z + positionsDifference.y, MIN_SWAY, MAX_SWAY);

        coffee.eulerAngles = newCoffeeRotation;
    }

    void DampenCoffee()
    {
        if (coffee.eulerAngles == inverseLastPosition && inverseLastPosition != neutralPosition)
        {
            float rotX = (Mathf.Abs(inverseLastPosition.x) < 3f) ? 0f : inverseLastPosition.x * -0.5f;
            float rotZ = (Mathf.Abs(inverseLastPosition.z) < 3f) ? 0f : inverseLastPosition.z * -0.5f;
            inverseLastPosition = new Vector3(rotX, yRotation, rotZ);
        }
           
        if(inverseLastPosition != neutralPosition)
            coffee.eulerAngles = new Vector3(Mathf.Lerp(coffee.eulerAngles.x, inverseLastPosition.x, Time.deltaTime * rotationDampening), yRotation, Mathf.Lerp(coffee.eulerAngles.x, inverseLastPosition.x, Time.deltaTime * rotationDampening));
            
    }

    bool IsCloseEnough(float oldVal, float newVal)
    {
        if(Mathf.Abs(oldVal) * 0.01 > newVal)
            return true;
        return false;
    }
}
