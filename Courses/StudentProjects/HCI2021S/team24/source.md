# HCI 02-Team 04 

# Detailed code 

1. Pykinect2 패키지를 다운로드 하세요
[Pykinect2](https://github.com/Kinect/PyKinect2)

2. Pykinect2SandMount 패키지를 다운로드 하세요
[Pykinect2SandMount](https://github.com/twwspes/pykinect2SandMount)

3. 설치 후 컴퓨터를 KinectV2와 연결하세요

#핵심 코드들이 밑에 있어요

```Python
#언어는 파이썬
import pygame
from pykinect2 import PyKinectV2
from pykinect2.PyKinectV2 import *
from pykinect2 import PyKinectRuntime
import time

import ctypes
import _ctypes
import pygame
import sys

import random
import math
import datetime

#버튼 클래스
class Button:
    def __init__(self, x, y, sx, sy, bborder,bcolour, fbcolour, font, fontsize, fcolour, text):
        self.x = x
        self.y = y
        self.sx = sx
        self.sy = sy
        self.bborder = bborder
        self.bcolour = bcolour
        self.fbcolour = fbcolour
        self.fcolour = fcolour
        self.fontsize = fontsize
        self.text = text
        self.current = False
        self.buttonf = pygame.font.SysFont(font, fontsize)
            
#사용자의 마우스 클릭을 인식하는 매서드 
    def focusCheck(self, mousepos, mouseclick):
        if(mousepos[0] >= self.x and mousepos[0] <= self.x + self.sx and mousepos[1] >= self.y and mousepos[1] <= self.y + self.sy):
            self.current = True
            return mouseclick[0]
        else:
            self.current = False
            return False
 
 #이 게임에서 없어서는 안 될 클래스
 class PyKinectCollect(object):
     def __init__(self, title, width = 1400, height=800, fill=YELLOW):
         self._clock = pygame.time.Clock()

         #스크린의 사이즈 설정; 가로, 세로
         self._infoObject = pygame.display.Info()
         self._screen = pygame.display.set_mode((self._infoObject.current_w >> 1, self._infoObject.current_h >> 1), 
                                               pygame.HWSURFACE|pygame.DOUBLEBUF|pygame.RESIZABLE)                                          
         #사용자가 close 버튼을 누르지 않는다면
         self._done = False

         #Kinect runtime object 
         self._kinect = PyKinectRuntime.PyKinectRuntime(PyKinectV2.FrameSourceTypes_Color | PyKinectV2.FrameSourceTypes_Body)

         #Kinect color frames, 32비트 색깔, 가로, 그리고 세로를 담을 공간(surface)
         self._frame_surface = pygame.Surface((self._kinect.color_frame_desc.Width, self._kinect.color_frame_desc.Height), 0, 32)

         #골격 정보를 담는 공간 
         self._bodies = None

         self.current = False
         self.title = title
         self.width = width
         self.height = height
         self.fill = fill        

#사용자의 몸이 화면에 보이도록 하고, 게임 작동 원리를 담고 있는 매서드  
     def draw_body_bone(self, joints, jointPoints, color, joint0, joint1, boardN):
         joint0State = joints[joint0].TrackingState;
         joint1State = joints[joint1].TrackingState;

         #사용자의 관절이 부분적으로 인식될 때 
         if (joint0State == PyKinectV2.TrackingState_NotTracked) or (joint1State == PyKinectV2.TrackingState_NotTracked):
             return

         #사용자의 관절이 전혀 인식되지 않을 때 
         if (joint0State == PyKinectV2.TrackingState_Inferred) and (joint1State == PyKinectV2.TrackingState_Inferred):
             return

         start = (0, 0)
         end = (0, 0)
         global starttime
         global flag
         
         #사용자의 머리를 인식하는 경우
         if (boardN == 1):
            
            #사용자의 머리 인식을 위해 x, y 좌표 정의 
            JointX = jointPoints[PyKinectV2.JointType_Head].x
            JointY = jointPoints[PyKinectV2.JointType_Head].y
            
            #사용자의 머리가 주어진 범위 안에 있을 때 
            if (1400 <= JointX) and (1000 >= JointY):
                
                #처음 
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('right', fts2)
                    if (starttime+2 < fts2):
                        print('touch1')
                        flag = 0
                        
            elif (700 >= JointX) and (1000 >= JointY):
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('left', fts2)
                    if (starttime+2 < fts2):
                        print('touch1')
                        flag = 2
            else:
                starttime = 0

        elif (boardN == 2):
            JointX = jointPoints[PyKinectV2.JointType_Head].x
            JointY = jointPoints[PyKinectV2.JointType_Head].y
         
            if (700 >= JointX) and (50 <= JointY) and (250 >= JointY):            
                print('touch2 left')
                flag = 2

            elif (1400 <= JointX) and (50 <= JointY) and (250 >= JointY):
                print('touch2 right')
                flag = 0

        #사용자의 손을 인식하는 경우
        elif (boardN == 3):
        
            #사용자의 손 인식을 위해 x, y 좌표 정의
            JointXR = jointPoints[PyKinectV2.JointType_HandRight].x
            JointYR = jointPoints[PyKinectV2.JointType_HandRight].y
            JointXL = jointPoints[PyKinectV2.JointType_HandLeft].x
            JointYL = jointPoints[PyKinectV2.JointType_HandLeft].y
            
            if (1400 <= JointXR) and (1000 >= JointYR):
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('HandRight', fts2)
                    if (starttime+2 < fts2):
                        print('touch3')
                        flag = 0
                             
            elif(700 >= JointXL) and (1000 >= JointYL):
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('HandLeft', fts2)
                    if (starttime+2 < fts2):
                        print('touch3')
                        flag = 2
            else:
                starttime = 0

        #사용자의 무릎을 인식하는 경우
        elif (boardN == 5):
        
            #사용자의 무릎 인식을 위해 x, y 좌표 정의
            JointXR = jointPoints[PyKinectV2.JointType_KneeRight].x
            JointYR = jointPoints[PyKinectV2.JointType_KneeRight].y
            JointXL = jointPoints[PyKinectV2.JointType_KneeLeft].x
            JointYL = jointPoints[PyKinectV2.JointType_KneeLeft].y
            
            if (1200 <= JointXR) and (1000 <= JointYR):    
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('KneeRight', fts2)
                    if (starttime+1 < fts2):
                        print('touch3')
                        flag = 0
                                  
            elif(850 >= JointXL) and (1000 <= JointYL) and (1200 >= JointYL):
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('KneeLeft', fts2)
                    if (starttime+1 < fts2):
                        print('touch3')
                        flag = 2
            else:
                starttime = 0

        #사용자의 팔꿈치를 인식하는 경우 
        elif (boardN == 9):
        
            #사용자의 팔꿈치 인식을 위해 x, y 좌표 정의
            JointXR = jointPoints[PyKinectV2.JointType_ElbowRight].x
            JointYR = jointPoints[PyKinectV2.JointType_ElbowRight].y
            JointXL = jointPoints[PyKinectV2.JointType_ElbowLeft].x
            JointYL = jointPoints[PyKinectV2.JointType_ElbowLeft].y
            
            if (1500 <= JointXR):
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)      
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('ElbowRight', fts2)
                    if (starttime+1 < fts2):
                        print('touch3')
                        flag = 0
   
            elif(600 >= JointXL):
                if (starttime == 0):
                    timestamp = datetime.datetime.now().timestamp()
                    fts = timestamp
                    starttime = fts
                    print('time start!!!!!!!!!!!!!!!!!!!!!!!!!')
                    pygame.display.update()
                    print (starttime)
                else:
                    timestamp = datetime.datetime.now().timestamp()
                    fts2 = timestamp
                    print('ElbowLeft', fts2)
                    if (starttime+1 < fts2):
                        print('touch3')
                        flag = 2
            else:
                starttime = 0

#사용자가 게임을 할 수 있도록 하는 매서드 
     def playGame(self,boardN):
        global flag
        flag = 1
        
        #주요 루프(loop)
        while not self._done:
            
            #사용자가 어떤 것을 한다면
            for event in pygame.event.get():
            
                #사용자가 close 버튼을 누른다면 
                if event.type == pygame.QUIT:
                
                    #사용자가 이 루프(loop)를 나가게 하는 Flag 
                    self._done = True 
                
                #화면의 크기가 변한다
                elif event.type == pygame.VIDEORESIZE: 
                    self._screen = pygame.display.set_mode(event.dict['size'], 
                                               pygame.HWSURFACE|pygame.DOUBLEBUF|pygame.RESIZABLE)
                    
            #프레임(frame)을 얻고, 그리기 위해   
            #프레임 정보로 back buffer surface 채우기 
            if self._kinect.has_new_color_frame():
                frame = self._kinect.get_last_color_frame()
                self.draw_color_frame(frame, self._frame_surface)
                frame = None

            #사용자의 골격을 인식하기 위해 
            if self._kinect.has_new_body_frame(): 
                self._bodies = self._kinect.get_last_body_frame()

            #사용자의 골격을 _frame_surface에 그린다
            if self._bodies is not None: 
                for i in range(0, self._kinect.max_body_count):
                    body = self._bodies.bodies[i]
                    if body.is_tracked and flag==1:
                        joints = body.joints
                        
                        #사용자의 관절 좌표를 color space로 바꾸기 
                        joint_points = self._kinect.body_joints_to_color_space(joints)
                        self.draw_body(joints, joint_points, SKELETON_COLORS[i],boardN)
                    elif (flag == 0) or (flag ==2):
                        break

            if (flag == 0) or (flag == 2):
                break

            #화면에 back buffer surface pixels를 복사하고, 그것의 크기를 조정한다 
            #화면 크기는 Kinect's color frame size에 따라 다르다
            h_to_w = float(self._frame_surface.get_height()) / self._frame_surface.get_width()
            target_height = int(h_to_w * self._screen.get_width())
            surface_to_draw = pygame.transform.scale(self._frame_surface, (self._screen.get_width(), target_height));
            self._screen.blit(surface_to_draw, (0,0))
            surface_to_draw = None
            
            #문제 이미지 
            titleImg = str(boardN) +"-3.png"
            
            #선택 문항 이미지 
            OptionImg1 = str(boardN)+ "-1.png"
            
            #선택 문항 이미지
            OptionImg2 = str(boardN )+"-2.png"
            
            #이미지를 싣고, 지정된 scale에 따라 그것을 조정한다
            img = pygame.image.load(OptionImg1)
            img = pygame.transform.scale(img, (230, 180))
            
            img2 = pygame.image.load(OptionImg2)
            img2 = pygame.transform.scale(img2, (230, 180))
           
            img3 = pygame.image.load(titleImg)
            img3 = pygame.transform.scale(img3, (1000, 140))
            
            #이미지를 화면에 보여줌 
            screen.blit(img, (250, 170))
            screen.blit(img2, (1050, 170))
            screen.blit(img3, (270, 10))

            pygame.display.update()
            
            #화면이 바뀜
            pygame.display.flip()

            #초당 60 프레임(frame)의 제한 
            self._clock.tick(60)

        #사용자가 문제를 맞췄는지, 틀렸는지를 알려준다 
        if flag == 0:
            global buttonlist
            buttonlist[boardN-1]=1         
            show_correct_img()
            print("0")           
        elif flag == 2:
            show_incorrect_img()
            print('2')
            
        pygame.time.delay(3000)

#이 게임이 작동되도록 하는 함수 
def w_game():
    pygame.font.init()

    game = PyKinectCollect("Bingo Game for Etiquette")
    b_screen = Screen("Bingo_Screen")
    win = b_screen.makeCurrent()
    done = False

    #버튼 그리기
    returnButton = Button(1000, 650, 300, 100,3, colours["Black"], colours["Cyan"], "arial", 20, colours["Black"], "RETURN")
    bingo_1 = Button(800,200,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "1")
    bingo_2 = Button(950,200,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "2")
    bingo_3 = Button(1100,200,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "3")
    bingo_4 = Button(800,350,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "4")
    bingo_5 = Button(950,350,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "5")
    bingo_6 = Button(1100,350,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "6")
    bingo_7 = Button(800,500,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "7")
    bingo_8 = Button(950,500,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "8")
    bingo_9 = Button(1100,500,150,150,3, colours["White"], colours["Cyan"],"arial", 20, colours["Black"], "9")

    toggle = False
    while not done:
        b_screen.screenUpdate()
        b_screen.show_middle_img()
        b_screen.show_left_img()
        game.screenUpdate()
        mouse_pos = pygame.mouse.get_pos()
        mouse_click = pygame.mouse.get_pressed()
        keys = pygame.key.get_pressed()
        
    #3x3 빙고 표에서의 좌표(행과 열)에 따라 page에 숫자를 부여했다 
    #b_1(행: 1, 열: 1)
        if b_screen.checkUpdate():
            screen2button = bingo_1.focusCheck(mouse_pos, mouse_click)
            bingo_1.showButton(b_screen.returnTitle(),buttonlist[0])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(1)
                b_screen.endCurrent()

        elif game.checkUpdate():
            b_screen.show_return_img()
            returnm = returnButton.focusCheck(mouse_pos, mouse_click)
            returnButton.showButton(game.returnTitle(),0)
            
            if returnm:
                win = b_screen.makeCurrent()
                game.endCurrent()
                
    #b_2(행: 1, 열: 2)  
        if b_screen.checkUpdate():
            screen2button = bingo_2.focusCheck(mouse_pos, mouse_click)
            bingo_2.showButton(b_screen.returnTitle(),buttonlist[1])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(2)
                b_screen.endCurrent()

    #b_3(행: 1, 열: 3)  
        if b_screen.checkUpdate():
            screen2button = bingo_3.focusCheck(mouse_pos, mouse_click)
            bingo_3.showButton(b_screen.returnTitle(),buttonlist[2])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(3)
                b_screen.endCurrent()
                
    #b_4(행: 2, 열: 1)   
        if b_screen.checkUpdate():
            screen2button = bingo_4.focusCheck(mouse_pos, mouse_click)
            bingo_4.showButton(b_screen.returnTitle(),buttonlist[3])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(4)
                b_screen.endCurrent()
                
    #b_5(행: 2, 열: 2)   
        if b_screen.checkUpdate():
            screen2button = bingo_5.focusCheck(mouse_pos, mouse_click)
            bingo_5.showButton(b_screen.returnTitle(),buttonlist[4])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(5)
                b_screen.endCurrent()

    #b_6(행: 2, 열: 3)  
        if b_screen.checkUpdate():
            screen2button = bingo_6.focusCheck(mouse_pos, mouse_click)
            bingo_6.showButton(b_screen.returnTitle(),buttonlist[5])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(6)
                b_screen.endCurrent()

    #b_7(행: 3, 열: 1)   
        if b_screen.checkUpdate():
            screen2button = bingo_7.focusCheck(mouse_pos, mouse_click)
            bingo_7.showButton(b_screen.returnTitle(),buttonlist[6])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(7)
                b_screen.endCurrent()

    #b_8(행: 3, 열: 2)   
        if b_screen.checkUpdate():
            screen2button = bingo_8.focusCheck(mouse_pos, mouse_click)
            bingo_8.showButton(b_screen.returnTitle(),buttonlist[7])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(8)
                b_screen.endCurrent()

    #b_9(행: 3, 열: 3)   
        if b_screen.checkUpdate():
            screen2button = bingo_9.focusCheck(mouse_pos, mouse_click)
            bingo_9.showButton(b_screen.returnTitle(),buttonlist[8])
            if screen2button:
                win = game.makeCurrent()
                g_screen=game.playGame(9)
                b_screen.endCurrent()

        for event in pygame.event.get():
            if(event.type == pygame.QUIT):
                done = True
        for event in pygame.event.get():
            if(event.type == pygame.QUIT):
                done = True
                
        pygame.display.update()
        
    pygame.quit()
```
