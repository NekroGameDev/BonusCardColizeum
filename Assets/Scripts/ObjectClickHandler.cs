using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectClickHandler : MonoBehaviour
{
    public Text numberText; // Reference to a UI Text component to display the assigned number 
    public Animator animator; // Reference to an Animator component to play the animation 
    public Button button;

    private static int[] numberArray = { 0, 0, 0, 0, 0, 0, 50, 50, 50, 50, 50, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 250, 250, 250, 250, 250, 250, 500, 1000 }; // The initial array of numbers 
    private static List<int> unusedNumbers = new List<int>(numberArray); // A list of unused numbers from the array 
    private int assignedNumber; // The number assigned to this object 
    private static List<GameObject> objects = new List<GameObject>(); // A list of all objects

    void Start()
    {
        // Assign a unique number from the unusedNumbers list to this object 
        int randomIndex = Random.Range(0, unusedNumbers.Count);
        assignedNumber = unusedNumbers[randomIndex];

        // Remove the assigned number from the unusedNumbers list 
        unusedNumbers.RemoveAt(randomIndex);

        // Display the assigned number in the UI Text component 
        objects.Add(gameObject);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            switch (assignedNumber)
            {
                case 0:
                    animator.Play("Animation0");
                    break;
                case 50:
                    animator.Play("Animation50");
                    break;
                case 100:
                    animator.Play("Animation100");
                    break;
                case 250:
                    animator.Play("Animation250");
                    break;
                case 500:
                    animator.Play("Animation500");
                    break;
                case 1000:
                    animator.Play("Animation1000");
                    break;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            ResetScene();
        }
    }



    public void OnMouseDown()
    {
        numberText.text = ("Вы выиграли: " + assignedNumber + " бонусов");

        foreach (GameObject obj in objects)
        {
            if (obj != gameObject)
            {
                obj.GetComponent<Button>().enabled = false;
                obj.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
               
            }

        }


        // Play the animation based on the assigned number 
        switch (assignedNumber)
        {
            case 0:
                animator.Play("Animation0");
                break;
            case 50:
                animator.Play("Animation50");
                break;
            case 100:
                animator.Play("Animation100");
                break;
            case 250:
                animator.Play("Animation250");
                break;
            case 500:
                animator.Play("Animation500");
                break;
            case 1000:
                animator.Play("Animation1000");
                break;
        }
    }

    static void ResetScene()
    {
        // Reset the unusedNumbers list to its original state
        unusedNumbers = new List<int>(numberArray);

        objects.Clear();

        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
