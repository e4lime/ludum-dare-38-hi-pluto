# Hi Pluto! #
Ludum dare 38. Theme: "A Small World"

Game page: https://ldjam.com/events/ludum-dare/38/hi-pluto

## Summary ##
"Hi Pluto!" is a classic infinite vertical jumping game where you play 
as Earth jumping upwards on asteroids to reach Pluto. Control Earth's 
horizontal movement with your mouse and aim for the asteroids and the 
golden comet checkpoints while you avoiddropping out of the screen.
                    
Uses Unity 5.6.0. with DoTween and Unity Analytics.  
Graphics were made with Blender and Krita.

### GDD ###
![Early design](skiss_1.png)

#### Story
Your second best friend (after the moon...) Pluto! Have been feeling down for a while cause NASA 
told hin he ain't a planet no more :( But there are rumours NASA will change their mind and 
classify Pluto as a planet once again! Go pay your old friend a visit and bring him the 
great news! :D   

Use the mouse to climb the astroids until you reach Pluto.
Hit comets on to create checkpoints. If you fall down you will die and respawn at the last checkpoint.

Keys  
Mouse movement: Moves earth   
Space: Pause game   

##### Stuff/Legend
[x] Earth (Player)    
[x] Planets (Checkpoints)   
	[x] Earth    
	[x] Mars   
	[x] Jupiter   
	[x] Saturnus  
	[x] Uranus    
	[x] Neptunus   
	[x] Pluto   
[x] JumpObject (stars/astroids/comets or w/e)   
[x] Sounds    
[X] Bumping on stars   
[ x] Falling down

##### Mechanics
[X] World Earth autojumps on stars/astroids/comets etc (pick one)   
[X] Control earth with mousemovement (try keys later if it feels bad)   
[x] Gain 1 point for each JumpObject   
[-] Planets are checkpoints     
[x] Respawn on checkpoint    
[x] Screen scroll ups with planet, smooth    
[x] Horizontal view or Vertical view

#####If time
[-] Planets   
	[-] Sun    
	[-] Mercury   
	[-] Venus    
	[-] Astroidbelt (between mars and Jupiter)    
[-] Keep falling until a planet saves you (instead of spawning at checkpoint)   
[-] Fall down past sun and slung around to gain momentum at start (instead of going to mars directly)    
[-] Something to avoid, like dangerous astroids  
[-] Give planets personality (make them say fun things when passing buy, give them 2d smileys/faces)
[-] music (Forgot to setup ableton with komplete, gonna take a while)    

### IMPORTANT Checklist ###

### Per User ###
[x] (OPTIONAL) Move content in "GameEngine Data" to your Unity installation to override default C# script
#### Beginning ####
[x] Fork this project    
[x] Set Company name in "Project Settings > Player Settings" to team name   
[x] Set Product name in "Project Settings > Player Settings" to project name   
[x] Decide folder structure (!_Game_ByAssetType vs !_Game_ByEntity) by renaming to !_Game and deleting the unwanted     
[x] Change name on the project folder: "unity-template-project-name"

#### Before Final build ####
[ ] Backup project  
[ ] Set final Company name in "Project Settings > Player Settings"    
[ ] Set final Product name in "Project Settings > Player Settings"    
[ ] Remove paid tools   
[ ] Remove placeholders   
[ ] Bake lightning 

--------

##Thirdparty Libraries and tools##
Resides in the Unity Project folder   

###DOTween###
Animation/Tween library.  
Free   
https://www.assetstore.unity3d.com/en/#!/content/27676  

* Demigiant/DOTween
* Resources/DOTweenSettings.asset

