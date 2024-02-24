using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerReader : MonoBehaviour
{
    public GameObject container; // Drag and drop the container object in the inspector
    public Button readButton; // Drag and drop the button object in the inspector
    public float moveSpeed = 1.0f; // The speed of the character's movement
    public float delay = 0.5f;
    public Animator animator; // Drag and drop the character object's Animator component in the inspector
    public GameObject FinishPanel;

    void Start()
    {
        readButton.onClick.AddListener(OnReadButtonClicked);
    }

    IEnumerator ReadChildObjects()
    {
        List<Transform> childObjects = new List<Transform>(container.transform.GetComponentsInChildren<Transform>());

        foreach (Transform child in childObjects)
        {
            if (child.tag == "Forward")
            {
                yield return StartCoroutine(MoveCharacter(child));
            }
            else if (child.tag == "Left")
            {
                yield return StartCoroutine(RotateCharacter(child, -90));
            }
            else if (child.tag == "Right")
            {
                yield return StartCoroutine(RotateCharacter(child, 90));
            }
        }
        if (transform.position.z > 1.4f && transform.position.z < 2.0f)
        {
            Debug.Log("Finish");
            Time.timeScale = 0f;
            // Turn on the UI game object
            FinishPanel.SetActive(true);
        }

    }

    IEnumerator MoveCharacter(Transform child)
    {
        Vector3 startPosition = transform.position;
        Vector3 forward = transform.forward;
        Vector3 endPosition = startPosition + forward;
        animator.SetBool("Walk1", true);

        float elapsedTime = 0.0f;
        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime);

            yield return null;
            animator.SetBool("Walk1", false);
        }

        transform.position = endPosition;

        yield return new WaitForSeconds(delay);
    }


    IEnumerator RotateCharacter(Transform child, float rotation)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, rotation, 0);
        
        float elapsedTime = 0.0f;
        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime);

            yield return null;
        }

        transform.rotation = endRotation;

        yield return new WaitForSeconds(delay);
    }

    void OnReadButtonClicked()
    {
        StartCoroutine(ReadChildObjects());
        

    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "finish")
    //    {
    //        Debug.Log("Finish");
    //        //animator.SetBool("jump", true);
    //    }
    //}
}