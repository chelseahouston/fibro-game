using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static Player instance;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    public Vector3 homePosition, shopPosition, commPosition, medPosition, gameLoadPos; // player's inside positions
    public Vector3 outsideHomePos, outsideShopPos, outsideCommPosition, outsideMedPos; // player's outside positions
    public string sceneName;
    public LoadPanel loadpanel;

    private void Awake()
    {
        // Ensure there is only one instance of the Player object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SetStartingPositions();
        LoadSceneAndSetPosition("Home", gameLoadPos); // load out of bed
        loadpanel = GameObject.Find("UI").GetComponent<LoadPanel>();
    }

    private void SetStartingPositions()
    {
        // set starting positions
        gameLoadPos = new Vector3(-21.5f, -15f, 0f);
        homePosition = new Vector3(-28.476f, -27.456f, 0f);
        shopPosition = new Vector3(-23.48f, -27.58f, 0f);
        commPosition = new Vector3(-22.05f, -24.82f, 0f);
        medPosition = new Vector3(-31.45f, -26.5f, 0f);
        outsideHomePos = new Vector3(-28.476f, -26.572f, 0f);
        outsideShopPos = new Vector3(-15.53f, -34.59f, 0f);
        outsideCommPosition = new Vector3(14.40f, -19.6f, 0f);
        outsideMedPos = new Vector3(-8.55f, -13.57f, 0f);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        rb.velocity = movement * moveSpeed;

        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    public void OnTriggerEnter2D(Collider2D thing)
    {

        // Check if the collider is a trigger
        if (!thing.isTrigger)
        {
            // Exit the method if the collider is not a trigger
            return;
        }

        sceneName = SceneManager.GetActiveScene().name;


        switch (sceneName)
        {
            case "Home":
                LeaveHomeScene(thing);
                break;
            case "Outside":
                LeaveOutsideScene(thing);
                break;
            case "Shop":
                LeaveShopScene(thing);
                break;
            case "CommunityClub":
                LeaveCommunityClubScene(thing);
                break;
            case "MedCentre":
                LeaveMedicalCentreScene(thing);
                break;
        }

    }

    

    private void LeaveHomeScene(Collider2D thing)
    {
        if (thing.tag == "HomeDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideHomePos));
        }
    }

    private void LeaveShopScene(Collider2D thing)
    {
        if (thing.tag == "ShopDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideShopPos));
        }
    }

    private void LeaveCommunityClubScene(Collider2D thing)
    {
        if (thing.tag == "CommDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideCommPosition));
        }
    }

    private void LeaveMedicalCentreScene(Collider2D thing)
    {
        if (thing.tag == "MedicalDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideMedPos));
        }
    }

    private void LeaveOutsideScene(Collider2D thing)
    {
        switch (thing.tag)
        {
            case "HomeDoor":
                StartCoroutine(LoadSceneAndSetPosition("Home", homePosition));
                break;
            case "ShopDoor":
                StartCoroutine(LoadSceneAndSetPosition("Shop", shopPosition));
                break;
            case "CommDoor":
                StartCoroutine(LoadSceneAndSetPosition("CommunityClub", commPosition));
                break;
            case "MedicalDoor":
                StartCoroutine(LoadSceneAndSetPosition("MedCentre", medPosition));
                break;
        }
    }

    IEnumerator LoadSceneAndSetPosition(string scene, Vector3 position)
    {

        // disable the player's renderer component
        Renderer rendererComponent = GetComponent<Renderer>();
        rendererComponent.enabled = false;
        loadpanel.HideAllUI();

        SceneManager.LoadScene(scene);

        yield return new WaitForEndOfFrame();

        // set the player position depending on the scene
        transform.position = position;

        // enable the renderer and collider component
        rendererComponent.enabled = true;;

    }

}
