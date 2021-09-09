using System.Collections;
using UnityEngine;

/**
 * Class to capture the ball being thrown into the boat, and 
 * hiding the boat on trigger with Collider.
 */
public class BoatScoreArea : MonoBehaviour
{
    [Header("Manager References")]
    public GameManager gameManager;

    [Header("Stage Game Object")]
    public GameObject Stage2;

    [Header("Current Boat Object References")]
    public GameObject currentBoat;
    public GameObject effectObject;
    public int boatNum;


    private void Start()
    {
        effectObject.SetActive(false);
        currentBoat.SetActive(true);
    }

    /**
     * Function attatched to collider to capture when a ball is thrown
     * into the boat.
     * @param other Object that collides with collider.
     */
    private void OnTriggerEnter(Collider other)
    {
        gameManager.GetComponent<GameManager>().CorrectActionHaptic();
        if(other.gameObject.tag == "Ball"){
            Stage2.GetComponent<ThrowingSequence>().setHiddenBoat(boatNum);
            effectObject.SetActive(true);
            StartCoroutine(HideBoat());

            Stage2.GetComponent<ThrowingSequence>().resetBallPositions();
        }
    }

    /**
     * Function to show the particles on the boat and hide it 
     * after 2 seconds.
     */
    private IEnumerator HideBoat()
    {
        float sec = 2f;
        yield return new WaitForSeconds(sec);
        currentBoat.SetActive(false);
    }
}
