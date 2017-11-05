using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nQueens
{
    enum Algorithm
    {
        Hill_Climbing,
        Min_Conflicts
    };

    public partial class MainForm : Form
    {
        private UInt16 numOfQueens;
        private TableLayoutPanel panel;
        private State initialState;
        private HillClimbingSolver hillClimbingSolver;
        private MinConflictSolver minConflictSolver;
        private bool doRandomRestart;
        private Algorithm algorithm;
        private string hc = "Hill Climbing";
        private string mc = "Min Conflicts";
       

        public MainForm()
        {
            InitializeComponent();
            this.algoComboBox.Items.Add(hc);
            this.algoComboBox.Items.Add(mc);
          
            this.randomRestartComboBox.Items.Add("No");
            this.randomRestartComboBox.Items.Add("Yes");

            resetButton_Click(this, null);

        }

        private void LockControls()
        {
            generateButton.Enabled = false;
            this.algoComboBox.Enabled = false;
            this.randomRestartComboBox.Enabled = false;
            this.inputUpDown.Enabled = false;
            this.stepsUpDown.Enabled = false;
            this.maxIterBox.Enabled = false;

        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            LockControls();
            ConstructLayout();
            initialState = State.GetRandomState(numOfQueens);
            PlotState(initialState);
            stepButton.Enabled = true;
            RunButton.Enabled = true;
            hillClimbingSolver = null;
            minConflictSolver = null;
        }

        private void ConstructLayout()
        {
            numOfQueens = Decimal.ToUInt16(this.inputUpDown.Value);
            if (panel != null)
            {
                Controls.Remove(panel);
            }
            panel = new TableLayoutPanel();
            DrawBoxes();
        }

        private void DrawBoxes()
        {
            panel.SuspendLayout();
            panel.AutoSize = true;
            panel.ColumnCount = numOfQueens;
            panel.RowCount = numOfQueens;

            int w = 20;
            int margin = 10;
            int center = (this.Size.Width) / 2;
            int gridCenter = ((w+margin) * numOfQueens)/2;
            int xStart = 0;
            int diff = center - gridCenter;
            if (diff > 0)
                xStart = diff;    
          
            int yStart = 180;

            panel.Location = new System.Drawing.Point(xStart, yStart);

            float percent = (1 / numOfQueens) * 100;


            for (int i = 0; i < numOfQueens; i++)
            {
                ColumnStyle cStyle = new ColumnStyle(SizeType.Percent, percent);
                panel.ColumnStyles.Add(cStyle);
            }

            for (int i = 0; i < numOfQueens; i++)
            {
                RowStyle rStyle = new RowStyle(SizeType.Percent, percent);
                panel.RowStyles.Add(rStyle);
            }


            Color current = Color.White;
            Color next = current;

            for (int i = 0; i < numOfQueens; i++)
            {
                for(int j = 0; j< numOfQueens; j++)
                {
                    
                    int x = xStart + (j * w);
                    int y = yStart + (i * w);

                    TextBox t = new TextBox();
                    t.ReadOnly = true;

                    t.BackColor = next;
                    t.Size = new Size(w, w);
                    t.Location = new System.Drawing.Point(x,y);
                    t.TextAlign = HorizontalAlignment.Center;
                    t.ForeColor = Color.Black;
                   
                    
                    panel.Controls.Add(t, j, i);

                    if (next == Color.LightGray)
                        next = Color.White;
                    else
                        next = Color.LightGray;
                }

                if (current == Color.LightGray)
                    current = Color.White;
                else
                    current = Color.LightGray;

                next = current;
            }

            Controls.Add(panel);
            panel.ResumeLayout(false);
            panel.PerformLayout();
        }

        private void PlotState(State state)
        {
            for(int i = 0; i < state.NumOfQueens; i++)
            {
                TextBox t = (TextBox)panel.GetControlFromPosition(i, state[i]);
                t.Text = "Q";
                t.Font = new Font(DefaultFont, FontStyle.Bold);
               
            }
        }

        private void ClearState()
        {
            for(int i = 0; i < numOfQueens; i++)
            {
                for(int j = 0; j < numOfQueens; j++)
                {
                    TextBox t = (TextBox)panel.GetControlFromPosition(i, j);
                    t.Text = "";
                    t.ForeColor = Color.Black;
                    t.Font = DefaultFont;
                }
            }
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            stepButton.Enabled = false;
            bool proceed;
            ISolver solver;
            if(algorithm == Algorithm.Hill_Climbing)
            {
                proceed = HillClimbingStep();
                solver = hillClimbingSolver;
            }

            else
            {
                proceed = MinConflictStep();
                solver = minConflictSolver;
            }

            this.movesTextBox.Text = solver.Moves.ToString();
            stepButton.Enabled = proceed;

            if (!proceed)
            {
                this.iterationsTextBox.Text = "1";
                ShowMessage(solver.NumOfConflicts == 0);
                RunButton.Enabled = false;
            }

            stepButton.Focus();
        }

        private bool HillClimbingStep()
        {
            if (hillClimbingSolver == null)
            {
                hillClimbingSolver = new HillClimbingSolver(initialState);
            }

            else
            {
                if (hillClimbingSolver.Next())
                {
                    ClearState();
                    PlotState(hillClimbingSolver.CurrentState);
                }
                else
                {
                    return false;
                }
            }

            PlotHillClimbingSolver(hillClimbingSolver);
            return true;
        }

        private bool MinConflictStep()
        {
            if(minConflictSolver == null)
            {
                int maxSteps = Decimal.ToInt32(this.stepsUpDown.Value);
                minConflictSolver = new MinConflictSolver(initialState, maxSteps);
            }

            else
            {
                if(minConflictSolver.Next())
                {
                    ClearState();
                    PlotState(minConflictSolver.CurrentState);
                }
                else
                {
                    return false;
                }
            }

            PlotMinConflictSolver(minConflictSolver);

            return true;
        }

        private void PlotHillClimbingSolver(HillClimbingSolver solver)
        {
            conflictTextBox.Text = solver.NumOfConflicts.ToString();

            if(solver.NumOfConflicts > 0)
            {
                int[,] costMatrix = solver.CostMatrix;
                for (int i = 0; i < numOfQueens; i++)
                {
                    for (int j = 0; j < numOfQueens; j++)
                    {
                        TextBox t = (TextBox)panel.GetControlFromPosition(i, j);
                        if (t.Text != "Q")
                        {
                            t.Text = costMatrix[i, j].ToString();
                        }
                    }
                }
            }

            List<Point> points = solver.MinConflictPoints;

            foreach (Point point in points)
            {
                TextBox t = (TextBox)panel.GetControlFromPosition(point.X, point.Y);

                if (point == solver.TargetPoint)
                    t.ForeColor = Color.Blue;
                else
                    t.ForeColor = Color.Red;

                t.Font = new Font(DefaultFont, FontStyle.Bold);
            }
        }

        private void PlotMinConflictSolver(MinConflictSolver solver)
        {
            conflictTextBox.Text = solver.NumOfConflicts.ToString();
            int[] costArray = solver.CostArray;

            if(solver.NumOfConflicts > 0)
            {

                for (int y = 0; y < numOfQueens; y++)
                {
                    TextBox t = (TextBox)panel.GetControlFromPosition(solver.CurrentQueen, y);
                    if (t.Text != "Q")
                    {
                        t.Text = costArray[y].ToString();
                    }
                }
            }


            List<Point> points = solver.MinCostPoints;

            foreach (Point point in points)
            {
                TextBox t = (TextBox)panel.GetControlFromPosition(point.X, point.Y);

                if (point == solver.TargetPoint)
                    t.ForeColor = Color.Blue;
                else
                    t.ForeColor = Color.Red;

                t.Font = new Font(DefaultFont, FontStyle.Bold);
            }

        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            RunButton.Enabled = false;
            this.stepButton.Enabled = false;
            LockControls();
            bool success;

            if(doRandomRestart)
            {
                ConstructLayout();
                int maxIter = Decimal.ToInt32(maxIterBox.Value);
                int maxSteps = Decimal.ToInt32(this.stepsUpDown.Value);

                RandomRestart rr = new RandomRestart(algorithm, numOfQueens, maxIter, maxSteps);
                success = rr.Run();

                this.iterationsTextBox.Text = rr.Iterations.ToString();
                this.movesTextBox.Text = rr.Solver.Moves.ToString();

                PlotState(rr.Solver.CurrentState);

                if (algorithm == Algorithm.Hill_Climbing)
                    PlotHillClimbingSolver(rr.Solver as HillClimbingSolver);
                else
                    PlotMinConflictSolver(rr.Solver as MinConflictSolver);
            }

            else
            {
                ISolver solver;
                if(algorithm == Algorithm.Hill_Climbing)
                {
                    while (HillClimbingStep()) { }
                    solver = hillClimbingSolver;
                }
                else
                {
                    while (MinConflictStep()) { }
                    solver = minConflictSolver;
                }

                this.movesTextBox.Text = solver.Moves.ToString();
                success = solver.NumOfConflicts == 0;
                this.iterationsTextBox.Text = "1";
            }

            ShowMessage(success);       
        }

        private void algoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.algoComboBox.SelectedIndex == 1)
                algorithm = Algorithm.Min_Conflicts;
            else
                algorithm = Algorithm.Hill_Climbing;

            if (algorithm == Algorithm.Hill_Climbing)
                this.stepsUpDown.Enabled = false;
            else
                this.stepsUpDown.Enabled = true;
        }

        private void randomRestartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.randomRestartComboBox.SelectedIndex == 0)
                doRandomRestart = false;
            else
                doRandomRestart = true;

            if(doRandomRestart)
            {
                this.generateButton.Enabled = false;
                this.stepButton.Enabled = false;
                this.maxIterBox.Enabled = true;
                this.RunButton.Enabled = true;
            }

            else
            {
                this.generateButton.Enabled = true;
                this.maxIterBox.Enabled = false;
                this.RunButton.Enabled = false;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.algoComboBox.Enabled = true;
            this.algoComboBox.SelectedIndex = 0;
            algoComboBox_SelectedIndexChanged(this, null);

            this.randomRestartComboBox.Enabled = true;
            this.randomRestartComboBox.SelectedIndex = 0;
            randomRestartComboBox_SelectedIndexChanged(this, null);

            this.inputUpDown.Enabled = true;
            this.generateButton.Enabled = true;
            this.stepButton.Enabled = false;

            if (panel != null)
            {
                Controls.Remove(panel);
            }

           
            this.stepsUpDown.Value = 50;
            this.maxIterBox.Value = 500;
            this.inputUpDown.Value = 8;

            this.conflictTextBox.Text = "";
            this.movesTextBox.Text = "";
            this.iterationsTextBox.Text = "";
            this.statusLabel.Text = "";

        }

        private void ShowMessage(bool success)
        {
            
            if (success)
            {
                this.statusLabel.Text = "SUCCESS!";
                this.statusLabel.ForeColor = Color.Green;
            }
                
            else
            {
                this.statusLabel.Text = "FAILED!";
                this.statusLabel.ForeColor = Color.Blue;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
          
        }
    }
}
