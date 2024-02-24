using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayButtonController : MonoBehaviour
{
    public GameObject container; // Drag and drop the container object in the inspector
    public GameObject character; // Drag and drop the character object in the inspector

    public float moveSpeed = 1.0f;
    public float rotateSpeed = 90.0f;

    private List<Transform> childObjects;

    public void OnPlayButtonPressed()
    {
        childObjects = new List<Transform>(container.transform.GetComponentsInChildren<Transform>());

        foreach (Transform child in childObjects)
        {
            switch (child.tag)
            {
                case "Forward":
                    StartCoroutine(MoveForward(child.position));
                    break;
                case "Left":
                    StartCoroutine(RotateLeft(child.rotation));
                    break;
                case "Right":
                    StartCoroutine(RotateRight(child.rotation));
                    break;
                default:
                    Debug.LogWarningFormat("Unknown tag {0}", child.tag);
                    break;
            }
        }
    }

    IEnumerator MoveForward(Vector3 targetPosition)
    {
        Vector3 startPosition = character.transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * moveSpeed;
            character.transform.position = new Vector3(startPosition.x + elapsedTime, startPosition.y, startPosition.z);
            yield return null;
        }

        character.transform.position = new Vector3(startPosition.x + 1.0f, startPosition.y, startPosition.z);
    }

    IEnumerator RotateLeft(Quaternion targetRotation)
    {
        Quaternion startRotation = character.transform.rotation;
        float elapsedTime = 0.0f;

        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * rotateSpeed;
            character.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }

        character.transform.rotation = targetRotation;
    }

    IEnumerator RotateRight(Quaternion targetRotation)
    {
        Quaternion startRotation = character.transform.rotation;
        float elapsedTime = 0.0f;

        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * rotateSpeed;
            character.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }

        character.transform.rotation = targetRotation;
    }
}