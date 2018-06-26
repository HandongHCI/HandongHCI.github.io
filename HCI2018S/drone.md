[← go back to the list](https://HandongHCI.github.io/HCI2018S)

# Drone Team

<img src="files/DJI Tello.jpg" height="200"><img src="files/Leap Motion.jpg" height="200">

#### Members
- 김한설, 임승찬, 김시은, 김하준, 황인성, Dennis Phalula

#### Agenda
- Tello & Leap Motion using Scratch
- Tello & Leap Motion using Gobot library

<br><br><br>
## Part A. Tello & Leap Motion using Scratch
### DJI Tello in Scratch 
1. Install <a href="https://scratch.mit.edu/download" target="_blank">Scratch 2.0 Offline Editor</a>
2. Install <a href="https://nodejs.org/en/" target="_blank">node.js</a>
3. Install <a href="https://get.adobe.com/air/" target="_blank">Adobe AIR</a> if needed
4. Download [Tello.js and Tello.s2e](https://dl-cdn.ryzerobotics.com/downloads/tello/20180222/Scratch.zip)
5. Open the terminal and go to the file directory where you saved the _Tello.js_ and _Tello.s2e_ files and type `node Tello.js`
6. Open Scratch 2.0 Offline, hold __Shift__ key, click __File__ menu, click __Import Experimental HTTP Extension__, and select _Tello.s2e_ file
7. The Tello interface will be shown in Scratch under __More Blocks__
* Read [https://www.heliguy.com/blog/2018/04/18/coding-with-the-ryze-tello/](https://www.heliguy.com/blog/2018/04/18/coding-with-the-ryze-tello/) to know details how to do this process.

![Tello blocks in Scratch](files/Tello&#32;in&#32;Scratch.png)
Figure: Tello blocks in Scratch

### Leap Motion in Scratch
1. Download [Scratch 2.0 Plug-in for Leap Motion.exe](https://github.com/khanning/khanning.github.io/blob/master/leapscratch/downloads/Scratch%202.0%20Plug-in%20for%20Leap%20Motion.exe) from https://github.com/khanning/khanning.github.io/tree/master/leapscratch/downloads
2. Connect Leap Motion controller to PC via USB.
3. Open Scratch 2.0 Offline
4. The Leap Motion interface will be shown in Scratch under __More Blocks__
* Read [https://khanning.github.io/scratch-leapmotion-extension/](https://khanning.github.io/scratch-leapmotion-extension/) to know more about the Scratch extention for Leap Motion.

### Controlling Tello by Leap Motion in Scratch
![Example: Tello by Leap Motion in Scratch](files/Tello&#32;by&#32;Leap&#32;Motion&#32;in&#32;Scratch.png)
Figure: Tello by Leap Motion in Scratch (example)

<br><br><br>
## Part B. Tello & Leap Motion using Gobot Library
### Limitation of Scratch
- Tello does not immediately move as it is controlled in Scratch. Once forward (or any direction) is commanded in Scratch to Tello, it starts to move in 1 or 2 seconds (no immediate movement; unkwon issue).
- Excute the _forward_ block in Scratch > (1~2s delay) > Tello moves forward > ...

### Gobot codes
- [Tello using Keyboard](drone/tello_with_keyboard.go)
- [Tello using Leap Motion](drone/tello_with_leap_motion.go)


[← go back to the list](https://HandongHCI.github.io/HCI2018S)
