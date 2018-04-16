using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Assignment1_KnightsTour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //intelligent button pressed
        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(comboBox1.SelectedItem);
            int y = Convert.ToInt32(comboBox2.SelectedItem);
            int attempts = Convert.ToInt32(comboBox3.SelectedItem);
            String[] message = new String[10];
            double totalCount = 0;
            double average = 0;
            double[] stdVal = new double[10];
            double std = 0;
            int count = 0;

            for (int i = 0; i < attempts; i++)
            {
                Knight knight = new Knight(x, y);
                Board board = new Board(true, knight);
                //board.printBoard(0);
                //board.printBoard(1);

                int counter = knight.move(board);
                board.printBoard(2, richTextBox1);
                message[i] = "\nTrial " + (i + 1) + " Completed in " + counter + " steps.";
                richTextBox1.AppendText(message[i]);
                totalCount += counter;
                
                if (i == attempts - 1)
                {
                    stdVal[count] = counter;
                    count += 1;
                }  
     
                knight = null;
                board = null;
                counter = 0;
            }

            average = totalCount / attempts;
            for (int i = 0; i < stdVal.Length; i++)
            {
                stdVal[i] = (stdVal[i] - average) * (stdVal[i] - average);
                std += stdVal[i];
            }
            std = std / attempts;
            std = Math.Sqrt(std);


            System.IO.File.WriteAllLines("intelligent.txt", message);
            System.IO.File.AppendAllText("intelligent.txt", "Average: " + average);
            System.IO.File.AppendAllText("intelligent.txt", "Standard Deviation: " + std);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.AppendText("" + average);
            textBox2.AppendText("" + std);

        }


        //non-intelligent button pressed
        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(comboBox1.SelectedItem);
            int y = Convert.ToInt32(comboBox2.SelectedItem);
            int attempts = Convert.ToInt32(comboBox3.SelectedItem);
            String[] message = new String[10];
            double totalCount = 0;
            double average = 0;
            double[] stdVal = new double[10];
            double std = 0;
            int count = 0;

            for (int i = 0; i < attempts; i++)
            {
                Knight knight = new Knight(x, y);
                Board board = new Board(false, knight);

                int counter = knight.move(board);
                board.printBoard(2, richTextBox1);
                message[i] = "\nTrial " + (i+1) + " Completed in " + counter + " steps.";
                richTextBox1.AppendText(message[i]);
                totalCount += counter;

                if (i == attempts - 1)
                {
                    stdVal[count] = counter;
                    count += 1;
                }

                knight = null;
                board = null;
                counter = 0;
            }

            average = totalCount / attempts;
            
            for (int i = 0; i < stdVal.Length; i++)
            {
                stdVal[i] = (stdVal[i] - average) * (stdVal[i] - average);
                std += stdVal[i];
            }
            std = std / attempts;
            std = Math.Sqrt(std);

            System.IO.File.WriteAllLines("non_intelligent.txt", message);
            System.IO.File.AppendAllText("non_intelligent.txt", "Average: " + average);
            System.IO.File.AppendAllText("non_intelligent.txt", "Standard Deviation: " + std);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.AppendText(""+average);
            textBox2.AppendText("" + std);

        }

        //view intelligent generated file
        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("intelligent.txt");

        }   

        //view non-intelligent generated file
        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("non_intelligent.txt");
        }

        //clear the rich text box
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
