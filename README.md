# 3D_Taken0
 
중세시대 배경의 Taken

1. 시작화면

![image](https://user-images.githubusercontent.com/48191157/71571785-682d4800-2b1f-11ea-8fa7-b6a7896377bb.png)

2. 성 밖의 AI적군의 공격

![image](https://user-images.githubusercontent.com/48191157/71571787-6cf1fc00-2b1f-11ea-9613-f8879920e436.png)

    NavMeshAgent nav;
    GameObject target;
    public GameObject Warrior;
    public Animator Warrior_Ani;
    private AudioSource audio_source;
    public AudioClip beat;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = beat;
        audio_source.loop = false;
        audio_source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.destination !=target.transform.position)
        {
            nav.SetDestination(target.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player_Round"))
        {        
            Warrior_Ani.SetBool("Attack", true);
            Invoke("Attack_Cancel", 1.0f);         
        }
        if (other.CompareTag("Man_Attack"))
        {
            Warrior_Ani.SetBool("Die", true);
            audio_source.Play();
            Warrior.GetComponent<BoxCollider>().enabled = false;
            Invoke("Des", 1.1f);           
        }       
    }
     void Des()
    {
        Destroy(Warrior);
    }    
    void Attack_Cancel()
    {
        Warrior_Ani.SetBool("Attack", false);
    }

3. 적 대포의 타겟 공격

![image](https://user-images.githubusercontent.com/48191157/71571795-79765480-2b1f-11ea-9db5-d721067189c3.png)

    void Update()
    {
        this.transform.LookAt(target);
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject spawn_point = GameObject.Find("sp_bullet1");
            GameObject bullet = Instantiate(bulletPrefab, spawn_point.transform.position, spawn_point.transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

4. 성 안의 AI적군의 공격

![image](https://user-images.githubusercontent.com/48191157/71571800-8004cc00-2b1f-11ea-8b37-8de1a1a2aae1.png)

5. 적군의 왕과 대결

![image](https://user-images.githubusercontent.com/48191157/71571829-a296e500-2b1f-11ea-8915-fd1dfc46238f.png)

    public float m_StartingHealth = 100f;
    public float m_CurrentHealth;
    public GameObject Monster;
    public GameObject Hammer;
    public Animator Monster_Ani;
    public bool living = true;
    private AudioSource audio_source;
    public AudioClip beat;
    public AudioClip Die;
    public Image m_FillImage1;
    public Image m_FillImage2;
    public Image m_FillImage3;
    public Image m_FillImage4;
    public Image m_FillImage5;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_StartingHealth;
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = beat;
        audio_source.loop = false;
        audio_source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Man_Attack"))
        {
            m_CurrentHealth -= 10;
            audio_source.Play();
            if (m_CurrentHealth > 80)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 0f);
            if (m_CurrentHealth <= 80 && m_CurrentHealth > 60)
                m_FillImage5.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 60 && m_CurrentHealth > 40)
                m_FillImage4.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 40 && m_CurrentHealth > 20)
                m_FillImage3.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 20 && m_CurrentHealth > 0)
                m_FillImage2.color = Color.Lerp(Color.red, Color.white, 1f);
            if (m_CurrentHealth <= 0)
            {
                m_FillImage1.color = Color.Lerp(Color.red, Color.white, 1f);
                  Monster.GetComponent<BoxCollider>().enabled = false;
                audio_source.clip = Die;
                audio_source.Play();
                 Monster.transform.DOMove(new Vector3(-2.39f, 1.9f, 112.44f), 10.0f).SetEase(Ease.Linear);
                 Monster.transform.DORotate(new Vector3(-90f, 0f,73.12f), 1.0f).SetEase(Ease.Linear);
                 Invoke("Des", 1.5f);
                living = false;
                Hammer.GetComponent<BoxCollider>().enabled = false;
            }
        }
        }
     void Des()
    {
        Monster.SetActive(false);
    }

6. 구출 후 안기는 딸

![image](https://user-images.githubusercontent.com/48191157/71571845-b5111e80-2b1f-11ea-8b88-0a05cd8314ff.png)
