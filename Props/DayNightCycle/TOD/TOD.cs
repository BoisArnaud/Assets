using UnityEngine;
using System.Collections;

public class TOD : MonoBehaviour {

	public float slider ;
	public float slider2;
	public float hour;

	private float tod ;

	public Light sun ;

	public float speed ;

	public Color nightFogColor ;
	public Color duskFogColor ;
	public Color morningFogColor ;
	public Color middayFogColor ;

	public Color nightAmbientLight ;
	public Color duskAmbientLight ;
	public Color morningAmbientLight ;
	public Color middayAmbientLight ;

	public Color nightTint;
	public Color duskTint;
	public Color morningTint;
	public Color middayTint;

	public Material skyBoxMaterial1 ;
	public Material skyBoxMaterial2 ;

	public Color sunNight;
	public Color sunDay ;

	public GameObject water ;
	public bool includeWater ;
	public Color waterNight ;
	public Color waterDay ;

	// Use this for initialization
	void Start () {
		slider = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(slider >= 1.0)
		{
			slider = 0;
		}
		
	//	slider= GUI.HorizontalSlider(new Rect(20,20,200,30), slider, 0.0f,1.0f);
		hour = slider*24;
		tod  = slider2*24;
		sun.transform.localEulerAngles = new Vector3((slider*360)-90, 0.0f, 0.0f);
		slider = slider +Time.deltaTime/speed;
		sun.color = Color.Lerp (sunNight, sunDay, slider*2);

		if (includeWater == true){
			//water.renderer.material.SetColor("_horizonColor", Color.Lerp (waterNight, waterDay, slider2*2-0.2));
		}

		if(slider<0.5){
			slider2= slider;
		}
		if(slider>0.5){
			slider2= (1-slider);
		}
		sun.intensity = (float)(slider2-0.2)*1.7f;

		if(tod < 4){
			//it is Night
			RenderSettings.skybox= skyBoxMaterial1;
			RenderSettings.skybox.SetFloat("_Blend", 0);
			skyBoxMaterial1.SetColor ("_Tint", nightTint);
			RenderSettings.ambientLight = nightAmbientLight;
			RenderSettings.fogColor = nightFogColor;
		}
		if(tod > 4 && tod < 6){
			RenderSettings.skybox=skyBoxMaterial1;
			RenderSettings.skybox.SetFloat("_Blend", 0);
			RenderSettings.skybox.SetFloat("_Blend", (tod/2)-2);
			skyBoxMaterial1.SetColor("_Tint", Color.Lerp (nightTint, duskTint, (tod/2)-2) );
			RenderSettings.ambientLight = Color.Lerp (nightAmbientLight, duskAmbientLight, (tod/2)-2);
			RenderSettings.fogColor = Color.Lerp (nightFogColor,duskFogColor, (tod/2)-2);
			//it is Dusk
			
		}
		if(tod > 6 && tod < 8){
			RenderSettings.skybox=skyBoxMaterial2;
			RenderSettings.skybox.SetFloat("_Blend", 0);
			RenderSettings.skybox.SetFloat("_Blend", (tod/2)-3);
			skyBoxMaterial2.SetColor("_Tint", Color.Lerp (duskTint,morningTint,  (tod/2)-3) );
			RenderSettings.ambientLight = Color.Lerp (duskAmbientLight, morningAmbientLight, (tod/2)-3);
			RenderSettings.fogColor = Color.Lerp (duskFogColor,morningFogColor, (tod/2)-3);
			//it is Morning
			
		}
		if( tod > 8 && tod < 10){
			RenderSettings.ambientLight = middayAmbientLight;
			RenderSettings.skybox=skyBoxMaterial2;
			RenderSettings.skybox.SetFloat("_Blend", 1);
			skyBoxMaterial2.SetColor("_Tint", Color.Lerp(morningTint,middayTint,  (tod/2)-4) );
			RenderSettings.ambientLight = Color.Lerp(morningAmbientLight, middayAmbientLight, (tod/2)-4);
			RenderSettings.fogColor = Color.Lerp(morningFogColor,middayFogColor, (tod/2)-4);

		}

	}
}

