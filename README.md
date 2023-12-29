# DrivingCar
### an auto Driving Car Simulation, for prototype car
##  Car Movement Rules : 
- Command L: rotates the car by 90 degrees to the left : N=>W , W=>S , S=>E, E=>N
- Command R: rotates the car by 90 degrees to the right : N=>E , E=>S , S=>W, W=>N
- Command F: moves forward by 1 grid point
- If the car tries to go out of the boundary, that command is ignored

  # Project Structure
  ### DrivingCar.Domain
      for handling business logic
  ### DrivingCar.Application
      keeping interaction and  with Domain Layer
  ### DrivingCar.Infrastructure
      Manage DepencyInjection & Logging
  ### DrivingCar.ConsoleApplication
      Manage Presentation for DrivingCar
  ### DrivingCar.UnitTest
      UnitTest For Domain and Application layer

# Project Info
.net6.0

# Sample Run :
1.Open Project and Click Run From Visual Studio\n
![image](https://github.com/satriansyahw/DrivingCar/assets/20899978/2bf2371f-6652-4d61-a861-45bc02da8b1f)



  
