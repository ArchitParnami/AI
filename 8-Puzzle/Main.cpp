/*
Author: Archit Parnami
ITCS 6150 : Project 1
*/


#include<iostream>
#include "AStar.h"

void printMatrix(int**);

using namespace std;

int main()
{
	int **initialState = new int*[3];
	int **finalState = new int*[3];
	for (int i = 0; i < 3; i++) {
		initialState[i] = new int[3];
		finalState[i] = new int[3];
	}

	//Uncomment any of the input and goal values below to test the application.

	//Sample Test
	//int input[3][3] = { { 1,2,3 },{ 7,5,6 },{ 8,4,0 } };
	//int goal[3][3] = { { 1,2,3 },{ 4,5,6 },{ 7,8,0 } };

	//Example 1
	//int input[3][3] = { { 2,8,3 },{ 1,6,4 },{ 7,0,5 } };
	//int goal[3][3] = { {1,2,3}, {8,6,4},{7,5,0} };

	//Example 2
	//int input[3][3] = { { 5,4,0 },{ 6,1,8 },{ 7,3,2 } };
	//int goal[3][3] = { { 1,2,3 },{ 4,0,5 },{ 6,7,8 } };

	//Example 3
	//int input[3][3] = { { 7,2,4 },{ 5,0,6 },{ 8,3,1 } };
	//int goal[3][3] = { { 0,1,2 },{ 3,4,5 },{ 6,7,8 } };


	//also comment this block of code to use the hard-coded input values above.
	cout << "Valid input range from 0 to 8 where 0 is blank tile" << endl << endl;
	cout << "Enter start state(seperated by space): ";
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			cin >> initialState[i][j];
		}
	}

	//also comment this block of code to use the  hard-coded input values above.
	cout << endl << "Enter goal state(seperated by space): ";
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			cin >> finalState[i][j];
		}
	}

	//also Uncomment this block of code to use  hard-coded input values above.

	/*for (int i = 0; i < 3; i++) {
	for (int j = 0; j < 3; j++) {
	initialState[i][j] = input[i][j];
	finalState[i][j] = goal[i][j];
	}
	}*/

	AStar *star = new AStar(initialState, finalState);

	cout << "Searching for Solution..." << endl;
	star->start();

	std::stack<Node*> solution = star->getSolution();
	cout << endl << "Solution found..." << endl;

	cout << "States Expanded: " << star->getNumberOfStatesExpanded() << "\t"
		<< "Generated: " << star->getNumberofStatesGenerated() << endl;

	cout << endl << "Moves: " << solution.size() - 1 << endl;

	cout << "Press any key to print the solution.." << endl;
	cin.get();
	cin.get();

	while (!solution.empty())
	{
		Node *node = solution.top();
		cout << node->cost << endl << endl;
		printMatrix(node->state);
		solution.pop();
	}

	delete[] initialState;
	delete[] finalState;
	delete star;

	cout << "Press any key to exit...";
	cin.get();
	return 0;
}

void printMatrix(int** m) {
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			cout << m[i][j] << " ";
		}
		cout << endl;
	}
	cout << endl;
}
