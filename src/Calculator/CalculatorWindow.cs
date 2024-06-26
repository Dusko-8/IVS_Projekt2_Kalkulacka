﻿using MathematicaLibraryIVS;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;


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
        /// 
        bool commaLast = false;
        decimal firstNum = 0;
        decimal secNum = 0;
        decimal result = 0;
        int operationCount = 0;
        string operatorStr;
        string nextOperatorStr;
        List<decimal> numList = new List<decimal>();
        List<string> operatorList = new List<string>();

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

            if (lineClear) // clears line for new input
            {
                txtNumBox.Clear();
                lineClear = false;
            }

            if (!commaLast && opButton.Text == "0" && txtNumBox.Text == "0") //Prevents spamming 0
            {
                return;
            }
            else
            {
                txtNumBox.Text += opButton.Text;
                opLast = false;
            }

            if (trackClear) //clears track box, before new calculation
            {
                txtBoxTrack.Clear();
                trackClear = false;
            }
            if (eqLast)
            {
                firstNum = 0;
                eqLast = false;
            }
            commaLast = false;
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
                    if (operatorStr == "+" || operatorStr == "-")
                    {
                        numList.Add(firstNum);
                        operatorList.Add(operatorStr);
                    }
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
                        nextOperatorStr = opButton.Text;
                        if (numList.Count == 1 && (nextOperatorStr == "×" || nextOperatorStr == "÷"))
                        {
                            numList[0] = result;
                            operatorList[0] = operatorStr;
                            numList.Add(Convert.ToDecimal(txtNumBox.Text));
                            operatorList.Add(nextOperatorStr);
                            labelSet(true, operatorStr);
                            labelSet(false, txtNumBox.Text);
                            operatorStr = nextOperatorStr;

                        }
                        else if (numList.Count == 2 && ((nextOperatorStr == "×" || nextOperatorStr == "÷") && (operatorList[1] == "×" || operatorList[1] == "÷")))
                        {
                            labelSet(true, operatorStr);
                            labelSet(false, txtNumBox.Text);

                            computeRes(numList[1], Convert.ToDecimal(txtNumBox.Text), operatorList[1]);
                            numList.RemoveAt(1);
                            numList.Add(result);
                            operatorStr = nextOperatorStr;
                            operatorList.RemoveAt(1);
                            operatorList.Add(nextOperatorStr);
                        }
                        else if (numList.Count == 2 && (nextOperatorStr == "+" || nextOperatorStr == "-"))
                        {
                            labelSet(true, operatorStr);
                            labelSet(false, txtNumBox.Text);

                            computeRes(numList[1], Convert.ToDecimal(txtNumBox.Text), operatorList[1]);
                            computeRes(numList[0], result, operatorList[0]);
                            numList.Clear();
                            operatorList.Clear();
                            operatorStr = nextOperatorStr;

                        }
                        else if ((operatorStr == "+" || operatorStr == "-") && (nextOperatorStr == "×" || nextOperatorStr == "÷"))
                        {
                            labelSet(true, operatorStr);
                            labelSet(false, txtNumBox.Text);

                            numList.Add(result);
                            operatorList.Add(operatorStr);
                            numList.Add(Convert.ToDecimal(txtNumBox.Text));
                            operatorList.Add(nextOperatorStr);
                            operatorStr = nextOperatorStr;
                        }
                        else
                        {
                            secNum = Convert.ToDecimal(txtNumBox.Text);
                            computeRes(result, secNum, operatorStr);

                            labelSet(true, operatorStr);
                            labelSet(false, secNum.ToString());

                            operatorStr = nextOperatorStr;
                        }
                        firstNum = result;
                        //printing the result
                        txtNumBox.Text = result.ToString();
                        opLast = true;
                    }
                    else // chaining two operations
                    {
                        labelSet(false, txtNumBox.Text);
                        nextOperatorStr = opButton.Text;
                        if (numList.Count == 1 && (nextOperatorStr == "×" || nextOperatorStr == "÷"))
                        {
                            numList.Add(Convert.ToDecimal(txtNumBox.Text));
                            operatorStr = nextOperatorStr;
                            operatorList.Add(nextOperatorStr);
                        }
                        else
                        {
                            computeRes(firstNum, Convert.ToDecimal(txtNumBox.Text), operatorStr);
                            operatorStr = nextOperatorStr;
                            firstNum = result;
                            //printing the result
                            txtNumBox.Text = result.ToString();
                        }

                        opLast = true;
                    }
                    lineClear = true;
                }

            }
        }

        /// <summary>
        /// Fuction sets track box 
        /// </summary>
        /// <param name="type">If type is true, fuction uses format for operation. If type is false,function uses format for numbers</param>
        /// <param name="lbltext">string(number or operation) to be set in box</param>
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
        /// <param name="secNum">second number of operation (can be null if not needed)</param>
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
            if (operationCount > 0) //If user is chaining operations, they will be calculated first, then the factorial will be done
            {
                labelSet(true, operatorStr);
                printResult();
            }
            commaCheck();

            if (txtNumBox.Text == "Error") //Button press wont work until there is Error message displayed
            {
                return;
            }

            else //If Error isnt displayed number is converted from txtNumBox
            {
                firstNum = Convert.ToDecimal(txtNumBox.Text);
            }

            if (firstNum == 0) //Prevents doing factorial of 0
            {
                lineClear = true;
                return;
            }

            try
            {
                operatorStr = "!";
                labelSet(false, txtNumBox.Text + operatorStr);
                printResult();
                eqLast = true;
                operationCount++;
            }

            catch (Exception) //If any exception is thrown from the ML library, calculator will print error
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
            if (!opLast)
            {
                if (operationCount == 1)
                {
                    printResult();
                }
                else if (operationCount >= 2)
                {
                    labelSet(true, operatorStr);
                    printResult();
                }
                commaCheck();

                if (txtNumBox.Text == "Error") //Button press wont work until there is Error message displayed
                {
                    return;
                }
                else
                {
                    if (operationCount == 0)
                    {
                        firstNum = Convert.ToDecimal(txtNumBox.Text);
                    }
                    labelSet(false, txtNumBox.Text);
                    operatorStr = "%";
                    labelSet(true, operatorStr);
                    opLast = true;
                    lineClear = true;
                    operationCount++;
                }
            }
        }

        /// <summary>
        /// Fuction handling power of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void power_click(object sender, EventArgs e)
        {
            if (!opLast)
            {
                if (operationCount == 1)
                {
                    printResult();
                }
                else if (operationCount >= 2)
                {
                    labelSet(true, operatorStr);
                    printResult();
                }
                commaCheck();

                if (txtNumBox.Text == "Error") //Button press wont work until there is Error message displayed
                {
                    return;
                }
                else //If Error isnt displayed number is converted from txtNumBox
                {
                    if (operationCount == 0)
                    {
                        firstNum = Convert.ToDecimal(txtNumBox.Text);
                    }
                    labelSet(false, txtNumBox.Text);
                    operatorStr = "^";
                    labelSet(false, operatorStr);
                    opLast = true;
                    operationCount++;
                    lineClear = true;
                }
            }


        }

        /// <summary>
        /// Fuction handling root of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void root_click(object sender, EventArgs e)
        {
            if (!opLast)
            {
                if (operationCount == 1)
                {
                    printResult();
                }
                else if (operationCount >= 2)
                {
                    labelSet(true, operatorStr);
                    printResult();
                }
                commaCheck();

                if (txtNumBox.Text == "Error") //Button press wont work until there is Error message displayed
                {
                    return;
                }

                else //If Error isnt displayed number is converted from txtNumBox
                {

                    if (operationCount == 0)
                    {
                        firstNum = Convert.ToDecimal(txtNumBox.Text);
                    }
                    operatorStr = "√";
                    labelSet(true, operatorStr + firstNum);
                    opLast = true;
                    eqLast = false;
                    lineClear = true;
                    operationCount++;
                }
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

            switch (operatorStr) //Formatting of special prints
            {
                case "√":
                    txtBoxTrack.Clear();
                    labelSet(false, txtNumBox.Text + operatorStr + firstNum);
                    break;
                case "^":
                    txtBoxTrack.Clear();
                    labelSet(false, firstNum + operatorStr + txtNumBox.Text);
                    break;
                case "!":
                    txtBoxTrack.Clear();
                    labelSet(false, firstNum + operatorStr);
                    break;
                case "%":
                    txtBoxTrack.Clear();
                    labelSet(false, firstNum + operatorStr + txtNumBox.Text);
                    break;
                default:
                    labelSet(false, txtNumBox.Text);
                    break;
            }

            labelSet(true, "=");
            secNum = Convert.ToDecimal(txtNumBox.Text); 
            if (numList.Count == 2)
            {
                computeRes(numList[1], secNum, operatorList[1]);
                firstNum = numList[0];
                secNum = result;
                operatorStr = operatorList[0];

            }
            computeRes(firstNum, secNum, operatorStr);
            trackClear = true;
            operatorStr = "";
            nextOperatorStr = "";
            operationCount = 0;
            numList.Clear();
            operatorList.Clear();
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
                txtNumBox.Text = txtNumBox.Text.Remove(txtNumBox.Text.Length - 1);
                commaLast = false;
            }

        }

        /// <summary>
        /// Function handling opening pdf file containing user manual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void help_Click(object sender, EventArgs e)
        {
            String file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\user_manual.pdf";
            System.IO.File.WriteAllBytes(file, global::Calculator.Properties.Resources.user_manual);
            System.Diagnostics.Process.Start(file);
        }

        /// <summary>
        /// Function handling key presses on keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorWindow_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    btn0.PerformClick();
                    break;
                case Keys.NumPad1:
                    btn1.PerformClick();
                    break;
                case Keys.NumPad2:
                    btn2.PerformClick();
                    break;
                case Keys.NumPad3:
                    btn3.PerformClick();
                    break;
                case Keys.NumPad4:
                    btn4.PerformClick();
                    break;
                case Keys.NumPad5:
                    btn5.PerformClick();
                    break;
                case Keys.NumPad6:
                    btn6.PerformClick();
                    break;
                case Keys.NumPad7:
                    btn7.PerformClick();
                    break;
                case Keys.NumPad8:
                    btn8.PerformClick();
                    break;
                case Keys.NumPad9:
                    btn9.PerformClick();
                    break;
                case Keys.Add:
                    btnAdd.PerformClick();
                    break;
                case Keys.Subtract:
                    btnMin.PerformClick();
                    break;
                case Keys.Multiply:
                    btnMul.PerformClick();
                    break;
                case Keys.Divide:
                    btnDiv.PerformClick();
                    break;
                case Keys.Decimal:
                    btnComma.PerformClick();
                    break;


            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            AboutWindow About = new AboutWindow();
            About.ShowDialog();
        }
    }
}