# TableTop Robot

TableTop Robot is a console application written in C# that simulates the movement of a robot on a grid. The robot can be placed on a 5x5 grid, and can be moved in any of the four cardinal directions (North, South, East, West). The application also allows the robot to rotate 90 degrees clockwise or anticlockwise, and output its current position and facing direction.

## System Requirements: 
Target framework .NET 6.0

## Installation

To use the application, clone the repository to your local machine and open the project in Visual Studio. Build and run the project to launch the console application.

## Usage

The application provides a command-line interface to interact with the robot. The available commands are:

- **place(x,y,facing)**: Places the robot on the grid at the specified location and facing direction. The x and y values must be integers within the range [0,4]. The facing direction must be one of the following: North, South, East, West.

- **move()**: Moves the robot one unit in the direction it is currently facing. If the move would cause the robot to fall off the grid, it is not allowed.

- **left()**: Rotates the robot 90 degrees anticlockwise.

- **right()**: Rotates the robot 90 degrees clockwise.

- **report()**: Outputs the current position and facing direction of the robot.

- **x or Esc**: Exits the application.

## Example Usage

The following example demonstrates how to use the application to place the robot at location (1,2) facing North, move it one unit forward, rotate it 90 degrees clockwise, and output its current position and facing direction.

```
Enter a command: place(1,2,North)
Success: Robot has been placed on the grid at(1, 2) facing NORTH.
Enter a command: move
Success: Robot moved forward facing North.
Enter a command: right
Success: Turned left. Robot is now facing NORTH.
Enter a command: report
Output:  3, 3,  NORTH.
```

