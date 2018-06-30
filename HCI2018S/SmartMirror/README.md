[← go back to the list](https://HandongHCI.github.io/HCI2018S)

# Smart Mirror

http://www.youtube.com/watch?v=XpDLMKQtfx4
https://www.youtube.com/watch?v=tmxpc1bJFaQ

#### Introduction

- This project was based on [Evan Cohen's Smart Mirror project](https://github.com/evancohen/smart-mirror).
- From our project, the necessary files, `keyfile.json` and `config.json`, were deleted because it contains personal API keys.
- See details about this project from [Evan's documentation](http://docs.smart-mirror.io).

#### Members
- 박종욱, 이상규, 김진이, 노진기, 한진영, M. Janet Mwanjiwa

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
![Example: Tello by Leap Motion in Scratch](../files/Tello&#32;by&#32;Leap&#32;Motion&#32;in&#32;Scratch.png)
Figure: Tello by Leap Motion in Scratch (example)


<br><br><br>
## Part B. Tello & Leap Motion using Gobot Library
### Limitation of Scratch
- Tello does not immediately move as it is controlled in Scratch. Once Tello is commanded to move in Scratch, it starts moving 1 or 2 seconds later (no immediate movement; unkwon issue).
- Excute the _forward_ block in Scratch > (1~2s delay) > Tello moves forward > ...

### Gobot 
- [Gobot](https://gobot.io/) is a framework of Go language, that supports [30+ robotics, Drones, and IoT devices](https://gobot.io/documentation/platforms/) including Tello and Leap Motion.
- See [Tello and Leap Motion Gobot examples](https://gobot.io/documentation/examples/) to understand how to use Gobot framework.
- To use Gobot
  1. Install [Go language](https://golang.org/)
  2. Install [Git](https://git-scm.com/downloads) if you use Windows (Mac does not require this step)
  3. Install Gobot. To install, in Git-Bash (MS Windows) or Terminal (MacOS), type `$ go get -d -u gobot.io/x/gobot/...` (including the three dots)
  4. In Git-Bash or Terminal, go to the directory where tello.go file exists. Then, type `go run tello.go` to run the Go file.

### Source Code
- Tello using Keyboard
- Tello using Leap Motion
- download from <a href="Drone" target="_blank">here</a>


<br><br><br>
## Further Issues
- upgrade the code for better alogirhm to control Tello with more natural hand guesture
- controlling multiple tellos altogether at the same time
- look into Tello.js if Tello can more immediately respond in Scratch


<br><br><br>
### Comments by the team
In conclusion, interaction with Leap Motion was not easy as it seemed. Reality and our expectation was usually different. And it was new to know that debugging part was so important. However, we could also learn that we don’t have to fully understand a certain language or skills to use it. What we need is problem solving skills rather than trying to know everything. We found out the interaction between the  hand guesture and drone is promising. It should be very intuitive. Whoever use drone for first time will know how to use it. Imagine yourself playing pilot game virtually. You can have tons of hand interaction without things like joystick!


<br><br><br>
[← go back to the list](https://HandongHCI.github.io/HCI2018S)
