using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CharacterController44 : MonoBehaviour
{
    private bool isPlaying = false , isPlaying2 = false;
    public float speed = 5f;
    public float rotationSpeed = 200f;
    private Animator animator;
    public GameObject AxePre;

    public LayerMask enemyLayer;
    public float punchRange = 5f;
    public int punchDamage = 10;
    bool isattacking;

    [Header("PlayerInfo")]
    public Image StamaniaBar;
    public float  Stamania, MaxStaminia;
    public float reduceStamania;



    void Start()
    {
        
        // Get the Animator component attached to the character
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        AxePre.SetActive(false);
    }

    void Update()
    {
        
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector3 movement = new Vector3(0f, 0f, verticalInput);
        movement.Normalize(); 

        
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && verticalInput > 0f;
        if (isRunning)
        {
            Stamania -= reduceStamania * Time.deltaTime;
        }
        else
        {
            Stamania += (reduceStamania * Time.deltaTime) / 3f;
        }

        if(Stamania <= 1f)
        {
            isRunning = false;
        }
        
        transform.Translate(movement * (isRunning ? speed * 2f : speed) * Time.deltaTime);


        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);


        animator.SetBool("IsMovingForward", (verticalInput > 0f));
        animator.SetBool("IsMovingBackward", (verticalInput < 0f));
        animator.SetBool("IsRunning", isRunning);

        CutTree();
        StamaniabarFunc();
        Punch();
        PunchValue();
        Kick();
    }

    void PunchValue()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.Log(isattacking);
        if (Physics.Raycast(ray, out hit, punchRange, enemyLayer) && isattacking)
        {
            Debug.Log("entered");
            GameObject hitEnemyGameObject = hit.collider.gameObject;
            floatingHealthBar fht = hitEnemyGameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<floatingHealthBar>();
            fht.enemyhealth -= punchDamage * Time.deltaTime;
}
    }
    void CutTree(){
        if(Input.GetKey(KeyCode.E)){
            animator.SetBool("CutTree",true);
            AxePre.SetActive(true);
        }
        else
        {
            animator.SetBool("CutTree",false);
            AxePre.SetActive(false);

        }
    }

    void StamaniabarFunc()
    {
        
        if (Stamania < 0)
        {
            Stamania = 0f;
        }
        StamaniaBar.fillAmount = Stamania / MaxStaminia;
    }

    void Kick()
    {
        if (Input.GetMouseButtonDown(1) && !isPlaying2)
        {
            isattacking = true;
            // Start the coroutine to play and wait for the punch animation to complete
            StartCoroutine(PlayKickAndWaitForCompletion());
        }
        
    }
    void Punch()
    {
        if (Input.GetMouseButtonDown(0) && !isPlaying)
        {
            isattacking = true;
            // Start the coroutine to play and wait for the punch animation to complete
            StartCoroutine(PlayPunchAndWaitForCompletion());
        }
        
    }
    IEnumerator PlayKickAndWaitForCompletion()
    {
        // Set the punch animation layer weight to 1
        animator.SetLayerWeight(2, 1f);

        // Play the punch animation
        animator.Play("kick", 2);

        // Set isPlaying to true to prevent triggering another coroutine while the animation is still playing
        isPlaying2 = true;

        // Wait for the punch animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(1).length);

        // Set the punch animation layer weight back to 0
        animator.SetLayerWeight(2, 0f);

        // Set isPlaying to false to allow triggering another coroutine
        isPlaying2 = false;
        isattacking = false;
    }

    IEnumerator PlayPunchAndWaitForCompletion()
    {
        // Set the punch animation layer weight to 1
        animator.SetLayerWeight(1, 1f);

        // Play the punch animation
        animator.Play("punch", 1);

        // Set isPlaying to true to prevent triggering another coroutine while the animation is still playing
        isPlaying = true;

        // Wait for the punch animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(1).length);

        // Set the punch animation layer weight back to 0
        animator.SetLayerWeight(1, 0f);

        // Set isPlaying to false to allow triggering another coroutine
        isPlaying = false;
        isattacking = false;
    }


}
