HORROR ELECTRO MUSIC PACK (FREE): SETUP GUIDE

Dear Unity Developer,
Thank you for downloading this package and supporting my work!

Here are some indications as to how to use this pack.

********************************************************************************************************************************************************************************************************
GENERAL REMARKS:

- DO NOT, under any circumstance, change the folder structure of the "Resources" folder.  The resources folder HAS to be located in your asset folder and the folder structure HAS to remain untouched.
  The reason is that many scrips rely on this folder structure to load the samples into arrays. Many scripts could stop working if you change the folder structure.

- Be sure to add an audio listener to your camera or the game object you attach the script on.  Apparently, this helps with the overall performance of the script.

*********************************************************************************************************************************************************************************************************

How to use the "drag and drop" HorrorPrefab:
--------------------------------------------

The "HorrorPrefab" is located in the Prefabs folder.
Simply drag and drop it into your scene, reposition, resize, duplicate the triggers as necessary.
Test it in your game, then deactivate the mesh renderer and you are all set!

The color codes are as follows:

Light Yellow: Sets the "main" mood to Ambiant (no action, soothing ambiant loop).
Light Orange: Sets the "main" mood to Tension (the main "tension" loop).
Red: Sets the "main" mood to Terror (the main "terror" loop).

CAREFUL: These three triggers are the MOST important.  Always start with these when switching from one mood to another.
HOWEVER, these BASIC mood sets also DISABLE any "additional" layers such as percussion or other synth loops so make sure the player walks through them only ONCE and you can destroy them if need be.

The colors below will ADD additional layers to the basic moods (percussion, synths etc)

Brown: Adds percussion to the "tension" mood
Green: Adds synths to the "tension" mood
Dark Pink: Adds bass to the "terror" mood
Light Pink: Adds stressful percussion effects to the "terror" mood
Pink: Adds the main percussion to the "terror" mood

TO STOP ANY OF THESE ADDITIONAL LAYERS, THE PLAYER WILL NEED TO WALK THROUGH THE "BASIC" TRIGGERS ABOVE.

Dark Purple: Plays a "HIT" at the next measure. (If you want to punctuate the mood with a "hit" sound at a specific time in the game, include this trigger and a "hit" sound will play each time the player walks through the trigger.
Light Purple: Stops all the music.


How to use the Psycho_master script with the triggers linked to gameObjects:
----------------------------------------------------------------------------

The Psycho_master script is inside the "Scripts" folder.
All you need to do is to drag and drop the script on a game object with an audio listener component.  
Drag/drop the "psycho_mixer" mixer into the corresponding box in the "Psycho_master" script.

BE SURE TO CHECK THE "USE TRIGGER" BOOLEAN.

Upon attaching the script to a game object, you will see several checkboxes which are public booleans that activate or deactivate the playback of the different samples.

So in your game, whenever you want to activate one of the sample loops (linked to a specific event, trigger...) 
simply access the booleans
 listed inside the script and set one of them to "true".

With the updated version, you can also use the methods included in the "Psycho_master" script to quickly set up the script inside your game.
The two "methods" added in the script are the "CheckDistanceToTrigger" method and the "SetMood" method.

The "CheckDistanceToTrigger" method evaluates the distance between the Player and a set number of GameObjects inside your scene (enemies, empty game objects...)
In this case, the script shows how to deal with multiple types of ennemies spawned at random (which is more complex than dealing with pre-existing GameObject that you can easily assign to a Transform 
either programmatically or by dragging/dropping the GameObject in the public variable cell in the inspector)

The "SetMood" method is responsible for checking whether the conditions are met to set a certain mood.  For instance, for the "Ambiant" or "soft" mood, whether there are no enemies present and whether the Player
is close enough to a "safe" zone inside the scene.

To further help you in writing the script, there is an example of the code used to assign unique names to instantiated/spawned GameObjects in the "code_snippet_script".

Upon setting the "reset" boolean to "true", the samples will finish playing and will be assigned new ones randomly.
The script will automatically wait for 2 seconds after the "reset" button was pressed before playing new samples.
If you set "reset" to "true" inside the game during heavy action, the sound will fade out, but will immediately start again with the level of intensity determined by the game with a fresh combination of samples.

Not all samples use fade in/out.  The Terror percussion loop starts and stops playing at the beginning of a measure so that it is always in tempo.
It also stops after the loop is finished.  

The "hits" boolean plays a "hit" sample which can be used for dramatic effect.  It will be played at the start of each measure and only once.
If you want to play it several times, make sure you set it to "true" several times as it resets itself automatically.

_____________________________________________________________________________________________________


The "Psycho_basic" script is essentially a stripped down version of the "Psycho_master" script.
It allows you to get full control over the mixer and transitions if you want to handle them yourself.
Activate the "start" boolean when you want the sound to start (don't forget to pull down all the mixer tracks or everything will start playing at once!).
Activate the "reset" boolean if you want to stop everything and reassign a fresh combination of samples randomly (make sure all mixer tracks are 
pulled down or the sound will end abruptly).
Activate the "hit" boolean if you want to play a "hit" sample at the beginning of a measure.

-------------------------------------------------------------------------------------------------------------------------
IMPORTANT THINGS TO REMEMBER:

- Make sure only ONE boolean is set to "true" at all times, otherwise the script may not function properly!
- The "Psycho_demo" script is used in the "Psycho Demo" scene in the "Scenes" folder.  You can play with it by running the scene, but it is not usable directly for your game.

-------------------------------------------------------------------------------------------------------------------------

I hope you'll be able to make use of this!
Don't forget to leave a review and suggestions/ideas for how to make this work even better!

Thanks again for your support and don't hesitate to contact me if you have any questions/suggestions! 

sincerely,

Marma

CONTACT: marma.developer@gmail.com
WEBSITE: http://www.marmamusic.com