﻿using System;
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
//3. napr 1+1=2 a nasledne spamovanie + robi mocniny (pravdepodobne)
//4. 0 + nieco po stlaceni = nevypise vysledok treba 2x stlacit znamienko a potom = a vypise
//5.. po fucktoriale po prepisani cisla sa neberie znamienko

namespace Calculator
{
    public partial class CalculatorWindow : Form
    {
        bool lineClear = true; // true - txtNumBox needs to be cleared
        bool eqLast = false; // true - last pressed button is equation
        bool opLast = false; // true - last pressed button is operation button
        bool trackClear = false; // true - txtTrackBox needs to be cleared
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
        /// Event click method that prints comma into textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertComma_Click(object sender, EventArgs e)
        {
            if (!txtNumBox.Text.Contains(","))
            {
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

        /* zakomentovane pre istotu, funkcia vyssie je globalne na vsetky cisla
        private void insert2_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "2";
            opLast = false;
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
        private void insert3_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "3";
            opLast = false;
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
        private void insert4_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "4";
            opLast = false;
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
        private void insert5_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "5";
            opLast = false;
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
        private void insert6_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "6";
            opLast = false;
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
        private void insert7_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "7";
            opLast = false;

            if (trackClear)
            {
                txtBoxTrack.Clear();
                trackClear = false;
            }
            if (eqLast)
            {
                firstNum = 0;
                eqLast= false;
            }
        }
        private void insert8_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "8";
            opLast = false;
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
        private void insert9_click(object sender, EventArgs e)
        {
            if (lineClear)
            {
                txtNumBox.Clear();
                lineClear = false;
            }
            txtNumBox.Text += "9";
            opLast = false;
            if (trackClear)
            {
                txtBoxTrack.Clear();
            }
            if (eqLast)
            {
                firstNum = 0;
                eqLast = false;
            }
        }
        private void insert0_click(object sender, EventArgs e)
        {
            if (!lineClear)
            {
                txtNumBox.Text += "0";
                opLast = false;
            }else if(lineClear && result != 0)
            {
                txtNumBox.Clear();
                txtNumBox.Text += "0";
                lineClear = false;
            }

            if (trackClear)
            {
                txtBoxTrack.Clear();
                trackClear = false;
            }
        }

        */

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
                    firstNum = 0;
                    txtNumBox.Text = "0";
                }
                if (firstNum == 0) //first operation
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
                        computeRes(result, Convert.ToDecimal(txtNumBox.Text), operatorStr);
                        labelSet(true, operatorStr);
                        labelSet(false, secNum.ToString());
                        operatorStr = opButton.Text;
                        firstNum = result;
                    }
                    else // chaining two operations
                    {
                        labelSet(false, txtNumBox.Text);
                        computeRes(firstNum, Convert.ToDecimal(txtNumBox.Text), operatorStr);
                        operatorStr = opButton.Text;
                        firstNum = result;
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
        private void computeRes(decimal firstNum, decimal secNum, string operatorStr)
        {
            switch (operatorStr)
            {
                case "+":
                    result = ML.plus(firstNum, secNum);
                    break;
                case "-":
                    if (secNum != 0)
                    {
                        result = ML.minus(firstNum, secNum);
                        txtNumBox.Text = result.ToString();
                        operatorStr = "";
                        lineClear = true;
                    }
                    else
                    {
                        btnCE.PerformClick();
                        txtNumBox.Text = "Chyba";
                    }
                    break;
                case "×":
                    result = ML.multiply(firstNum, secNum);
                    break;
                case "÷":
                    result = ML.divide(firstNum, secNum);
                    break;
            }
            if (operatorStr != "-")
            {
                txtNumBox.Text = result.ToString();
                operatorStr = "";
                lineClear = true;
            }
        }

        /// <summary>
        /// Fuction handling factorial of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFct_click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDecimal(txtNumBox.Text);
            if (firstNum == 0)
            {
                lineClear = true;
                return;
            }
            try
            {

                result = ML.factorial(firstNum);
                txtNumBox.Text = result.ToString();
                firstNum = result;
                eqLast = true;
                //lineClear = true;

            }
            catch (Exception)
            {
                txtNumBox.Text = "Error";
                lineClear = true;

            }

        }

        /// <summary>
        /// Fuction handling power of number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void power_click(object sender, EventArgs e)
        {

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
                if (operatorStr != "sqr" && operatorStr != "fact" && operatorStr != "sqrt")
                {
                    if (firstNum != 0)
                    {
                        if (operationCount >= 2)
                        {
                            labelSet(true, operatorStr);
                        }
                        labelSet(false, txtNumBox.Text);
                        secNum = Convert.ToDecimal(txtNumBox.Text);
                        labelSet(true, "=");
                        computeRes(firstNum, secNum, operatorStr);
                        trackClear = true;
                        operatorStr = "";
                        operationCount = 0;
                        eqLast = true;
                        firstNum = result;
                    }
                }
                else
                {
                    //TODO pre zvysne funkcie
                }
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            //TODO help
        }
    }
}