﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathematicaLibraryIVS;

//known bugs:
//1. po stlaceni klavesy a naslednom drzani enter sa spamuje cislo
//2. nadvazuje na 1. -> po zaspamovani a naslednom stlaceni znamienka padne calc

namespace Calculator
{
    public partial class CalculatorWindow : Form
    {
        /// <summary>
        /// true - txtNumBox needs to be cleared
        /// </summary>
        bool lineClear = true;
        /// <summary>
        /// true - last pressed button is equation
        /// </summary>
        bool eqLast = false;
        /// <summary>
        /// true - last pressed button is operation button
        /// </summary>
        bool opLast = false;
        /// <summary>
        /// true - txtTrackBox needs to be cleared
        /// </summary>
        bool trackClear = false;
        /// <summary>
        /// true - if basic operation button is pressed, 0 is added after the comma
        /// </summary>
        bool commaLast = false;
        decimal firstNum = 0;
        decimal secNum = 0;
        decimal result = 0;
        int operationCount = 0;
        string operatorStr;
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function for printing Error, resets firstNumber, operatorStr and operationCount, sets clearing for txtNumbox, clears txtTrackBox
        /// </summary>
        private void printError()
        {
            txtNumBox.Text = "Error";
            firstNum = 0;
            lineClear = true;
            txtBoxTrack.Clear();
            operationCount = 0;
            operatorStr = "";
        }

        /// <summary>
        /// Event click method that prints comma into textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertComma_Click(object sender, EventArgs e)
        {
            if (txtNumBox.Text == "Error")
            {
                return;
            }
            if (!txtNumBox.Text.Contains(","))
            {
                commaLast = true;
                txtNumBox.Text += ",";
                lineClear = false;
            }
        }

        /// <summary>
        /// Event click method, prints number into textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertNum_Click(object sender, EventArgs e)
        {
            Button opButton = (Button)sender;
            // clears line for new input
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += opButton.Text;
            opLast = false;
            //clears track box, before new calculation
            if (trackClear)
            {
                txtBoxTrack.Clear();
                trackClear = false;
            }
            if (eqLast)
            {
                firstNum = 0;
                eqLast = false;
            }
        }

        /// <summary>
        /// Function clears txtNumBox and sets its value to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_click(object sender, EventArgs e)
        {
            if (!lineClear)
            {
                txtNumBox.Clear();
                txtNumBox.Text += "0";
                lineClear = true;
            }
        }

        /// <summary>
        /// Function clears result box, track box, result and numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAll_click(object sender, EventArgs e)
        {
            txtNumBox.Clear();
            txtBoxTrack.Text = "";
            firstNum = 0;
            secNum = 0;
            result = 0;
            operationCount = 0;
            txtNumBox.Text = "0";
            lineClear = true;
        }

        /// <summary>
        /// Fuction used for handling basic operations (+,-,*,/)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void basic_op_click(object sender, EventArgs e)
        {
            Button opButton = (Button)sender;
            if (!opLast)
            {
                if (txtNumBox.Text == "Error")
                {
                    return;
                }
                commaCheck();
                if (firstNum == 0 && operationCount == 0) //first operation
                {
                    firstNum = Convert.ToDecimal(txtNumBox.Text);
                    labelSet(false, txtNumBox.Text);
                    operatorStr = opButton.Text;
                    labelSet(true, operatorStr);
                    lineClear = true;
                    operationCount++;
                    opLast = true;
                }
                else if (eqLast) // operation with result from last operation
                {
                    eqLast = false;
                    txtBoxTrack.Clear();
                    trackClear = false;
                    labelSet(false, firstNum.ToString());
                    operatorStr = opButton.Text;
                    labelSet(true, operatorStr);
                    lineClear = true;
                    operationCount++;
                    opLast = true;
                }
                else
                {
                    operationCount++;
                    if (operationCount >= 3) // chaining 3 or more operation
                    {
                        secNum = Convert.ToDecimal(txtNumBox.Text);
                        computeRes(result, secNum, operatorStr);

                        labelSet(true, operatorStr);
                        labelSet(false, secNum.ToString());

                        operatorStr = opButton.Text; //funguje aj bez tohoto

                        opLast = true;

                        firstNum = result;
                        //printing the result
                        txtNumBox.Text = result.ToString();   
                    }
                    else // chaining two operations
                    {
                        labelSet(false, txtNumBox.Text);

                        computeRes(firstNum, Convert.ToDecimal(txtNumBox.Text), operatorStr);

                        operatorStr = opButton.Text;

                        opLast = true;

                        firstNum = result;
                        //printing the result
                        txtNumBox.Text = result.ToString();
                    }
                    lineClear = true;
                }

            }
        }

        /// <summary>
        /// Fuction sets track box 
        /// </summary>
        /// <param name="type">If type is true, fuction uses format for operation. If type is false,function uses format for numbers</param>
        /// <param name="lbltext"></param>
        private void labelSet(bool type, string lbltext)
        {
            if (!type)
            {
                if (txtBoxTrack.Text == "0")
                {
                    txtBoxTrack.Text = "";
                }
                txtBoxTrack.Text += lbltext;
            }
            else
            {
                txtBoxTrack.Text += (" " + lbltext + " ");
            }
        }

