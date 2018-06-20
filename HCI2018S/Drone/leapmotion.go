package main

import (
        "fmt"
		_ "sync/atomic"
        "gobot.io/x/gobot"
        "gobot.io/x/gobot/platforms/leap"
)

var PalmPosition []float64
var User1 int
var User2 int
var count int
func main() {
        leapMotionAdaptor := leap.NewAdaptor("127.0.0.1:6437")
        l := leap.NewDriver(leapMotionAdaptor)

        work := func() {
				
               
                l.On(leap.HandEvent, func(data interface{}) {
				//PalmPosition = data.(leap.Hand).StabilizedPalmPosition

                //fmt.Println(int(PalmPosition[0]/3), int(PalmPosition[1]/3), int(PalmPosition[2]/3))
				fmt.Println(data.(leap.Hand).R[1][0])
				//User1 = data.(leap.Hand).ID
				
				
				
				

			
				
				})
        }

        robot := gobot.NewRobot("leapBot",
                []gobot.Connection{leapMotionAdaptor},
                []gobot.Device{l},
                work,
        )

        robot.Start()
}

