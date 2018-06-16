using System.Collections;
using UnityEngine;

namespace S3
{
public class GameManager_References : MonoBehaviour {

    public string playerTag;
    public static string _playerTag;
    public string enemyTag;
    public static string _enemyTag;
    public static GameObject _player;
    
        // Use this for initialization
    void OnEnable ()
    {
		if(playerTag == "" || enemyTag== "")
        {
            Debug.LogWarning("Please type in a player/enemy tag in the GM_References");
        }
            _playerTag = playerTag;
            _enemyTag = enemyTag;

            _player = GameObject.FindGameObjectWithTag(_playerTag);
	}
	
	// Update is called once per frame
	void OnDisable() {
		
	}
}
}

