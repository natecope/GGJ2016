using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Manages all audio for the game.
 */
public class AudioManager : MonoBehaviour {

	//----------------------------------------------------------------------------------------------
	// Members
	//----------------------------------------------------------------------------------------------

	// Enumeration for music tracks. Used to identify which music to play.
	public enum MusicTrack {
		None,
		MenuTheme,
		MainTheme,
		Victory,
		Failure
	};

	public bool gameNoisesActive = false;
	public MusicTrack initialMusicTrack;

	// Unity Objects and Components
	//----------------------------------------------------------------------------------------------

	// Music.
	public AudioSource music_menuTheme;
	public AudioSource music_mainTheme;
	public AudioSource music_victory;
	public AudioSource music_failure;

	// Sound effects.
	public List<AudioSource> sfx_playerNoises;
	public List<AudioSource> sfx_birdNoises;
	public List<AudioSource> sfx_mugBumps;
	public AudioSource sfx_pour;
	public AudioSource sfx_toasterLever;
	public AudioSource sfx_toasterPop;

	// Private Members
	//----------------------------------------------------------------------------------------------

	private const float PLAYER_NOISE_INTERVAL_MIN = 5f;
	private const float PLAYER_NOISE_INTERVAL_MAX = 10f;
	private const float BIRD_NOISE_INTERVAL_MIN = 7f;
	private const float BIRD_NOISE_INTERVAL_MAX = 15f;

	private float playerNoiseTimer;
	private float birdNoiseTimer;

	//----------------------------------------------------------------------------------------------
	// METHODS
	//----------------------------------------------------------------------------------------------

	// MonoBehaviour Methods
	//----------------------------------------------------------------------------------------------

	public void Awake() {

		ResetPlayerNoiseTimer();
		ResetBirdNoiseTimer();
		PlayMusic(initialMusicTrack);
	}
	
	public void Update() {

		if (gameNoisesActive) {
			// Play a random player noise at random intervals.
			playerNoiseTimer -= Time.deltaTime;
			if (playerNoiseTimer <= 0f) {
				sfx_playerNoises[Random.Range(0, sfx_playerNoises.Count)].Play();
				ResetPlayerNoiseTimer();
			}

			// Play a random bird noise at random intervals.
			birdNoiseTimer -= Time.deltaTime;
			if (birdNoiseTimer <= 0f) {
				sfx_birdNoises[Random.Range(0, sfx_birdNoises.Count)].Play();
				ResetBirdNoiseTimer();
			}
		}
	}

	// Private Methods
	//----------------------------------------------------------------------------------------------

	private void ResetPlayerNoiseTimer() {
		playerNoiseTimer = Random.Range(PLAYER_NOISE_INTERVAL_MIN, PLAYER_NOISE_INTERVAL_MAX);
	}

	private void ResetBirdNoiseTimer() {
		birdNoiseTimer = Random.Range(BIRD_NOISE_INTERVAL_MIN, BIRD_NOISE_INTERVAL_MAX);
	}

	// Public Methods
	//----------------------------------------------------------------------------------------------

	// Set the automatic game noises on or off. This includes player noises and bird noises.
	public void SetGameNoisesActive(bool gameNoisesActive) {
		this.gameNoisesActive = gameNoisesActive;
	}

	// Plays the given music track, turning off all other music tracks.
	public void PlayMusic(MusicTrack musicTrack) {

		// Stop all currently playing music.
		music_menuTheme.Stop();
		music_mainTheme.Stop();
		music_victory.Stop();
		music_failure.Stop();

		// Play the requested track.
		switch (musicTrack) {
			case MusicTrack.MenuTheme: music_menuTheme.Play(); break;
			case MusicTrack.MainTheme: music_mainTheme.Play(); break;
			case MusicTrack.Victory: music_victory.Play(); break;
			case MusicTrack.Failure: music_failure.Play(); break;
			default: break;
		}
	}

	public void PlayMugBump() {
		sfx_mugBumps[Random.Range(0, sfx_mugBumps.Count)].Play();
	}

	public void PlayPour() {
		sfx_pour.Play();
	}

	public void PlayToasterLever() {
		sfx_toasterLever.Play();
	}

	public void PlayToasterPop() {
		sfx_toasterPop.Play();
	}
}
