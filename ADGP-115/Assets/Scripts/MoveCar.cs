using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveCar : MonoBehaviour
{
    public float CarSpeed = 1.0f;
    Vector3 position;
    public bool HasRocket = false;
    public float Health = 100;
    public int GasTank = 1;
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

    private Rigidbody ridgidbody;

    // Use this for initialization
    void Start () {
        ridgidbody = GetComponent<Rigidbody>();
        position = transform.position;
        if (gameObject.tag == "P1")
        {
            movementAxisHorizontal = "P1Horizontal" ;
            movementAxisVertical = "P1Vertical" ;
            Rotate = "Mouse X";
            fire = "Fire1";
            fast = "Fast";
            Special = "Special";
        }
        if (gameObject.tag == "P2")
        {
            movementAxisHorizontal = "P2Horizontal";
            movementAxisVertical = "P2Vertical";
            Rotate = "Joystick2";
            fire = "Fire2";
            fast = "Fast2";
            Special = "Special2";
        }

        if (barrel == 0)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.1f, .4f, .1f);
            delaySpan = 5;
            Delay = 0;
            currentBullet = Sniper;
            currentWeapon.text = " Sniper";
        }
        else if (barrel == 1)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.3f, .2f, .2f);
            delaySpan = 3;
            Delay = 0;
            currentBullet = Shotgun;
            currentWeapon.text = " Shotgun";
        }
        else if (barrel == 2)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.2f, .2f, .2f);
            delaySpan = .1f;
            Delay = 0;
            currentBullet = MachineGun;
            currentWeapon.text = " Machine Gun";
            CarSpeed = 1.2f;
        }
        else if (barrel == 3)
        {
            this.gameObject.transform.GetChild(1).transform.localScale = new Vector3(.2f, .4f, .01f);
            this.gameObject.GetComponentInChildren<ChainsawScript>().Owner = this.gameObject;
            currentWeapon.text = " Chainsaw";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (alive)
        {
            if (HasRocket == true && Input.GetButtonDown(Special))
            {
                GameObject rocket = (GameObject)Instantiate(Rocket, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                rocket.GetComponent<RocketScript>().Owner = this.gameObject;
                HasRocket = false;
            }
            if (GasTank == 1)
            {
                if (Input.GetButtonDown(fast))
                {
                    CarSpeed = 3.0f;
                    GasTank = 1;
                }
            }
            if (CarSpeed == 3.0f)
            {
                Boost = 5;
                CarSpeed = 2.0f;
                BoostCurrent = true;
                GasTank -= 1;
            }
            if (BoostCurrent == true)
            {
                Boost -= Time.deltaTime;
            }
            if (Boost <= 0)
            {
                CarSpeed = 1.0f;
                BoostCurrent = false;
                
            }

            position.x += Input.GetAxis(movementAxisHorizontal) * CarSpeed * Time.deltaTime;
            position.z += Input.GetAxis(movementAxisVertical) * CarSpeed * Time.deltaTime;
           
            transform.position += transform.forward * CarSpeed * Input.GetAxis(movementAxisVertical);
            transform.position += transform.right * CarSpeed * Input.GetAxis(movementAxisHorizontal);
            //transform.position = new Vector3(transform.position.x + Input.GetAxis(movementAxisHorizontal), 0,transform.forward.z + Input.GetAxis(movementAxisVertical));


            float yAxis = transform.rotation.eulerAngles.y + (150.0F * Input.GetAxis(Rotate) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, yAxis, 0);
            if (Input.GetButtonDown(fire))
                shooting = true;
            if (Input.GetButtonUp(fire))
                shooting = false;
            if ((shooting && (Delay <= 0)) && (barrel != 3))
            {
                GameObject Bullet = (GameObject)Instantiate(currentBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Bullet.GetComponent<bullet>().Owner = this.gameObject;
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
        if (GasTank == 2)
            GasTank = 1;
	}

    void TankDeath()
    {
        if (Health <= 0)
        {
            winScreen.gameObject.SetActive(true);
            alive = false;
        }
    }
}
