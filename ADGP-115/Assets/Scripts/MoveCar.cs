using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveCar : MonoBehaviour
{
    public float CarSpeed = 1.0f;
    float BaseSpeed = 0.0f;
    //Vector3 position;
    public bool HasRocket = false;
    public float Health = 100;
    public int GasTank = 0;
    string movementAxisHorizontal;
    string movementAxisVertical;
    string fire;
    string Rotate;
    string Special;
    public GameObject Sniper;
    public GameObject Shotgun;
    public GameObject MachineGun;
    public GameObject Rocket;
    bool shooting = false;
    public int barrel = 0;
    float delaySpan = 1;
    float Delay = 1;
    public float Boost;
    public bool BoostCurrent = false;
    public GameObject currentBullet;
    bool alive = true;
    string fast;
    public Slider healthSlider;
    public Text currentWeapon;
    public Transform winScreen, HUD;
    //private Rigidbody ridgidbody;

    public AudioSource powerup;
    public AudioSource takedamage;
    public AudioSource rocket;

    // Use this for initialization
    void Start()
    {
        //ridgidbody = GetComponent<Rigidbody>();

        //position = transform.position; //Used to edit the player's location.

        //This edits the string values of Player 1's controls.
        if (gameObject.tag == "P1")
        {
            movementAxisHorizontal = "P1Horizontal";
            movementAxisVertical = "P1Vertical";
            Rotate = "Mouse X";
            fire = "Fire1";
            fast = "Fast";
            Special = "Special";
        }
        //This edits the string values of Player 2's controls.
        if (gameObject.tag == "P2")
        {
            movementAxisHorizontal = "P2Horizontal";
            movementAxisVertical = "P2Vertical";
            Rotate = "Joystick2";
            fire = "Fire2";
            fast = "Fast2";
            Special = "Special2";
        }

        //This conditional checks if the player's barrel is a Sniper barrel,
        //and gives the player's gun the Sniper functionality.
        if (barrel == 0)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.1f, .2f, .1f);
            delaySpan = 5;
            Delay = 0;
            currentBullet = Sniper;
            currentWeapon.text = " Sniper";
            BaseSpeed = 60.0f;
        }
        //This conditional checks if the player's barrel is a Shotgun barrel,
        //and gives the player's gun the Shotgun functionality.
        else if (barrel == 1)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.3f, .2f, .2f);
            delaySpan = 2;
            Delay = 0;
            currentBullet = Shotgun;
            currentWeapon.text = " Shotgun";
            BaseSpeed = 60.0f;
        }
        //This conditional checks if the player's barrel is a Machine Gun barrel,
        //and gives the player's gun the Machine Gun functionality.
        else if (barrel == 2)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.2f, .2f, .2f);
            delaySpan = .1f;
            Delay = 0;
            currentBullet = MachineGun;
            currentWeapon.text = " Machine Gun";
            BaseSpeed = 60.0f;
        }
        //This conditional checks if the player's barrel is a chainsaw,
        //and gives the player's barrel, chainsaw functionality.
        else if (barrel == 3)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.2f, .4f, .01f);
            this.gameObject.GetComponentInChildren<ChainsawScript>().Owner = this.gameObject;
            currentWeapon.text = " Chainsaw";
            BaseSpeed = 70.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (alive) //Checks to see if the player is alive.
        {
            if (HasRocket == true && Input.GetButtonDown(Special)) // Removes the rocket from the inventory and creates the rocket at barrel location
            {
                GameObject rocket = (GameObject)Instantiate(Rocket, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                rocket.GetComponent<RocketScript>().Owner = this.gameObject;
                HasRocket = false;
            }
            if (GasTank == 1) //checks to see if the player has a usable boost.
            {
                if (Input.GetButtonDown(fast))//If the button designated for player
                {
                    CarSpeed = 3.0f;
                    GasTank = 0;
                }
            }
            if (CarSpeed == 3.0f) //Speed settings fur during the boost
            {
                Boost = 5;
                CarSpeed = 120.0f;
                BoostCurrent = true;
                GasTank -= 1;
            }
            if (BoostCurrent == true) // A timer counting down for the boost duration.
            {
                Boost -= Time.deltaTime;
            }
            if (Boost <= 0)  //resets carspeed after the boost duration is out.
            {
                CarSpeed = BaseSpeed;
                BoostCurrent = false;

            }

            transform.position += transform.forward * CarSpeed * Input.GetAxis(movementAxisVertical) * Time.deltaTime;
            transform.position += transform.right * CarSpeed * Input.GetAxis(movementAxisHorizontal) * Time.deltaTime;

            float yAxis = transform.rotation.eulerAngles.y + (150.0F * Input.GetAxis(Rotate) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, yAxis, 0);

            //Fires the Player's gun as long as the designated button is pressed.
            if (Input.GetButtonDown(fire))
                shooting = true;
            if (Input.GetButtonUp(fire))
                shooting = false;

            //Conditional for firing the Player's gun depending of the type of gun and its bullets and delay.
            if ((shooting && (Delay <= 0)) && (barrel != 3))
            {
                GameObject Bullet = (GameObject)Instantiate(currentBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Bullet.GetComponent<bullet>().Owner = this.gameObject;
                //Special bullet creation for shotgun.
                if (barrel == 1)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        GameObject exPosBullet = (GameObject)Instantiate(currentBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z) + (transform.right * (5 * i)), Quaternion.identity);
                        exPosBullet.GetComponent<bullet>().Owner = this.gameObject;
                        GameObject exNegBullet = (GameObject)Instantiate(currentBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z) - (transform.right * (5 * i)), Quaternion.identity);
                        exNegBullet.GetComponent<bullet>().Owner = this.gameObject;
                    }
                }
                Delay = delaySpan;
            }
        }
        healthSlider.value = Health;
        TankDeath();
        Delay -= Time.deltaTime;
        if (GasTank == 2) //Limits the amount of boosts you can have.
            GasTank = 1;
    }


    void TankDeath() //kills the player and sends the game to the win screen.
    {
        if (Health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            winScreen.gameObject.SetActive(true);
            alive = false;
        }
    }
}
