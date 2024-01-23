using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public bool mailRead, mailDay;
    public string playerName;
    private TimeManager timeManager;
    public PlayerData playerData;
    public GameObject hair, trousers, eyes, shoes, tshirt, baseskin, glasses;
    public GameObject[] hairs, bottoms, tshirts, skinbase;


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
        foreach (GameObject hair in hairs)
        {
            hair.SetActive(false);
        }

        foreach (GameObject bottom in bottoms)
        {
            bottom.SetActive(false);
        }

        foreach (GameObject skin in skinbase)
        {
            skin.SetActive(false);
        }

        foreach (GameObject tee in tshirts)
        {
            tee.SetActive(false);
        }

        SetPlayerCustomisation();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SetStartingPositions();
        LoadSceneAndSetPosition("Home", gameLoadPos); // load out of bed
        loadpanel = GameObject.Find("UI").GetComponent<LoadPanel>();
        timeManager = GameObject.Find("DayTimePanel").GetComponent<TimeManager>();
        mailDay = false;
        mailRead = false;

    }

    public void SetPlayerCustomisation()
    {
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        playerName = playerData.playerName;

        // player customisation from the player data
        hair = hairs[playerData.hairInt];
        trousers = bottoms[playerData.bottomsInt];
        tshirt = tshirts[playerData.teeInt];
        baseskin = skinbase[playerData.teeInt];

        // set the appropriate GOs to active
        hair.SetActive(true);
        trousers.SetActive(true);
        tshirt.SetActive(true);
        baseskin.SetActive(true);
        if (playerData.glasses.enabled)
        {
            glasses.SetActive(true);
        }

        // and set the correct colors
        hair.GetComponent<SpriteRenderer>().color = playerData.hairColor;
        trousers.GetComponent<SpriteRenderer>().color = playerData.trousersColor;
        tshirt.GetComponent<SpriteRenderer>().color = playerData.tshirtColor;
        eyes.GetComponent<SpriteRenderer>().color = playerData.eyeColor;
        shoes.GetComponent<SpriteRenderer>().color = playerData.shoesColor;
        baseskin.GetComponent<SpriteRenderer>().color = playerData.skinColor;
    }

    private void SetStartingPositions()
    {
        // set starting positions depending on which building entered/exited
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

        if (timeManager.IsItMailDay())
        {
            mailDay = true;
        }
        else
        {
            mailDay = false;
        }

    }

    public void OnTriggerEnter2D(Collider2D thing)
    {
        // check if the collider is a trigger
        if (!thing.isTrigger)
        {
            // exit the method if the collider is not a trigger
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

    private void DisableRenderersInChildren()
    {
        foreach (Transform child in transform)
        {
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();

            if (childRenderer != null)
            {
                childRenderer.enabled = false;
            }
        }
    }

    private void EnableRenderersInChildren()
    {
        foreach (Transform child in transform)
        {
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();

            if (childRenderer != null)
            {
                childRenderer.enabled = true;
            }
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

        // disable the player's renderer components
        DisableRenderersInChildren();
        loadpanel.HideAllUI();

        SceneManager.LoadScene(scene);

        yield return new WaitForEndOfFrame();

        // set the player position depending on the scene
        transform.position = position;

        // enable the renderer and collider component
        EnableRenderersInChildren();

    }

}
