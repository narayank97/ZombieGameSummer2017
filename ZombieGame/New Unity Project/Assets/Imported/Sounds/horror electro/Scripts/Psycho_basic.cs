using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Psycho_basic : MonoBehaviour {

		
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

	private int ambiant_patch_0_7;

	private int tension_main_patch_0_15;
	private int tension_short_patch_0_7;
	private int tension_percs_0_15;

	private int terror_main_patch_0_7;
	private int terror_bass_0_7;
	private int terror_percs_0_7;
	private int terror_intense_0_7;

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

	public bool hits;

	private bool ambiant_isPlaying;
	private bool tension_isPlaying;
	private bool terror_isPlaying;
	public bool start = false;

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
	
	// Update is called once per frame
	void Update () {

		if (start) {
			Psycho_Play ();

			if (!first_run){
				singleMeasureTime = AudioSettings.dspTime + 2.0F;
				running = true;
			}
			first_run = true;
		}	



	}
	


	
	public void Psycho_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
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
			
			audio_hits.clip = AudioArray_audio_hits[random_hits] as AudioClip;
		}


		if (hits){
			if (i==1 | i == 2| i ==3| i == 4){
				if (time + 1.0F > singleMeasureTime) {
					
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
				audio_terror_percs.PlayScheduled (time);
						
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
			

		if (i == 4) {
			i =2;
		}

		
		if (reset){
				i = 0;
				reset = false;
				start = false;
				running = false;
				first_run = false;
				


			audio_ambiant_synth.Stop ();
			audio_tension_long.Stop ();
			audio_tension_short.Stop ();
			audio_tension_percs.Stop ();
			audio_terror_long.Stop ();
			audio_terror_bass.Stop ();
			audio_terror_intense.Stop ();
			audio_terror_background.Stop ();
			audio_terror_percs.Stop ();


		}
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime & start) {
			Debug.Log ("The i int equals  " + i);
				i +=1;
			y += 1;
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;

		}

		
		
		
	}


	public void Reset_OnClick(){
		reset = true;
	}

}