        /// <summary>
        /// Function is used for calculations, using Mathematical library
        /// </summary>
        /// <param name="firstNum">first number of operation</param>
        /// <param name="secNum">second number of operation</param>
        /// <param name="operatorStr">operation operator</param>
        private void computeRes(decimal firstNum, decimal? secNum, string operatorStr)
        {
            switch (operatorStr)
            {
                case "+":
                    result = ML.plus(firstNum, (decimal)secNum);
                    break;
                case "-":
                    result = ML.minus(firstNum, (decimal)secNum);
                    break;
                case "×":
                    result = ML.multiply(firstNum, (decimal)secNum);
                    break;
                case "÷":
                    result = ML.divide(firstNum, (decimal)secNum);
                    break;
                case "%":
                    result = ML.modulo(firstNum, (decimal)secNum);
                    break;
                case "!":
                    result = ML.factorial(firstNum);
                    break;
                case "^":
                    result = ML.power(firstNum, (decimal)secNum);
                    break;
                case "√":
                    result = ML.root(firstNum, (decimal)secNum);
                    break;
            }
            
        }

        /// <summary>
        /// Fuction handling factorial of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFct_click(object sender, EventArgs e)
        {
            
            //If user is chaining operations, they will be calculated first, then the factorial will be done
            if (operationCount > 1)
            {
                labelSet(true, operatorStr);
                printResult();
            }
            commaCheck();
            //Button press wont work until there is Error message displayed
            if (txtNumBox.Text == "Error")
            {
                return;
            }
            //If Error isnt displayed number is converted from txtNumBox
            else
            {
                firstNum = Convert.ToDecimal(txtNumBox.Text);
            }
            //Prevents doing factorial of 0
            if (firstNum == 0)
            {
                lineClear = true;
                return;
            }
            try
            {
                operatorStr = "!";
                labelSet(false, txtNumBox.Text + operatorStr);
                printResult();
            }
            //If any exception is thrown from the ML library, calculator will print error
            catch (Exception)
            {
                printError();
            }
        }

        /// <summary>
        /// Function handling modulo of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mod_click(object sender, EventArgs e)
        {
            commaCheck();
            //Button press wont work until there is Error message displayed
            if (txtNumBox.Text == "Error")
            {
                return;
            }
            //If Error isnt displayed number is converted from txtNumBox
            else
            {
                firstNum = Convert.ToDecimal(txtNumBox.Text);
                labelSet(false, txtNumBox.Text);
                operatorStr = "%";
                labelSet(true, operatorStr);
                opLast = true;
                lineClear=true;
            }
        }

        /// <summary>
        /// Fuction handling power of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void power_click(object sender, EventArgs e)
        {
            commaCheck();
            //Button press wont work until there is Error message displayed
            if (txtNumBox.Text == "Error")
            {
                return;
            }
            //If Error isnt displayed number is converted from txtNumBox
            else
            {
                firstNum = Convert.ToDecimal(txtNumBox.Text);
                labelSet(false, txtNumBox.Text);
                operatorStr = "^";
                labelSet(true, operatorStr);
                opLast = true;
                lineClear = true;
            }

        }
        
        /// <summary>
        /// Fuction handling root of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void root_click(object sender, EventArgs e)
        {
            if (operationCount > 1)
            {
                labelSet(true, operatorStr);
                printResult();
            }
            commaCheck();
            //Button press wont work until there is Error message displayed
            if (txtNumBox.Text == "Error")
            {
                return;
            }
            //If Error isnt displayed number is converted from txtNumBox
            else
            {
               
                if (operationCount == 0)
                {
                    firstNum = Convert.ToDecimal(txtNumBox.Text);
                }
                operatorStr = "√";
                //Console.WriteLine(firstNum);
                labelSet(true, operatorStr + firstNum);
                opLast = true;
                lineClear = true;
            }
        }

        /// <summary>
        /// Fuction handling "=" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eql_click(object sender, EventArgs e)
        {
            if (!opLast && !eqLast)
            {
                switch (operatorStr)
                {
                    case "+":
                    case "-":
                    case "×":
                    case "÷":
                        if (operationCount >= 1)
                        {
                            if (operationCount >= 2)
                            {
                                labelSet(true, operatorStr);
                            }
                            try
                            {
                                printResult();
                                eqLast = true;

                            }
                            catch (Exception)
                            {
                                printError();
                            }

                        }
                        break;
                    case "%":
                        try
                        {
                            printResult();
                            eqLast = true;
                        }
                        catch (Exception)
                        {
                            printError();
                        }
                        break;
                    case "^":
                        try
                        {
                            printResult();
                            eqLast = true;
                        }
                        catch (Exception)
                        {
                            printError();
                        }
                        break;
                    case "√":
                        try
                        {
                            
                            printResult();
                            eqLast = true;
                        }
                        catch (Exception)
                        {
                            printError();
                        }
                        break;
                }
            }
        }
        
        /// <summary>
        /// Function for printing result
        /// </summary>
        private void printResult()
        {
            //Without this condition, the number left in the txtNumBox would be printed behind the factorial in the txtTrackBox
            if (operatorStr != "!")
            {
                if(operatorStr != "√")
                {
                    labelSet(false, txtNumBox.Text);
                }
                else
                {
                    txtBoxTrack.Clear();
                    labelSet(false, txtNumBox.Text + operatorStr + firstNum);
                }
            }
            labelSet(true, "=");
            secNum = Convert.ToDecimal(txtNumBox.Text);
            computeRes(firstNum, secNum, operatorStr);
            trackClear = true;
            operatorStr = "";
            operationCount = 0;
            lineClear = true;
            firstNum = result;
            txtNumBox.Text = result.ToString();
        }
        
        /// <summary>
        /// Function for checking if the last input character before operation was a comma
        /// </summary>
        private void commaCheck()
        {
            if (commaLast)
            {
                txtNumBox.Text += "0";
                commaLast = false;
            }
        }
        private void help_Click(object sender, EventArgs e)
        {
            //TODO help
        }
    }
}