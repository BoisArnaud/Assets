using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int exp ;
	private int expMax ;
	private int expPerLevel;

	public int level ;
	public int money  ;



	public int force ; // influe sur l'attaque min et max

	private int attackMin ;
	private int attackMax ;
	private int attackPerLevel ; 
	private float attackMinFactor ;
	private float attackMaxFactor ;

	public int endurance ; // influe health max et la l'armure min et max

	public int health ;
	private int healthMax ;
	private int healthPerLevel ;
	private float healthFactor ;
	private int armorMin ;
	private int armorMax ;
	private int armorPerLevel ;
	private float armorMinFactor ;
	private float armorMaxFactor ;

	public int agilite ; // influe sur l'esquive et les chances de coup critiques 

	private int escape ; // en pourcentage 
	private float escapeFactor ;
	private int escapeMax ; 
	private int criticDamage ; // en pourcentage
	private float criticFactor ;
	private int criticMax ; 

	public int intelligence ; // influe sur la puissance d'attaque magique min et max ainsi que le mana max
	
	public int mana ;
	private int manaMax ;
	private int manaPerLevel ;
	private float manaFactor ;
	private int attackMagicMin ;
	private int attackMagicMax ;
	private int attackMagicPerLevel ; 
	private float attackMagicMinFactor ;
	private float attackMagicMaxFactor ;


	public int charisme ;  // influe sur la chance de  drop , chance de double gold et les reduction de prix 

	private int luck ; // en poucentage 
	private float luckFactor ;
	private int luckMax ;
	private int bonusGold ; // en pourcentage
	private float bonusGoldFactor ;
	private int bonusGoldMax ;
	private int priceReduction ; // en pourcentage
	private float priceReductionFactor ;
	private int priceReductionMax ;


	
	public GameObject[] skill; 
	 

	void Start () {

		attackPerLevel = 3 ;
		attackMinFactor = 0.8f;
		attackMaxFactor = 1.2f; 

		attackMagicPerLevel = 3 ;
		attackMagicMinFactor = 0.8f;
		attackMagicMaxFactor = 1.2f; 

		armorPerLevel = 1 ;
		armorMinFactor = 0.2f ;
		armorMaxFactor = 0.4f ;

		healthPerLevel = 10 ;
		healthFactor = 1.7f ;

		manaPerLevel = 12 ;
		manaFactor = 1.9f ;

		escapeFactor = 0.75f;
		escapeMax = 75 ;

		criticFactor = 0.75f;
		criticMax = 90; 

		luckFactor = 1.5f ;
		luckMax = 100 ;
		bonusGoldFactor = 1.5f ;
		bonusGoldMax = 200;
		priceReductionFactor = 0.75f ;
		priceReductionMax  = 85 ;

		expPerLevel = 10 ;

	

	}

	public void initPlayer(){
		force = 1 ;
		endurance = 1 ;
		intelligence = 1 ;
		agilite = 1 ;
		charisme = 1 ;
		exp = 0 ;
		level = 1 ;
		money = 0 ;

		checkAllCarac ();
		checkExpMax() ;

		mana = manaMax ;
		health = healthMax ;

	}

	public void loadPlayer(){
		this.money = PlayerPrefs.GetInt("money") ;
		this.exp   = PlayerPrefs.GetInt("exp") ;
		this.level = PlayerPrefs.GetInt("level") ;
		
		// sauvegarde des caractéristiques ;
		this.force = PlayerPrefs.GetInt("force") ;
		this.endurance = PlayerPrefs.GetInt("endurance") ;
		this.intelligence = PlayerPrefs.GetInt("intelligence") ;
		this.agilite = PlayerPrefs.GetInt("agilite") ;
		this.charisme = PlayerPrefs.GetInt("charisme") ;

		checkAllCarac ();
		checkExpMax ();

	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("x")) {
			exp += 10 ;
		}
		checkAllCarac ();
		checkXp ();

	}

	void checkXp(){
		if (exp >= expMax) {
			exp = 0 ;

			level ++ ;
			checkExpMax();
			checkAllCarac();
			mana = manaMax ;
			health = healthMax ;
		}

	}
	
	void checkAllCarac(){
		checkAttack();
		
		checkAttackMagic();
		checkMana();
		
		
		checkArmor();
		checkHealth();
		
		
		checkEscape();
		checkCriticDamage();
		
		checkBonusGold();
		checkLuck();
		checkPriceReduction();
	}	

	void checkExpMax(){
		expMax = 100 ;
		for (int i = 0; i <= level; i++) {
			expMax += expPerLevel * i * i ;
		}
	}

	void checkAttack(){
		attackMin = (int)(force * attackPerLevel + (force * attackMaxFactor));
		attackMax = (int)(force * attackPerLevel + (force * attackMinFactor));
	}

	void checkAttackMagic(){
		attackMagicMin = (int)(intelligence * attackMagicPerLevel + (intelligence * attackMagicMaxFactor));
		attackMagicMax = (int)(intelligence * attackMagicPerLevel + (intelligence * attackMagicMinFactor));
	}

	void checkMana(){
		manaMax = (int)(intelligence * manaPerLevel + (intelligence * manaFactor));
	}

	void checkArmor(){
		armorMin = (int)(endurance * armorPerLevel + ( endurance * armorMinFactor ));
		armorMax = (int)(endurance * armorPerLevel + ( endurance * armorMaxFactor ));
	}

	void checkHealth(){
		healthMax = (int)(endurance * healthPerLevel + (endurance * healthFactor));
	}

	void checkEscape(){
		escape = (int)(agilite * escapeFactor) ; 
		if (escape > escapeMax) {
			escape = escapeMax ;
		}
	}

	void checkCriticDamage(){
		criticDamage = (int)(agilite * criticFactor) ;
		if (criticDamage > criticMax) {
			criticDamage = criticMax ;
		}
	}

	void checkLuck(){
		luck = (int)(charisme * luckFactor) ;
		if (luck > luckMax) {
			luck = luckMax ;
		}
	}

	void checkBonusGold(){
		bonusGold = (int)(charisme * bonusGoldFactor) ;
		if (bonusGold > bonusGoldMax) {
			bonusGold = bonusGoldMax ;
		}
	}

	void checkPriceReduction(){
		priceReduction = (int)(charisme * priceReductionFactor);
		if (priceReduction > priceReductionMax) {
			priceReduction = priceReductionMax ;
		}
	}



	void dead(){
		Debug.Log ("vous etes mort");
	}

	void OnGUI(){

		GUI.BeginGroup( new Rect(10f,10f,300f,300f));
		GUI.Box(new Rect(25f, 10f, 150f,25f), this.health+"/"+this.healthMax);
		GUI.Label (new Rect (30f, 10.5f, 50f, 20f), "HP :");
		GUI.EndGroup() ;

		GUI.Box(new Rect(60f, 75f, 130f,25f), "Gold: "+ this.money	);
		GUI.Box(new Rect(60f, 100f, 130f,25f), "XP: "+ this.exp);
		GUI.Box(new Rect(60f, 125f, 130f,25f), "Lv : "+ this.level);

	}

	void OnTriggerEnter(Collider hit ){
		if (hit.transform.tag == "Weapon") {
			this.health -= hit.GetComponentInParent<AdvancedAI>().damage ;
			Debug.Log("Vide du joueur" +this.health);
			if(health<=0){
				dead();
			}
		}
	}

	public void addExp(int exp){
		this.exp += exp;
	}

	public void addMoney(int money){
		this.money += money;
	}

	public Skill getSkill(int i){
		return skill[i].GetComponent<Skill>();
	}

	public void setHealth(int healthp){
		this.health = healthp;
	}

	public int getHealth(){
		return this.health;
	}

	public void setHealthMax(int healthp){
		this.healthMax = healthp;
	}

	public int getHealthMax(){
		return this.healthMax;
	}

	public int getMana(){
		return this.mana;
	}
	
	public int getManaMax(){
		return this.manaMax;
	}

	public int getMoney(){
		return this.money;
	}

	public void setMoney(int money){
		this.money = money;
	}

	public int getExp(){
		return this.exp;
	}

	public int getLevel(){
		return this.level;
	}

	// caracteristiques

	public int getForce(){
		return this.force;
	}

	public int getEndurance(){
		return this.endurance;
	}

	public int getAgilite(){
		return this.agilite;
	}

	public int getIntelligence(){
		return this.intelligence;
	}

	public int getCharisme(){
		return this.charisme;
	}


	public void setForce(int force){
		this.force = force;
	}
	
	public void setEndurance(int endurance){
		this.endurance = endurance;
	}
	
	public void setAgilite(int agilite){
		this.agilite = agilite;
	}
	
	public void setIntelligence(int intelligence){
		this.intelligence = intelligence;
	}
	
	public void setCharisme(int charisme){
		this.charisme = charisme;
	}


	// retourne une attaque aléatoire entre l'attaque Min et Max 
	public int getAttack(){
		return Random.Range (attackMin, attackMax);
	}



}
