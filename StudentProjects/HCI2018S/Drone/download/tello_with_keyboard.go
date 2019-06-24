/*
How to run:
Connect to the drone's Wi-Fi network from your computer. It will be named something like "TELLO-XXXXXX".

Once you are connected you can run the Gobot code on your computer to control the drone.

        go run examples/tello.go
*/

package main

import (
        "fmt"
        "time"
        "sync/atomic"

        "gobot.io/x/gobot"
        "gobot.io/x/gobot/platforms/dji/tello"
        "gobot.io/x/gobot/platforms/keyboard"

)

type pair struct {
        ws float64
        ad float64
        qe float64
        jk float64
}

var TelloAD, TelloWS, TelloQE, TelloJK atomic.Value
var valWS, valAD, valQE, valJK int

const offset = 100
const sensitivity = 3

func main() {
        drone := tello.NewDriver("8888")

        keys := keyboard.NewDriver()

        work := func() {
                TelloAD.Store(float64(0.0))
                TelloWS.Store(float64(0.0))
                TelloQE.Store(float64(0.0))
                TelloJK.Store(float64(0.0))
                valWS = 0
                valAD = 0
                valQE = 0
                valJK = 0

                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.O {
                                drone.TakeOff()
                        }
                })

                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.P {
                                drone.Land()
                        }
                })

                /* STOP moving */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.X {
                                valWS = 0
                                valAD = 0
                                valQE = 0
                                valJK = 0
                                TelloWS.Store(float64(valWS))
                                TelloAD.Store(float64(valAD))
                                TelloQE.Store(float64(valQE))
                                TelloJK.Store(float64(valJK))
                        }
                })

                /* FORWARD */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.W {
                                valWS = valWS + 1
                                if valWS > 20 {
                                      valWS = 20
                                }
                                TelloWS.Store(float64(valWS))
                        }
                })

                /* BACKWARD */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.S {
                                valWS = valWS - 1
                                if valWS < -20 {
                                      valWS = -20
                                }
                                TelloWS.Store(float64(valWS))
                        }
                })

                /* LEFT */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.A {
                                valAD = valAD - 1
                                if valAD < -20 {
                                      valAD = -20
                                }
                                TelloAD.Store(float64(valAD))
                        }
                })

                /* RIGHT */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.D {
                                valAD = valAD + 1
                                if valAD > 20 {
                                      valAD = 20
                                }
                                TelloAD.Store(float64(valAD))
                        }
                })

                /* CCW */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.Q {
                                valQE = valQE - 1
                                if valQE < -20 {
                                      valQE = -20
                                }
                                TelloQE.Store(float64(valQE))
                        }
                })

                /* CW */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.E {
                                valQE = valQE + 1
                                if valQE > 20 {
                                      valQE = 20
                                }
                                TelloQE.Store(float64(valQE))
                        }
                })

                /* UP */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.J {
                                valJK = valJK + 1
                                if valJK > 20 {
                                      valJK = 20
                                }
                                TelloJK.Store(float64(valJK))
                        }
                })

                /* DOWN */
                keys.On(keyboard.Key, func(data interface{}) {
                        key := data.(keyboard.KeyEvent)

                        if key.Key == keyboard.K {
                                valJK = valJK - 1
                                if valJK < -20 {
                                        valJK = -20
                                }
                                TelloJK.Store(float64(valJK))
                        }
                })

                /*gobot.Every(1*time.second, func() {
                }*/

                gobot.Every(10*time.Millisecond, func() {
                        controlDirection := Direction()

                        switch {
                                case controlDirection.ws > 0:
                                        drone.Forward(tello.ValidatePitch(controlDirection.ws * sensitivity, offset))
                                case controlDirection.ws < 0:
                                        drone.Backward(tello.ValidatePitch(controlDirection.ws * sensitivity, offset))
                                case controlDirection.ws == 0:
                                        drone.Forward(0)
                                        drone.Backward(0)
                                default:
                                        drone.Forward(0)
                                        drone.Backward(0)
                        }

                        switch {
                                case controlDirection.ad > 0:
                                        drone.Right(tello.ValidatePitch(controlDirection.ad * sensitivity, offset))
                                case controlDirection.ad < 0:
                                        drone.Left(tello.ValidatePitch(controlDirection.ad * sensitivity, offset))
                                case controlDirection.ad == 0:
                                        drone.Right(0)
                                        drone.Left(0)
                                default:
                                        drone.Right(0)
                                        drone.Left(0)
                        }

                        switch {
                                case controlDirection.qe > 0:
                                        drone.Clockwise(tello.ValidatePitch(controlDirection.qe * sensitivity * 2, offset))
                                case controlDirection.qe < 0:
                                        drone.CounterClockwise(tello.ValidatePitch(controlDirection.qe * sensitivity * 2, offset))
                                case controlDirection.qe == 0:
                                        drone.Clockwise(0)
                                        drone.CounterClockwise(0)
                                default:
                                        drone.Clockwise(0)
                                        drone.CounterClockwise(0)
                        }

                        switch {
                                case controlDirection.jk > 0:
                                        drone.Up(tello.ValidatePitch(controlDirection.jk * sensitivity, offset))
                                case controlDirection.jk < 0:
                                        drone.Down(tello.ValidatePitch(controlDirection.jk * sensitivity, offset))
                                case controlDirection.jk == 0:
                                        drone.Up(0)
                                        drone.Down(0)
                                default:
                                        drone.Up(0)
                                        drone.Down(0)
                        }
                })
        }

        robot := gobot.NewRobot("tello",
                []gobot.Connection{},
                []gobot.Device{keys, drone},
                work,
        )

        robot.Start()
}

func Direction() pair {
        s := pair{ws: 0, ad: 0, qe: 0, jk: 0}
        s.ws = TelloWS.Load().(float64)
        s.ad = TelloAD.Load().(float64)
        s.qe = TelloQE.Load().(float64)
        s.jk = TelloJK.Load().(float64)
        fmt.Println(s.ws, s.ad, s.qe, s.jk)
        return s
}