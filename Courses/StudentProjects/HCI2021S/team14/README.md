# Spoon-School

## Experiential Solar System Education Using Projection Mapping for Lower Grade Students </br>
### Members
이대성 이성원 이유리 임도전 정수현
</br></br>
***
## *1. Background*
***
### 1-1. Background
It has undergone many changes as the education content market has shifted from offline to online-oriented. However, most of the educational contents are still cramming education based on unilateral information transfer and does not have a positive impact on improving user's learning immersion. </br>
</br>
This one-sided cramming education suppresses children's diverse thinking, resulting in a constant and uniform mindset. This method of education, which has only the purpose of knowledge transfer, does not induce one to think for oneself, further degrades individual development of competence and interest in education.</br>
</br>
We will use interactive media to allow children to interact with programs (content) and learn about solar planets with interests. Interactive media provides a greater sense of how each planet is located and rotates apart from the sun. And it allows children to learn about each planet directly by interacting with the media which allows children to have fun while learning. </br>
</br>
### 1-2. Goal</br>

We will create a planetary education program that interacts with users by using beam projector and interaction objects like sticks which are attaching Aruco markers. </br>
</br>
It implements a moving orbit of a planet in the solar system, and when a user places a stick with an Aruco marker and touches one of the planets with it, it can be moved to provide information about that planet. At this time, standing by the user covered various places, you can watch the movement of planets in orbit.</br>
</br>
We want to implement a simulation using OpenCV for Aruco marker detector and OpenGL for graphic tool. This will require a little study, but it does not require high-level work because it does not implement complex models with artificial planets graphics, but rather the movement of planets. And we also need a way to connect to the webcam for the Aruco marker tracking and projector equipment to the computer.</br>
</br>
### 1-3. Target</br>
Lower grade students and any other student who wants leaning about Solar system 
</br></br>
***
## *2. Final Output*
***
### 2-1. Device
Webcam </br>
Beam Projector

### 2-2. Artifacts
Aruco Stick (we named it Spoon)

### 2-3. Final Output

</br></br>
***
## *3. Step by step tutorial*
***
### 3-1. Setting
#### 3-1-1. Install OpenCV
Install Homebrew (if you don’t have)
```
 /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)
```

Install Opencv
```
brew install opencv
```

</br></br>
#### 3-1-2. Install OpenGL
Install glfw3
```
brew install glfw3
```
Install glew
```
brew install glew
```
Install assimp
```
brew install assimp
```
</br></br>
#### 3-1-3. install our source code
https://github.com/keynekassapa13/solar-system

</br></br>
### 3-2. how to play
#### 3-2-1. Splash Screen
The program starts when a user brings aruco marker to the Sun
![spoon_school](/img/splashScreen.png)

#### 3-2-2. Main Screen
The solar system keeps rotating around the Sun and an object is tracking the aruco marker
![spoon_school](/img/mainScreen.png)

#### 3-2-3. Selecting a Planet
A description of a planet appears when the user object approaches the planet
![spoon_school](/img/descriptionScreen1.png)
![spoon_school](/img/descriptionScreen2.png)

#### 3-2-4. Game Mode
The Game Mode starts when a button (number 6) is pressed. The planets rotate faster and the user object should reach the Sun without crushing with other planets.
![spoon_school](/img/gameModeLost.png)
![spoon_school](/img/gameModeWin.png)


</br></br>
***
## *4. Limitation*
***
1. The program could not detect the aruco code if there is a projection object on the aruco code
</br></br>
2. The webcam sometimes gets out of focus resulting not being able to detect the aruco code
</br></br>
3. The current version 1.0 only supports 1 player mode
</br></br>

***
## *5. Future Plan*
***
The core of the project was to get the coordinate system and let the user move directly. If we are able to develop the project in the future, we could add more diverse effects and interactions. It would be nice to conduct user motion interactions in a three-dimensional manner to match the name Spoon School. Previously, there was a plan to develop the project into a game, and the possibility seems sufficient as the users had fun during the user test and required more interactions for hedonic purposes.

1. Updating various effects with human interactions. 
2. Modify code to increase readability of code.
3. And we will add information about the Sun like another planet.  
4. Increase Arcomarker Recognition.
5. Speed up image processing. 

</br></br>
***
## Reference
***
```solar system <https://github.com/keynekassapa13/solar-system>```
```aruco detection <https://docs.opencv.org/master/d5/dae/tutorial_aruco_detection.html>```


