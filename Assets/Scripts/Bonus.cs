using UnityEngine;

public class Bonus : MonoBehaviour
{
    private int[] TwoNumbers = {-1,1};

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trap"))
        { 
            gameObject.tag = "Untagged";
            gameObject.transform.parent = null;

            System.Random rnd = new System.Random();
            int i = rnd.Next(0, 2);
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right * (3500 * TwoNumbers[i]));                                                
        }
    }
}
