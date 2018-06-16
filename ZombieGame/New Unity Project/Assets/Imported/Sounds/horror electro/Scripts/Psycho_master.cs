using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Psycho_master : MonoBehaviour {

	//public EnemyManager EnemyManager;
	public bool use_triggers;

	public int enemy_number = 0;
	public Transform enemy_bunny0;
	public Transform enemy_bear0;
	public Transform enemy_helle0;
	public Transform enemy_bunny1;
	public Transform enemy_bear1;
	public Transform enemy_helle1;
	public Transform enemy_bunny2;
	public Transform enemy_bear2;
	public Transform enemy_helle2;
	public Transform enemy_bunny3;
	public Transform enemy_bear3;
	public Transform enemy_helle3;
	public Transform enemy_bunny4;
	public Transform enemy_bear4;
	public Transform enemy_helle4;
	public Transform Ambiant_trigger;
	private float reset_time;
	private float reset_pause = 2.0f;

	private float bunny0;
	private float bunny1;
	private float bunny2;
	private float bunny3;
	private float bunny4;
	private float bear0;
	private float bear1;
	private float bear2;
	private float bear3;
	private float bear4;
	private float helle0;
	private float helle1;
	private float helle2;
	private float helle3;
	private float helle4;


	public Transform Player;
	public float reset_timer;
	private float Ambiant_mood;
	private float Tension_mood_A;
	private float Tension_mood_B;
	private float Terror_mood_A;
	private float Terror_mood_B;

	private float ambiant_mood_distance = 5000;
	private float tension_mood_A_distance = 5000;
	private float tension_mood_B_distance = 5000;
	private float terror_mood_A_distance = 5000;
	private float terror_mood_B_distance = 5000;
	public float trigger_sensitivity;
	public float nearest_bunny;
	public float nearest_bear;
	public float nearest_helle;

	//GENERAL
	public AudioMixer psycho_mixer;
	private float bpm = 160.0f;
	private int beatsPerMeasure = 4;
	private double singleMeasureTime;
	private double delayEvent;
	private bool running = false;
	private int i;
	private int y;
	private bool abrupt_change;
	public bool reset = false;
	private bool first_run = false;
	private bool end_terror_percs = false;

	public int ambiant_patch_0_7;

	public int tension_main_patch_0_15;
	public int tension_short_patch_0_7;
	public int tension_percs_0_15;

	public int terror_main_patch_0_7;
	public int terror_bass_0_7;
	public int terror_percs_0_7;
	public int terror_intense_0_7;

	private int random_ambiant_synth;

	private int random_tension_long;
	private int random_tension_short;
	private int random_tension_percs;
	
	private int random_terror_long;
	private int random_terror_bass;
	
	private int random_terror_percs;
	private int random_terror_intense;
	
	private int random_hits;

		
	public float fadeout_speed = 30f;
	public float fadein_speed = 60f;
	
	private AudioSource audio_ambiant_synth;
	
	private AudioSource audio_tension_long;
	private AudioSource audio_tension_short;
	private AudioSource audio_tension_percs;
	
	private AudioSource audio_terror_long;
	private AudioSource audio_terror_bass;
	
	private AudioSource audio_terror_percs;
	private AudioSource audio_terror_intense;
	private AudioSource audio_terror_percs_end;
	private AudioSource audio_terror_background;

	private AudioSource audio_hits;

	private float audio_ambiant_synth_vol = 0.0f;

	private float audio_tension_long_vol = 0.0f;
	private float audio_tension_short_vol = 0.0f;
	private float audio_tension_percs_vol = 0.0f;
	
	private float audio_terror_long_vol = 0.0f;
	private float audio_terror_bass_vol = 0.0f;
	
	private float audio_terror_percs_vol = 0.0f;
	private float audio_terror_intense_vol = 0.0f;
	private float audio_terror_background_vol = 0.0f;

	private bool bunny_trigger = false;
	private bool bear_trigger = false;
	private bool helle_trigger = false;
	
	private bool ambiant;
	private bool tension;
	private bool terror;

	public bool ambiant_long_bool;
	public bool tension_long_bool;
	public bool tension_short_bool;
	public bool tension_percs_bool;

	public bool terror_long_bool;
	public bool terror_bass_bool;
	public bool terror_percs_bool;
	public bool terror_intense_bool;
	public bool terror_background_bool;
	private bool start_terror_percs;

	public bool hits;

	private bool ambiant_isPlaying;
	private bool tension_isPlaying;
	private bool terror_isPlaying;

	private bool start = false;

	private AudioSource audio_demo;
	
	private Object[] AudioArray_ambiant_synth;
	private Object[] AudioArray_ambiant_percs;
	private Object[] AudioArray_tension_long;
	private Object[] AudioArray_tension_short;
	private Object[] AudioArray_terror_long;
	private Object[] AudioArray_terror_bass;
	private Object[] AudioArray_terror_percs;
	private Object[] AudioArray_terror_intense;
	private Object[] AudioArray_terror_percs_end;
	private Object[] AudioArray_audio_hits;
	private Object[] AudioArray_demo;
		
	// Use this for initialization
	void Start () {

		first_run = false;
		beatsPerMeasure = 4;
		int i = 0;
		bpm = 160.0f;
		audio_demo = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_ambiant_synth = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_tension_long = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_tension_short = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_tension_percs = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_terror_long = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_terror_bass = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_terror_percs = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_terror_percs_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_terror_intense = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_terror_background = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_hits = (AudioSource)gameObject.AddComponent <AudioSource>();

		audio_ambiant_synth.loop = true;
		
		audio_tension_long.loop = true;
		audio_tension_short.loop = true;
		audio_tension_percs.loop = true;
		
		audio_terror_long.loop = true;
		audio_terror_bass.loop = true;
		audio_terror_background.loop = true;
		
		audio_terror_percs.loop = true;
		audio_terror_intense.loop = true;

		ambiant_patch_0_7 = -1;
		
		tension_main_patch_0_15= -1;
		tension_short_patch_0_7= -1;
		tension_percs_0_15= -1;
		
		terror_main_patch_0_7= -1;
		terror_bass_0_7= -1;
		terror_percs_0_7= -1;
		terror_intense_0_7= -1;

		AudioArray_ambiant_synth = Resources.LoadAll("random/ambiant/synth",typeof(AudioClip));
		AudioArray_ambiant_percs = Resources.LoadAll("random/ambiant/percs",typeof(AudioClip));
		AudioArray_tension_long = Resources.LoadAll("random/tension/long",typeof(AudioClip));
		AudioArray_tension_short = Resources.LoadAll("random/tension/short",typeof(AudioClip));
		AudioArray_terror_long = Resources.LoadAll("random/terror/long",typeof(AudioClip));
		AudioArray_terror_bass= Resources.LoadAll("random/terror/bass",typeof(AudioClip));
		AudioArray_terror_percs= Resources.LoadAll("random/terror/percs",typeof(AudioClip));
		AudioArray_terror_percs_end= Resources.LoadAll("random/terror/end",typeof(AudioClip));
		AudioArray_terror_intense= Resources.LoadAll("random/terror/intense",typeof(AudioClip));
		AudioArray_audio_hits= Resources.LoadAll("random/hits",typeof(AudioClip));

		audio_ambiant_synth.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("ambiant_synth")[0];
		audio_tension_long.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("tension_synth_long")[0];
		audio_tension_short.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("tension_synth_short")[0];
		audio_tension_percs.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("tension_percs")[0];
		audio_terror_long.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("terror_synth_long")[0];
		audio_terror_bass.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("terror_bass")[0];
		audio_terror_percs.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("terror_percs")[0];
		audio_terror_percs_end.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("hits")[0];
		audio_terror_intense.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("terror_intense")[0];
		audio_terror_background.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("terror_background")[0];
		audio_hits.outputAudioMixerGroup = psycho_mixer.FindMatchingGroups("hits")[0];

		audio_ambiant_synth_vol = -80.0f;
		
		audio_tension_long_vol = -80.0f;
		audio_tension_short_vol = -80.0f;
		audio_tension_percs_vol = -80.0f;
		
		audio_terror_long_vol = -80.0f;
		audio_terror_bass_vol = -80.0f;
		audio_terror_background_vol = -80.0f;
		
		audio_terror_percs_vol = -80.0f;
		audio_terror_intense_vol = -80.0f;

		audio_ambiant_synth.volume = 0.0f;
		
		audio_tension_long.volume = 0.0f;
		audio_tension_short.volume = 0.0f;
		audio_tension_percs.volume = 0.0f;
		
		audio_terror_long.volume = 0.0f;
		audio_terror_bass.volume = 0.0f;
		audio_terror_background.volume = 0.0f;
		
		audio_terror_percs.volume = 0.0f;
		audio_terror_intense.volume = 0.0f;
		if (use_triggers) {
			Ambiant_trigger = GameObject.Find ("Ambiant_trigger").transform;
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		// COMMENT OUT THE TWO METHODS BELOW IF YOU DO NOT INTEND TO CONFIGURE/USE THEM!!!
		if (!reset & use_triggers) {
			CheckDistanceToTrigger ();
			SetMood ();
		}

		if (ambiant_long_bool) {
			if (!start) {
				start = true;
			}
			ambiant = true;
			tension = false;
			terror = false;
		}
		
		
		if (tension_long_bool) {
			if (!start) {
				start = true;
			}
			tension = true;
			ambiant = false;
			terror = false;
		}
		
		if (tension_short_bool) {
			if (!start) {
				start = true;
			}
			tension = true;
			ambiant = false;
			terror = false;
			
		}
		if (tension_percs_bool) {
			if (!start) {
				start = true;
			}
			tension = true;
			ambiant = false;
			terror = false;
		}
		if (terror_long_bool) {
			if (!start) {
				start = true;
			}
			terror = true;
			ambiant = false;
			tension = false;
		}
		if (terror_bass_bool) {
			if (!start) {
				start = true;
			}
			terror = true;
			ambiant = false;
			tension = false;
		}
		if (terror_percs_bool) {
			if (!start) {
				start = true;
			}
			terror = true;
			ambiant = false;
			tension = false;
		}
		if (terror_intense_bool) {
			if (!start) {
				start = true;
			}
			terror = true;
			ambiant = false;
			tension = false;
		}
		if (terror_background_bool) {
			if (!start) {
				start = true;
			}
			terror = true;
			ambiant = false;
			tension = false;
		}
		


		psycho_mixer.SetFloat ("ambiant_synth", audio_ambiant_synth_vol);
		psycho_mixer.SetFloat ("tension_synth_long", audio_tension_long_vol);
		psycho_mixer.SetFloat ("tension_synth_short", audio_tension_short_vol);
		psycho_mixer.SetFloat ("tension_percs", audio_tension_percs_vol);
		psycho_mixer.SetFloat ("terror_synth_long", audio_terror_long_vol);
		psycho_mixer.SetFloat ("terror_bass", audio_terror_bass_vol);
		psycho_mixer.SetFloat ("terror_percs", audio_terror_percs_vol);
		psycho_mixer.SetFloat ("terror_background", audio_terror_background_vol);
		psycho_mixer.SetFloat ("terror_intense", audio_terror_intense_vol);

		if (start) {
			Psycho_Play ();

			if (!first_run){
				singleMeasureTime = AudioSettings.dspTime + 2.0F;
				running = true;
			}
			first_run = true;
		}	

		if (!terror & terror_isPlaying & audio_terror_percs_vol > -80.0f) {
			end_terror_percs = true;
		}

		if (!ambiant & !tension & !terror) {
			if (audio_ambiant_synth_vol > -80.0f) {
				audio_ambiant_synth_vol -= fadeout_speed * Time.deltaTime;	
			}
			if (audio_tension_long_vol > -80.0f | audio_tension_short_vol > -80.0f| audio_tension_percs_vol > -80.0f) {
				audio_tension_long_vol -= fadeout_speed * Time.deltaTime;	
				audio_tension_short_vol -= fadeout_speed * Time.deltaTime;
				audio_tension_percs_vol -= fadeout_speed * Time.deltaTime;
			}
			if (audio_terror_long_vol > -80.0f | audio_terror_bass_vol > -80.0f| audio_terror_percs_vol > -80.0f| audio_terror_intense_vol > -80.0f| audio_terror_background_vol > -80.0f) {
				audio_terror_long_vol -= fadeout_speed * Time.deltaTime;	
				audio_terror_bass_vol -= fadeout_speed * Time.deltaTime;
				audio_terror_intense_vol -= fadeout_speed * Time.deltaTime;
				audio_terror_background_vol -= fadeout_speed * Time.deltaTime;
			}

			if (audio_terror_long_vol < -50.0f & audio_terror_bass_vol < -50.0f & audio_terror_percs_vol < -50.0f & audio_terror_intense_vol < -50.0f & audio_terror_background_vol < -50.0f) {
				terror_isPlaying = false;
				terror_long_bool = false;
				terror_bass_bool = false;
				terror_intense_bool = false;
				terror_background_bool = false;
				terror_percs_bool = false;
			}

			if (audio_tension_long_vol < -50.0f  & audio_tension_short_vol < -50.0f & audio_tension_percs_vol < -50.0f) {
				tension_isPlaying = false;
				tension_long_bool = false;
				tension_short_bool = false;
				tension_percs_bool = false;
				
			}
			if (audio_ambiant_synth_vol < -50.0f) {
				ambiant_isPlaying = false;
				ambiant_long_bool = false;
			}
		}


		if (ambiant) {

			if (ambiant_long_bool & audio_ambiant_synth_vol < 0.0f){
				audio_ambiant_synth_vol += fadein_speed * Time.deltaTime;
			}
			if (!ambiant_long_bool & audio_ambiant_synth_vol > -80.0f){
				audio_ambiant_synth_vol -= fadein_speed * Time.deltaTime;
			}

			if (audio_ambiant_synth_vol > -50.0f){
				ambiant_isPlaying = true;
			}
			
			if (audio_terror_long_vol > -80.0f | audio_terror_bass_vol > -80.0f| audio_terror_percs_vol > -80.0f| audio_terror_intense_vol > -80.0f| audio_terror_background_vol > -80.0f) {
				audio_terror_long_vol -= fadeout_speed * Time.deltaTime;	
				audio_terror_bass_vol -= fadeout_speed * Time.deltaTime;
				audio_terror_intense_vol -= fadeout_speed * Time.deltaTime;
				audio_terror_background_vol -= fadeout_speed * Time.deltaTime;
			}

			if (audio_terror_long_vol < -50.0f & audio_terror_bass_vol < -50.0f & audio_terror_percs_vol < -50.0f & audio_terror_intense_vol < -50.0f & audio_terror_background_vol < -50.0f) {
				terror_isPlaying = false;
				terror_long_bool = false;
				terror_bass_bool = false;
				terror_intense_bool = false;
				terror_background_bool = false;
				terror_percs_bool = false;
			}
			
			if (audio_tension_long_vol > -80.0f  | audio_tension_short_vol > -80.0f | audio_tension_percs_vol > -80.0f) {
				audio_tension_long_vol -= fadeout_speed * Time.deltaTime;
				audio_tension_short_vol -= fadeout_speed * Time.deltaTime;
				audio_tension_percs_vol -= fadeout_speed * Time.deltaTime;

			}

			if (audio_tension_long_vol < -50.0f  | audio_tension_short_vol < -50.0f | audio_tension_percs_vol < -50.0f) {
				tension_isPlaying = false;
				tension_long_bool = false;
				tension_short_bool = false;
				tension_percs_bool = false;
				
			}
		}
	

		if (tension) {

			if (audio_ambiant_synth_vol > -80.0f) {
				audio_ambiant_synth_vol -= fadeout_speed * Time.deltaTime;	
			}
			if (audio_ambiant_synth_vol < -50.0f) {
				ambiant_isPlaying = false;
				ambiant_long_bool = false;
			}

				if (tension_short_bool & audio_tension_short_vol < 0.0f){
					audio_tension_short_vol += fadein_speed * Time.deltaTime;
				}
				if (!tension_short_bool & audio_tension_short_vol > -80.0f){
					audio_tension_short_vol -= fadeout_speed * Time.deltaTime;
				}
				
				if (tension_percs_bool & audio_tension_percs_vol < 0.0f){
					audio_tension_percs_vol += fadein_speed * Time.deltaTime;
				}
				if (!tension_percs_bool & audio_tension_percs_vol > -80.0f){
					audio_tension_percs_vol -= fadeout_speed * Time.deltaTime;
				}

			if (tension_long_bool & audio_tension_long_vol < 0.0f){
				audio_tension_long_vol += fadein_speed * Time.deltaTime;
			}
			
			if (!tension_long_bool & audio_tension_long_vol > -80.0f){
				audio_tension_long_vol -= fadeout_speed * Time.deltaTime;
			}

			
			if (audio_terror_long_vol > -80.0f | audio_terror_bass_vol > -80.0f| audio_terror_percs_vol > -80.0f| audio_terror_intense_vol > -80.0f| audio_terror_background_vol > -80.0f) {
				audio_terror_long_vol -= fadeout_speed * Time.deltaTime;	
				audio_terror_bass_vol -= fadeout_speed * Time.deltaTime;
				audio_terror_intense_vol -= fadeout_speed * Time.deltaTime;
				audio_terror_background_vol -= fadeout_speed * Time.deltaTime;
			}
			
			if (audio_terror_long_vol < -50.0f & audio_terror_bass_vol < -50.0f & audio_terror_percs_vol < -50.0f & audio_terror_intense_vol < -50.0f & audio_terror_background_vol < -50.0f) {
				terror_isPlaying = false;
				terror_long_bool = false;
				terror_bass_bool = false;
				terror_intense_bool = false;
				terror_background_bool = false;
				terror_percs_bool = false;
			}
			
			if (audio_tension_long_vol > -50.0f  | audio_tension_short_vol > -50.0f | audio_tension_percs_vol > -50.0f) {
				tension_isPlaying = true;
			}
			
		}



		
		
		
		
		if (terror) {
			if (audio_ambiant_synth_vol > -80.0f) {
				audio_ambiant_synth_vol -= fadeout_speed * Time.deltaTime;	
			}
			if (audio_ambiant_synth_vol < -50.0f) {
				ambiant_isPlaying = false;
				ambiant_long_bool = false;
			}

			if (audio_tension_long_vol > -80.0f  | audio_tension_short_vol > -80.0f | audio_tension_percs_vol > -80.0f) {
				audio_tension_long_vol -= fadeout_speed * Time.deltaTime;
				audio_tension_short_vol -= fadeout_speed * Time.deltaTime;
				audio_tension_percs_vol -= fadeout_speed * Time.deltaTime;
				
			}
			
			if (audio_tension_long_vol < -50.0f  & audio_tension_short_vol < -50.0f & audio_tension_percs_vol < -50.0f) {
				tension_isPlaying = false;
				tension_long_bool = false;
				tension_short_bool = false;
				tension_percs_bool = false;
				
			}

			if (terror_long_bool & audio_terror_long_vol < 0.0f){
				audio_terror_long_vol += fadein_speed * Time.deltaTime;
			}
			if (!terror_long_bool & audio_terror_long_vol > -80.0f){
				audio_terror_long_vol -= fadeout_speed * Time.deltaTime;
			}

			if (terror_bass_bool & audio_terror_bass_vol < 0.0f){
				audio_terror_bass_vol += fadein_speed * Time.deltaTime;
			}
			if (!terror_bass_bool & audio_terror_bass_vol > -80.0f){
				audio_terror_bass_vol -= fadeout_speed * Time.deltaTime;
			}
			
			if (terror_intense_bool & audio_terror_intense_vol < 0.0f){
				audio_terror_intense_vol += fadein_speed * Time.deltaTime;
			}
			if (!terror_intense_bool & audio_terror_intense_vol > -80.0f){
				audio_terror_intense_vol -= fadeout_speed * Time.deltaTime;
			}

			if (terror_background_bool & audio_terror_background_vol < 0.0f){
				audio_terror_background_vol += fadein_speed * Time.deltaTime;
			}
			if (!terror_background_bool & audio_terror_background_vol > -80.0f){
				audio_terror_background_vol -= fadeout_speed * Time.deltaTime;
			}

			if (terror_percs_bool & audio_terror_percs_vol < 0.0f){
				if (i == 2|i==4){
					start_terror_percs = true;
					audio_terror_percs_vol = 0.0f;
				}
			}

			if (!terror_percs_bool & audio_terror_percs_vol > -80.0f){
				if (i == 2|i==4){
					end_terror_percs = true;
				}
			}

			if (audio_terror_long_vol > -50.0f  | audio_terror_bass_vol > -50.0f | audio_terror_intense_vol > -50.0f | audio_terror_percs_vol > -50.0f) {
				terror_isPlaying = true;
			}
			
			
		}

	}
	


	
	public void Psycho_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {


			if (ambiant_patch_0_7 == -1){
				random_ambiant_synth = Random.Range (0, AudioArray_ambiant_synth.Length);
			}else{
				random_ambiant_synth = ambiant_patch_0_7;
				//Debug.Log ("Ambiant_patch_8 is  " + ambiant_patch_0_7 + " Random_ambiant_synth is " + random_ambiant_synth);

			}

			if (tension_main_patch_0_15 == -1){
				random_tension_long = Random.Range (0, AudioArray_tension_long.Length);
			}else{
				random_tension_long = tension_main_patch_0_15;
			}

			if (tension_short_patch_0_7 == -1){
				random_tension_short = Random.Range (0, AudioArray_tension_short.Length);
			}else{
				random_tension_short = tension_short_patch_0_7;
			}

			if (tension_percs_0_15 == -1){
				random_tension_percs  = Random.Range (0, AudioArray_ambiant_percs.Length);
			}else{
				random_tension_percs = tension_percs_0_15;
			}

			if (terror_main_patch_0_7 == -1){
				random_terror_long = Random.Range (0, AudioArray_terror_long.Length);
			}else{
				random_terror_long = terror_main_patch_0_7;
			}

			if (terror_bass_0_7 == -1){
				random_terror_bass = Random.Range (0, AudioArray_terror_bass.Length);
			}else{
				random_terror_bass = terror_bass_0_7;
			}	

			if (terror_percs_0_7 == -1){
				random_terror_percs = Random.Range (0, AudioArray_terror_percs.Length);
			}else{
				random_terror_percs = terror_percs_0_7;
			}	

			if (terror_intense_0_7 == -1){
				random_terror_intense = Random.Range (0, AudioArray_terror_intense.Length);

			}else{
				random_terror_intense = terror_intense_0_7;
			}		


			random_hits = Random.Range (0, AudioArray_audio_hits.Length);

			audio_ambiant_synth.clip = AudioArray_ambiant_synth[random_ambiant_synth] as AudioClip;
			
			audio_tension_long.clip = AudioArray_tension_long[random_tension_long] as AudioClip;
			audio_tension_short.clip = AudioArray_tension_short[random_tension_short] as AudioClip;
			audio_tension_percs.clip = AudioArray_ambiant_percs[random_tension_percs] as AudioClip;
			
			audio_terror_long.clip = AudioArray_terror_long[random_terror_long] as AudioClip;
			audio_terror_bass.clip = AudioArray_terror_bass[random_terror_bass] as AudioClip;
			audio_terror_background.clip = AudioArray_tension_long[random_tension_long] as AudioClip;
			audio_terror_percs.clip = AudioArray_terror_percs[random_terror_percs] as AudioClip;
			audio_terror_percs_end.clip = AudioArray_terror_percs_end[random_terror_percs] as AudioClip;
			audio_terror_intense.clip = AudioArray_terror_intense[random_terror_intense] as AudioClip;
			
		}


		if (hits){
			if (i==1 | i == 2| i ==3| i == 4){
				if (time + 1.0F > singleMeasureTime) {
					random_hits = Random.Range (0, AudioArray_audio_hits.Length);
					audio_hits.clip = AudioArray_audio_hits[random_hits] as AudioClip;

					audio_hits.PlayScheduled (time);		
					hits = false;
				}
			}
		}

		if (i == 1) {
			if (time + 1.0F > singleMeasureTime) {

						audio_ambiant_synth.PlayScheduled (time);
						audio_tension_long.PlayScheduled (time);
						audio_tension_short.PlayScheduled (time);
						audio_tension_percs.PlayScheduled (time);
						audio_terror_long.PlayScheduled (time);
						audio_terror_bass.PlayScheduled (time);
						audio_terror_intense.PlayScheduled (time);
						audio_terror_background.PlayScheduled(time);
				audio_ambiant_synth.volume = 1.0f;
				
				audio_tension_long.volume = 1.0f;
				audio_tension_short.volume = 1.0f;
				audio_tension_percs.volume = 0.5f;
				
				audio_terror_long.volume = 1.0f;
				audio_terror_bass.volume = 1.0f;
				audio_terror_background.volume = 1.0f;
				audio_terror_percs.volume = 1.0f;
				audio_terror_intense.volume = 1.0f;
					}
					
				}
			
		if (i == 2|i==4) {
			if (time + 1.0F > singleMeasureTime) {
				
				if (end_terror_percs){
					audio_terror_percs_end.PlayScheduled (time);
					end_terror_percs = false;
					audio_terror_percs_vol = -80.0f;
					audio_terror_percs.Stop();
					terror_percs_bool = false;
					if (reset){
						i = 0;
						reset = false;
						start = false;
						running = false;
						first_run = false;
						tension = false;
						terror = false;
						ambiant = false;
						tension_long_bool = false;
					}
				}
				if (start_terror_percs){
					audio_terror_percs_vol = 0.0f;
					audio_terror_percs.PlayScheduled (time);
					start_terror_percs = false;
				}
				
			}
		}
		if (i == 4) {
			i =2;
		}
	
		if (reset){
			if (terror_percs_bool & audio_terror_percs_vol > -80.0f) {
				end_terror_percs = true;
			}else{
				tension = false;
				terror = false;
				ambiant = false;
				tension_long_bool = false;
				reset_pause -= Time.deltaTime;
				if (reset_pause < 0 )
					{	i = 0;
						reset = false;
						start = false;
						running = false;
						first_run = false;
						reset_pause = 2.0f;

					}
			}



		}


		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
				i +=1;
			y += 1;
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			if (use_triggers){
				CheckDistanceToTrigger ();
			}


		}

	}

	void CheckDistanceToTrigger(){

		//If the GameObject exists, assigns the game object of the name .Find ("NameOfGameObject) to a Transform (created in the private declarations above
		//Measures the distance between that GameObject and the Player and includes it in a float variable
		try{
			enemy_bunny0 = GameObject.Find ("ZomBunny0").transform;
			bunny0 = Vector3.Distance(Player.position, enemy_bunny0.position);
		}catch{
			//do nothing
		}try{
			enemy_bunny1 = GameObject.Find ("ZomBunny1").transform;
			bunny1 = Vector3.Distance(Player.position, enemy_bunny1.position);

		}catch{
			//do nothing
		}try{
			enemy_bunny2 = GameObject.Find ("ZomBunny2").transform;
			bunny2 = Vector3.Distance(Player.position, enemy_bunny2.position);

		}catch{
			//do nothing
		}try{
			enemy_bunny3 = GameObject.Find ("ZomBunny3").transform;
			bunny3 = Vector3.Distance(Player.position, enemy_bunny3.position);

		}catch{
			//do nothing
		}try{
			enemy_bunny4 = GameObject.Find ("ZomBunny4").transform;
			bunny4 = Vector3.Distance(Player.position, enemy_bunny4.position);

		}catch{
			//do nothing
		}try{
			enemy_bear0 = GameObject.Find ("ZomBear0").transform;
			bear0 = Vector3.Distance(Player.position, enemy_bear0.position);

		}catch{
			//do nothing
		}try{
			enemy_bear1 = GameObject.Find ("ZomBear1").transform;
			bear1 = Vector3.Distance(Player.position, enemy_bear1.position);

		}catch{
			//do nothing
		}try{
			enemy_bear2 = GameObject.Find ("ZomBear2").transform;
			bear2 = Vector3.Distance(Player.position, enemy_bear2.position);

		}catch{
			//do nothing
		}try{
			enemy_bear3 = GameObject.Find ("ZomBear3").transform;
		bear3 = Vector3.Distance(Player.position, enemy_bear3.position);

		}catch{
			//do nothing
		}try{
			enemy_bear4 = GameObject.Find ("ZomBear4").transform;
			bear4 = Vector3.Distance(Player.position, enemy_bear4.position);

		}catch{
			//do nothing
		}try{
			enemy_helle0 = GameObject.Find ("Hellephant0").transform;
			helle0 = Vector3.Distance(Player.position, enemy_helle0.position);

		}catch{
			//do nothing
		}try{
			enemy_helle1 = GameObject.Find ("Hellephant1").transform;	
			helle1 = Vector3.Distance(Player.position, enemy_helle1.position);

		}catch{
			//do nothing
		}try{
			enemy_helle2 = GameObject.Find ("Hellephant2").transform;	
			helle2 = Vector3.Distance(Player.position, enemy_helle2.position);

		}catch{
			//do nothing
		}try{
			enemy_helle3 = GameObject.Find ("Hellephant3").transform;
			helle3 = Vector3.Distance(Player.position, enemy_helle3.position);

		}catch{
			//do nothing
		}try{
			enemy_helle4 = GameObject.Find ("Hellephant4").transform;
			helle4 = Vector3.Distance(Player.position, enemy_helle4.position);

		}catch{
			//do nothing
		}
		
		//If the distance float is equal to 0 (it has not been initialized) or if the GameObject has been destroyed or doesn't exist yet, 
		//it assigns a very high default value to the "distance" float to avoid it to trigger in game events.
		if (bunny0 == 0 | enemy_bunny0 == null) {
			bunny0 = 5000;
		}
		if (bunny1 == 0 | enemy_bunny1 == null) {
			bunny1 = 5000;
		}
		if (bunny2 == 0 | enemy_bunny2 == null) {
			bunny2 = 5000;
		}
		if (bunny3 == 0 | enemy_bunny3 == null) {
			bunny3 = 5000;
		}
		if (bunny4 == 0 | enemy_bunny4 == null) {
			bunny4 = 5000;
		}
		//Sets up a float array that groups all the distances from GameObjects to the player and it sorts it by size so that the closest GameObject is stored in a "nearest_enemy" float.
		float[] distance_to_bunny = {bunny0 ,
			bunny1,
			bunny2,
			bunny3 ,
			bunny4};
		System.Array.Sort(distance_to_bunny);
		nearest_bunny = distance_to_bunny[0];


		if (helle0 == 0 | enemy_helle0 == null) {
			helle0 = 5000;
		}
		if (helle1 == 0 | enemy_helle1 == null) {
			helle1 = 5000;
		}
		if (helle2 == 0 | enemy_helle2 == null) {
			helle2 = 5000;
		}
		if (helle3 == 0 | enemy_helle3 == null) {
			helle3 = 5000;
		}
		if (helle4 == 0 | enemy_helle4 == null) {
			helle4 = 5000;
		}
		
		float[] distance_to_helle = {helle0 ,
			helle1,
			helle2,
			helle3 ,
			helle4};
		System.Array.Sort(distance_to_helle);
		nearest_helle = distance_to_helle[0];

		if (bear0 == 0 | enemy_bear0 == null) {
			bear0 = 5000;
		}
		if (bear1 == 0 | enemy_bear1 == null) {
			bear1 = 5000;
		}
		if (bear2 == 0 | enemy_bear2 == null) {
			bear2 = 5000;
		}
		if (bear3 == 0 | enemy_bear3 == null) {
			bear3 = 5000;
		}
		if (bear4 == 0 | enemy_bear4 == null) {
			bear4 = 5000;
		}
		
		float[] distance_to_bear = {bear0 ,
			bear1,
			bear2,
			bear3 ,
			bear4};
		System.Array.Sort(distance_to_bear);
		nearest_bear = distance_to_bear[0];

	}
	
		


	void SetMood (){

		
		//Sets up the final float variables for determining the mood
		//The Ambiant and Tension_mood_A are triggered based on a fixed GameObject (like a room or a specific place)
		//The Tension_mood_B, Terror_mood_A and Terror_mood_B are triggered based on the type of enemy approaching.
		//You can create an unlimited number of other moods, for instance, only playing the percussion loop, or only the terror_synth loop 
		//based on your preference and custom triggers, based on the models provided below.
		Ambiant_mood = Vector3.Distance(Player.position, Ambiant_trigger.position);
		Tension_mood_A = Vector3.Distance(Player.position, Ambiant_trigger.position);
		Tension_mood_B = nearest_bunny;
		Terror_mood_A = nearest_bear;
		Terror_mood_B = nearest_helle;

		//These set of "if" statements check for whether the enemies are within the range of the trigger and enable a boolean which will serve to determine the mood.
		
		if (Tension_mood_B < trigger_sensitivity & nearest_bunny != 0) {
			bunny_trigger = true;
		}
		if (Tension_mood_B > trigger_sensitivity & nearest_bunny != 0) {
			bunny_trigger = false;
		}
		if (Terror_mood_A < trigger_sensitivity & nearest_bear != 0) {
			bear_trigger = true;
		}
		if (Terror_mood_A > trigger_sensitivity & nearest_bear != 0) {
			bear_trigger = false;
		}
		if (Terror_mood_B < trigger_sensitivity & nearest_helle != 0) {
			helle_trigger = true;
		}
		if (Terror_mood_B > trigger_sensitivity & nearest_helle != 0) {
			helle_trigger = false;
		}
		
		//these "if" statements set the mood according to a combination of booleans and conditions.
		//In the code, be sure to include "priorities", meaning, that two situations cannot be "true" at the same time.

		if (Ambiant_mood < trigger_sensitivity & !bunny_trigger & !bear_trigger & !helle_trigger) {
			if (!start) {
				start = true;
			}
			//The line of code below allows for setting a delay between the time when the last enemy is killed and the mood changes back to
			//a "soft" ambiance mood in order to avoid abrupt changes everytime a game situation changes.
			reset_time -= Time.deltaTime;
			if ( reset_time < 0 )
			{
				ambiant = true;
				ambiant_long_bool = true;
				tension_percs_bool = false;
				tension_short_bool = false;
				tension_long_bool = false;
				terror_background_bool = false;
				terror_long_bool = false;
				terror_bass_bool = false;
				terror_intense_bool = false;
				terror_percs_bool = false;
				tension = false;
				terror = false;
			}
		}
		
		if (Ambiant_mood > trigger_sensitivity & !bunny_trigger & !bear_trigger & !helle_trigger) {
			if (!start) {
				start = true;
			}
			reset_time -= Time.deltaTime;
			if ( reset_time < 0 )
			{
				ambiant = false;
				ambiant_long_bool = false;
				tension_long_bool = true;
				tension_percs_bool = false;
				tension_short_bool = false;
				terror_background_bool = false;
				terror_long_bool = false;
				terror_bass_bool = false;
				terror_intense_bool = false;
				terror_percs_bool = false;
				tension = false;
				terror = false;
			}
		}

		if (bunny_trigger & !bear_trigger & !helle_trigger) {
			if (!start) {
				start = true;
			}
			reset_time = reset_timer;
			ambiant = false;
			ambiant_long_bool = false;
			tension_long_bool = true;
			tension_percs_bool = true;
			tension_short_bool = true;
			terror_background_bool = false;
			terror_long_bool = false;
			terror_bass_bool = false;
			terror_intense_bool = false;
			terror_percs_bool = false;
			tension = false;
			terror = false;
		}

		if (bear_trigger & !helle_trigger) {
			if (!start) {
				start = true;
			}
			reset_time = reset_timer;
			ambiant = false;
			ambiant_long_bool = false;
			tension_long_bool = false;
			tension_percs_bool = false;
			tension_short_bool = false;
			terror_background_bool = true;
			terror_long_bool = true;
			terror_bass_bool = true;
			terror_intense_bool = false;
			terror_percs_bool = false;
			tension = false;
			terror = true;
		}

		if (helle_trigger) {
			if (!start) {
				start = true;
			}
			reset_time = reset_timer;
			ambiant = false;
			ambiant_long_bool = false;
			tension_long_bool = false;
			tension_percs_bool = false;
			tension_short_bool = false;
			terror_background_bool = true;
			terror_long_bool = true;
			terror_bass_bool = true;
			terror_intense_bool = true;
			terror_percs_bool = true;
			tension = false;
			terror = true;
		}


	}

	public void Ambiant_onClick(){
		if (!start) {
			start = true;
		}
		//The line of code below allows for setting a delay between the time when the last enemy is killed and the mood changes back to
		//a "soft" ambiance mood in order to avoid abrupt changes everytime a game situation changes.
		reset_time -= Time.deltaTime;
		if ( reset_time < 0 )
		{
			ambiant = true;
			ambiant_long_bool = true;
			tension_percs_bool = false;
			tension_short_bool = false;
			tension_long_bool = false;
			terror_background_bool = false;
			terror_long_bool = false;
			terror_bass_bool = false;
			terror_intense_bool = false;
			terror_percs_bool = false;
			tension = false;
			terror = false;
		}

	}



	public void Tension_Basic_onClick() {
		if (!start) {
			start = true;
		}
		reset_time -= Time.deltaTime;
		if ( reset_time < 0 )
		{
			ambiant = false;
			ambiant_long_bool = false;
			tension_long_bool = true;
			tension_percs_bool = false;
			tension_short_bool = false;
			terror_background_bool = false;
			terror_long_bool = false;
			terror_bass_bool = false;
			terror_intense_bool = false;
			terror_percs_bool = false;
			tension = false;
			terror = false;
		}
	}

	public void Tension_Synth_onClick () {
		if (!start) {
			start = true;
		}
		ambiant = false;
		ambiant_long_bool = false;
		tension_short_bool = true;
		terror_background_bool = false;
		terror_long_bool = false;
		terror_bass_bool = false;
		terror_intense_bool = false;
		terror_percs_bool = false;
		tension = false;
		terror = false;
	}

	public void Tension_Percs_onClick() {
		if (!start) {
			start = true;
		}
			ambiant = false;
			ambiant_long_bool = false;
			tension_percs_bool = true;
			terror_background_bool = false;
			terror_long_bool = false;
			terror_bass_bool = false;
			terror_intense_bool = false;
			terror_percs_bool = false;
			tension = false;
			terror = false;
	}

	public void Terror_Basic_onClick() {
		if (!start) {
			start = true;
		}
		ambiant = false;
		ambiant_long_bool = false;
		tension_long_bool = false;
		tension_percs_bool = false;
		tension_short_bool = false;
		terror_background_bool = true;
		terror_long_bool = true;
		terror_bass_bool = false;
		terror_intense_bool = false;
		terror_percs_bool = false;
		tension = false;
		terror = true;
	}

	public void Terror_Bass_onClick() {
		if (!start) {
			start = true;
		}
		ambiant = false;
		ambiant_long_bool = false;
		tension_long_bool = false;
		tension_percs_bool = false;
		tension_short_bool = false;
		terror_bass_bool = true;
		tension = false;
		terror = true;
	}

	public void Terror_Intense_onClick() {
		if (!start) {
			start = true;
		}
		ambiant = false;
		ambiant_long_bool = false;
		tension_long_bool = false;
		tension_percs_bool = false;
		terror_intense_bool = true;
		tension = false;
		terror = true;
	}

	public void Hits_onClick() {
		hits = true;
	}

	public void Terror_Percs_onClick() {
		if (!start) {
			start = true;
		}
		ambiant = false;
		ambiant_long_bool = false;
		tension_long_bool = false;
		tension_percs_bool = false;
		tension_short_bool = false;
		terror_percs_bool = true;
		tension = false;
		terror = true;
	}

	public void Stop_Horror_onClick() {
		reset = true;
		ambiant = false;
		ambiant_long_bool = false;
		tension_long_bool = false;
		tension_percs_bool = false;
		tension_short_bool = false;
		terror_background_bool = false;
		terror_long_bool = false;
		terror_bass_bool = false;
		terror_intense_bool = false;
		terror_percs_bool = false;
		tension = false;
		terror = false;
	}



}