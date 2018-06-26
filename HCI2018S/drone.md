[← go back to the list](https://HandongHCI.github.io/HCI2018S)

# Drone Team

<img src="files/DJI Tello.jpg" height="200"><img src="files/Leap Motion.jpg" height="200">

#### Members
- 김한설, 임승찬, 김시은, 김하준, 황인성, Dennis Phalula

#### Agenda
- Tello & Leap Motion using Scratch
- Tello & Leap Motion using Gobot library

## Part A. Tello & Leap Motion using Scratch
### DJI Tello in Scratch 
1. Install [Scratch 2.0 Offline Editor](https://scratch.mit.edu/download)
2. Install [node.js](https://nodejs.org/en/)
3. Download [Tello.js and Tello.s2e](https://dl-cdn.ryzerobotics.com/downloads/tello/20180222/Scratch.zip)
4. Open the terminal and go to the file directory where you saved the _Tello.js_ and _Tello.s2e_ files and type `node Tello.js`
5. Open Scratch 2.0, hold __Shift__ key, click __File__ menu, click __Import Experimental HTTP Extension__, and select _Tello.s2e_ file
6. The Tello interface will be shown in Scratch under More Blocks
![Tello blocks in Scratch](files/Tello&#32;in&#32;Scratch.png)

### Leap Motion in Scratch
1. Download [Scratch 2.0 Plug-in for Leap Motion.exe](https://github.com/khanning/khanning.github.io/blob/master/leapscratch/downloads/Scratch%202.0%20Plug-in%20for%20Leap%20Motion.exe) from https://github.com/khanning/khanning.github.io/tree/master/leapscratch/downloads
2. Connect the Leap Motion controller to the PC via USB.
3. Read [https://khanning.github.io/scratch-leapmotion-extension/](https://khanning.github.io/scratch-leapmotion-extension/) to know more about the Scratch extention for Leap Motion.


## Part B. Tello & Leap Motion using Gobot Library

### Gobot codes
- [Tello using Keyboard](drone/tello_with_keyboard.go)
- [Tello using Leap Motion](drone/tello_with_leap_motion.go)


[← go back to the list](https://HandongHCI.github.io/HCI2018S)
