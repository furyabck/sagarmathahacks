using UnityEngine;

public class Food : MonoBehaviour
{
    public  float healthGain = 10;
    public GameObject mainplayer;
    PlayerInfo pi;
    private void Start()
    {
        pi = mainplayer.GetComponent<PlayerInfo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yes enter");
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {

            pi.Health += healthGain;
            gameObject.SetActive(false);
          
        }
    }
}
