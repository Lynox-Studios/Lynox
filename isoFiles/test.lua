local graphics = require "lynoxAPI.graphics"

graphics.createcanvas(1280,720)

graphics.clearcanvas(0,0,255)
graphics.drawfilledrect(0,680,1280,40,255,255,255)
graphics.displaycanvas()