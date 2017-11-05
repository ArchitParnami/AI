Requirements:
	Microsoft Visual Studio and C#.NET

How to execute:
	Running from Visual Studio:
		Open the location file located at .\nQueens\nQueens.sln
		Solution opens in visual studio
		Goto  Build -> Build Solution
		Press F5

	Directly from Executable
		Execute the nQueens.exe present in this folder

User Interface:
	1. Select the desired algorithm from the list.
	2. Select Yes/No if you want to use random restart or not
	3. Set the value of number of Queens
	4. Set Max Steps if using Min Conflicts Algorithm
	5. Set Maximum iterations if using Random Restart

	Run Button:
		Clicking run button finds the solution for desired input

	Generate Button:
		Is enabled when not using random restart.
		Will randomly generate a n x n board.
		Click on Step button afterwards to see step by step solution.
		Click Run if you want to skip step wise solution.

	Reset Button:
		Will reset the interface to default state.
		Click rest to try another set of parameters

	Max Steps: 
		1 to 10,000
	Max Iterations: 
		1 to 10,000
	Queens: 
		1 to 100, but 20 is the size that max fits the screen without getting cropped.

	Conflicts: 
		Number of pairs of queens attacking each other
	Moves:
		Number of state changes.
	Iterations:
		Number of random restarts


