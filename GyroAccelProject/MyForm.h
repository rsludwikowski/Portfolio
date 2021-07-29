#pragma once
#include <iostream>
#include <Windows.h>
#include <string>
#include <iomanip>
#include <sstream>
#include <math.h>
#include <msclr\marshal_cppstd.h>
#include "MovingObj.h"


using namespace System;
using namespace System::Windows::Forms;
using namespace System::IO::Ports;
using std::string;
using std::stringstream;



bool opened = true;

int to_count;

bool IsOpen = false;

bool openClick = false;


inline string dec2hex(int decim);
short int hex2dec(string hex);

float X_Accel = 0;
float Y_Accel = 0;
float Z_Accel = 0;

float X_Gyro = 0;
float Y_Gyro = 0;
float Z_Gyro = 0;


MovingObj myObj;


float X_Temp = 0;
float Y_Temp = 0;
float Z_Temp = 0;
float B_Temp = 0;

int maxChart = 2000;







string portName;

int counter = 0;





namespace GuiGyro {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Windows::Forms;
	using namespace System::IO::Ports;
	//using std::string;
	//using std::stringstream;


	
	string rate;
	

	


	/// <summary>
	/// Podsumowanie informacji o MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{

		

		

	
	public:
		
		void openPorts();
		

		
	
		

		

		

	private: System::Windows::Forms::Timer^ timer1;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::TextBox^ textBox1;
	private: System::Windows::Forms::Button^ CLOSE;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::TextBox^ xAccelTextBox;
	private: System::Windows::Forms::TextBox^ yAccelTextBox;
	private: System::Windows::Forms::TextBox^ zAccelTextBox;
	private: System::Windows::Forms::TextBox^ zGyroTextBox;
	private: System::Windows::Forms::TextBox^ yGyroTextBox;
	private: System::Windows::Forms::TextBox^ xGyroTextBox;
	private: System::Windows::Forms::Label^ label6;
	private: System::Windows::Forms::Label^ label7;
	private: System::Windows::Forms::Label^ label8;
	private: System::Windows::Forms::TextBox^ zTempTextBox;
	private: System::Windows::Forms::TextBox^ yTempTextBox;
	private: System::Windows::Forms::TextBox^ xTempTextBox;
	private: System::Windows::Forms::Label^ label9;
	private: System::Windows::Forms::Label^ label10;
	private: System::Windows::Forms::Label^ label11;
	private: System::Windows::Forms::TextBox^ bTempTextBox;
	private: System::Windows::Forms::Label^ label12;
	private: System::Windows::Forms::DataVisualization::Charting::Chart^ chart2;
	private: System::Windows::Forms::TextBox^ YawBox;

	private: System::Windows::Forms::TextBox^ RollBox;

	private: System::Windows::Forms::TextBox^ PitchBox;

	private: System::Windows::Forms::Label^ label13;
	private: System::Windows::Forms::Label^ label14;
	private: System::Windows::Forms::Label^ label15;
	private: System::Windows::Forms::TextBox^ textBoxQ2;

	private: System::Windows::Forms::TextBox^ textBoxQ1;

	private: System::Windows::Forms::TextBox^ textBoxQ0;

	private: System::Windows::Forms::Label^ label16;
	private: System::Windows::Forms::Label^ label17;
	private: System::Windows::Forms::Label^ label18;
	private: System::Windows::Forms::TextBox^ textBoxQ3;

	private: System::Windows::Forms::Label^ label19;
	private: System::Windows::Forms::Button^ Calibrate_Button;
	private: System::Windows::Forms::TextBox^ calib_textbox;
	private: System::Windows::Forms::Label^ label20;
	private: System::Windows::Forms::TextBox^ textBoxX_zero;
	private: System::Windows::Forms::TextBox^ textBoxY_zero;
	private: System::Windows::Forms::TextBox^ textBoxZ_zero;
	private: System::Windows::Forms::Label^ label21;
	private: System::Windows::Forms::Label^ label22;
	private: System::Windows::Forms::Label^ label23;





	private: System::Windows::Forms::DataVisualization::Charting::Chart^ chart1;



	public:

		
		
		


		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: W tym miejscu dodaj kod konstruktora

			array<String^>^ ports = SerialPort().GetPortNames();

			for each (String ^ s in ports)
			{
				comboBox1->Items->Add(s->Clone());
			}

			opened = true;

			this->timer1->Start();
			progressBar1->Minimum = 0;
			progressBar1->Maximum = 1;
			progressBar1->Value = 0;
			int b;
			
			chart1->ChartAreas[0]->AxisX->Maximum = maxChart;
			chart2->ChartAreas[0]->AxisX->Maximum = maxChart;
			
			chart1->ChartAreas[0]->AxisX->Minimum = 0;
			chart2->ChartAreas[0]->AxisX->Minimum = 0;

			
		}

	protected:
		/// <summary>
		/// Wyczyœæ wszystkie u¿ywane zasoby.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::ComboBox^ comboBox1;
	protected:
	private: System::Windows::Forms::Button^ OpenPortButton;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::ProgressBar^ progressBar1;
	private: System::ComponentModel::IContainer^ components;

	private:
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Metoda wymagana do obs³ugi projektanta — nie nale¿y modyfikowaæ
		/// jej zawartoœci w edytorze kodu.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::Windows::Forms::DataVisualization::Charting::ChartArea^ chartArea3 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
			System::Windows::Forms::DataVisualization::Charting::Legend^ legend3 = (gcnew System::Windows::Forms::DataVisualization::Charting::Legend());
			System::Windows::Forms::DataVisualization::Charting::Series^ series7 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^ series8 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^ series9 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::ChartArea^ chartArea4 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
			System::Windows::Forms::DataVisualization::Charting::Legend^ legend4 = (gcnew System::Windows::Forms::DataVisualization::Charting::Legend());
			System::Windows::Forms::DataVisualization::Charting::Series^ series10 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^ series11 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^ series12 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->OpenPortButton = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->progressBar1 = (gcnew System::Windows::Forms::ProgressBar());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->CLOSE = (gcnew System::Windows::Forms::Button());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->xAccelTextBox = (gcnew System::Windows::Forms::TextBox());
			this->yAccelTextBox = (gcnew System::Windows::Forms::TextBox());
			this->zAccelTextBox = (gcnew System::Windows::Forms::TextBox());
			this->zGyroTextBox = (gcnew System::Windows::Forms::TextBox());
			this->yGyroTextBox = (gcnew System::Windows::Forms::TextBox());
			this->xGyroTextBox = (gcnew System::Windows::Forms::TextBox());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->zTempTextBox = (gcnew System::Windows::Forms::TextBox());
			this->yTempTextBox = (gcnew System::Windows::Forms::TextBox());
			this->xTempTextBox = (gcnew System::Windows::Forms::TextBox());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->label11 = (gcnew System::Windows::Forms::Label());
			this->bTempTextBox = (gcnew System::Windows::Forms::TextBox());
			this->label12 = (gcnew System::Windows::Forms::Label());
			this->chart1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			this->chart2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			this->YawBox = (gcnew System::Windows::Forms::TextBox());
			this->RollBox = (gcnew System::Windows::Forms::TextBox());
			this->PitchBox = (gcnew System::Windows::Forms::TextBox());
			this->label13 = (gcnew System::Windows::Forms::Label());
			this->label14 = (gcnew System::Windows::Forms::Label());
			this->label15 = (gcnew System::Windows::Forms::Label());
			this->textBoxQ2 = (gcnew System::Windows::Forms::TextBox());
			this->textBoxQ1 = (gcnew System::Windows::Forms::TextBox());
			this->textBoxQ0 = (gcnew System::Windows::Forms::TextBox());
			this->label16 = (gcnew System::Windows::Forms::Label());
			this->label17 = (gcnew System::Windows::Forms::Label());
			this->label18 = (gcnew System::Windows::Forms::Label());
			this->textBoxQ3 = (gcnew System::Windows::Forms::TextBox());
			this->label19 = (gcnew System::Windows::Forms::Label());
			this->Calibrate_Button = (gcnew System::Windows::Forms::Button());
			this->calib_textbox = (gcnew System::Windows::Forms::TextBox());
			this->label20 = (gcnew System::Windows::Forms::Label());
			this->textBoxX_zero = (gcnew System::Windows::Forms::TextBox());
			this->textBoxY_zero = (gcnew System::Windows::Forms::TextBox());
			this->textBoxZ_zero = (gcnew System::Windows::Forms::TextBox());
			this->label21 = (gcnew System::Windows::Forms::Label());
			this->label22 = (gcnew System::Windows::Forms::Label());
			this->label23 = (gcnew System::Windows::Forms::Label());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart2))->BeginInit();
			this->SuspendLayout();
			// 
			// comboBox1
			// 
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Location = System::Drawing::Point(90, 101);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(121, 21);
			this->comboBox1->TabIndex = 0;
			this->comboBox1->DropDown += gcnew System::EventHandler(this, &MyForm::comboBox1_SelectedIndexChanged);
			// 
			// OpenPortButton
			// 
			this->OpenPortButton->Location = System::Drawing::Point(90, 139);
			this->OpenPortButton->Name = L"OpenPortButton";
			this->OpenPortButton->Size = System::Drawing::Size(121, 23);
			this->OpenPortButton->TabIndex = 1;
			this->OpenPortButton->Text = L"OPEN";
			this->OpenPortButton->UseVisualStyleBackColor = true;
			this->OpenPortButton->Click += gcnew System::EventHandler(this, &MyForm::OpenPortButton_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(90, 82);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(57, 13);
			this->label1->TabIndex = 2;
			this->label1->Text = L"COM ports";
			// 
			// progressBar1
			// 
			this->progressBar1->Location = System::Drawing::Point(90, 168);
			this->progressBar1->Name = L"progressBar1";
			this->progressBar1->Size = System::Drawing::Size(121, 23);
			this->progressBar1->TabIndex = 3;
			// 
			// timer1
			// 
			this->timer1->Interval = 1;
			this->timer1->Tick += gcnew System::EventHandler(this, &MyForm::timer1_Tick);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(226, 82);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(55, 13);
			this->label2->TabIndex = 4;
			this->label2->Text = L"BaudRate";
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(229, 101);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(100, 20);
			this->textBox1->TabIndex = 5;
			this->textBox1->Text = L"57600";
			// 
			// CLOSE
			// 
			this->CLOSE->Location = System::Drawing::Point(90, 198);
			this->CLOSE->Name = L"CLOSE";
			this->CLOSE->Size = System::Drawing::Size(121, 23);
			this->CLOSE->TabIndex = 6;
			this->CLOSE->Text = L"CloseButton";
			this->CLOSE->UseVisualStyleBackColor = true;
			this->CLOSE->Click += gcnew System::EventHandler(this, &MyForm::CLOSE_Click);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(40, 267);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(47, 13);
			this->label3->TabIndex = 7;
			this->label3->Text = L"X_Accel";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(40, 293);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(47, 13);
			this->label4->TabIndex = 8;
			this->label4->Text = L"Y_Accel";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(40, 319);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(47, 13);
			this->label5->TabIndex = 9;
			this->label5->Text = L"Z_Accel";
			// 
			// xAccelTextBox
			// 
			this->xAccelTextBox->Location = System::Drawing::Point(90, 264);
			this->xAccelTextBox->Name = L"xAccelTextBox";
			this->xAccelTextBox->Size = System::Drawing::Size(121, 20);
			this->xAccelTextBox->TabIndex = 10;
			// 
			// yAccelTextBox
			// 
			this->yAccelTextBox->Location = System::Drawing::Point(90, 290);
			this->yAccelTextBox->Name = L"yAccelTextBox";
			this->yAccelTextBox->Size = System::Drawing::Size(121, 20);
			this->yAccelTextBox->TabIndex = 11;
			// 
			// zAccelTextBox
			// 
			this->zAccelTextBox->Location = System::Drawing::Point(90, 316);
			this->zAccelTextBox->Name = L"zAccelTextBox";
			this->zAccelTextBox->Size = System::Drawing::Size(121, 20);
			this->zAccelTextBox->TabIndex = 12;
			// 
			// zGyroTextBox
			// 
			this->zGyroTextBox->Location = System::Drawing::Point(90, 407);
			this->zGyroTextBox->Name = L"zGyroTextBox";
			this->zGyroTextBox->Size = System::Drawing::Size(121, 20);
			this->zGyroTextBox->TabIndex = 18;
			// 
			// yGyroTextBox
			// 
			this->yGyroTextBox->Location = System::Drawing::Point(90, 381);
			this->yGyroTextBox->Name = L"yGyroTextBox";
			this->yGyroTextBox->Size = System::Drawing::Size(121, 20);
			this->yGyroTextBox->TabIndex = 17;
			// 
			// xGyroTextBox
			// 
			this->xGyroTextBox->Location = System::Drawing::Point(90, 355);
			this->xGyroTextBox->Name = L"xGyroTextBox";
			this->xGyroTextBox->Size = System::Drawing::Size(121, 20);
			this->xGyroTextBox->TabIndex = 16;
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(40, 410);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(42, 13);
			this->label6->TabIndex = 15;
			this->label6->Text = L"Z_Gyro";
			// 
			// label7
			// 
			this->label7->AutoSize = true;
			this->label7->Location = System::Drawing::Point(40, 384);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(42, 13);
			this->label7->TabIndex = 14;
			this->label7->Text = L"Y_Gyro";
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->Location = System::Drawing::Point(40, 358);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(42, 13);
			this->label8->TabIndex = 13;
			this->label8->Text = L"X_Gyro";
			// 
			// zTempTextBox
			// 
			this->zTempTextBox->Location = System::Drawing::Point(90, 505);
			this->zTempTextBox->Name = L"zTempTextBox";
			this->zTempTextBox->Size = System::Drawing::Size(121, 20);
			this->zTempTextBox->TabIndex = 24;
			// 
			// yTempTextBox
			// 
			this->yTempTextBox->Location = System::Drawing::Point(90, 479);
			this->yTempTextBox->Name = L"yTempTextBox";
			this->yTempTextBox->Size = System::Drawing::Size(121, 20);
			this->yTempTextBox->TabIndex = 23;
			// 
			// xTempTextBox
			// 
			this->xTempTextBox->Location = System::Drawing::Point(90, 453);
			this->xTempTextBox->Name = L"xTempTextBox";
			this->xTempTextBox->Size = System::Drawing::Size(121, 20);
			this->xTempTextBox->TabIndex = 22;
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->Location = System::Drawing::Point(40, 508);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(47, 13);
			this->label9->TabIndex = 21;
			this->label9->Text = L"Z_Temp";
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Location = System::Drawing::Point(40, 482);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(47, 13);
			this->label10->TabIndex = 20;
			this->label10->Text = L"Y_Temp";
			// 
			// label11
			// 
			this->label11->AutoSize = true;
			this->label11->Location = System::Drawing::Point(40, 456);
			this->label11->Name = L"label11";
			this->label11->Size = System::Drawing::Size(47, 13);
			this->label11->TabIndex = 19;
			this->label11->Text = L"X_Temp";
			// 
			// bTempTextBox
			// 
			this->bTempTextBox->Location = System::Drawing::Point(90, 531);
			this->bTempTextBox->Name = L"bTempTextBox";
			this->bTempTextBox->Size = System::Drawing::Size(121, 20);
			this->bTempTextBox->TabIndex = 26;
			// 
			// label12
			// 
			this->label12->AutoSize = true;
			this->label12->Location = System::Drawing::Point(19, 534);
			this->label12->Name = L"label12";
			this->label12->Size = System::Drawing::Size(68, 13);
			this->label12->TabIndex = 25;
			this->label12->Text = L"Board_Temp";
			// 
			// chart1
			// 
			chartArea3->Name = L"ChartArea1";
			this->chart1->ChartAreas->Add(chartArea3);
			legend3->Name = L"Legend1";
			this->chart1->Legends->Add(legend3);
			this->chart1->Location = System::Drawing::Point(369, 19);
			this->chart1->Name = L"chart1";
			series7->ChartArea = L"ChartArea1";
			series7->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series7->Legend = L"Legend1";
			series7->Name = L"X";
			series8->ChartArea = L"ChartArea1";
			series8->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series8->Legend = L"Legend1";
			series8->Name = L"Y";
			series9->ChartArea = L"ChartArea1";
			series9->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series9->Legend = L"Legend1";
			series9->Name = L"Z";
			this->chart1->Series->Add(series7);
			this->chart1->Series->Add(series8);
			this->chart1->Series->Add(series9);
			this->chart1->Size = System::Drawing::Size(586, 287);
			this->chart1->TabIndex = 10;
			this->chart1->Text = L"chart1";
			// 
			// chart2
			// 
			chartArea4->Name = L"ChartArea1";
			this->chart2->ChartAreas->Add(chartArea4);
			legend4->Name = L"Legend1";
			this->chart2->Legends->Add(legend4);
			this->chart2->Location = System::Drawing::Point(369, 312);
			this->chart2->Name = L"chart2";
			series10->ChartArea = L"ChartArea1";
			series10->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series10->Legend = L"Legend1";
			series10->Name = L"X";
			series11->ChartArea = L"ChartArea1";
			series11->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series11->Legend = L"Legend1";
			series11->Name = L"Y";
			series12->ChartArea = L"ChartArea1";
			series12->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series12->Legend = L"Legend1";
			series12->Name = L"Z";
			this->chart2->Series->Add(series10);
			this->chart2->Series->Add(series11);
			this->chart2->Series->Add(series12);
			this->chart2->Size = System::Drawing::Size(586, 300);
			this->chart2->TabIndex = 27;
			this->chart2->Text = L"chart2";
			// 
			// YawBox
			// 
			this->YawBox->Location = System::Drawing::Point(1082, 34);
			this->YawBox->Name = L"YawBox";
			this->YawBox->Size = System::Drawing::Size(121, 20);
			this->YawBox->TabIndex = 33;
			this->YawBox->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox2_TextChanged);
			// 
			// RollBox
			// 
			this->RollBox->Location = System::Drawing::Point(1082, 88);
			this->RollBox->Name = L"RollBox";
			this->RollBox->Size = System::Drawing::Size(121, 20);
			this->RollBox->TabIndex = 32;
			this->RollBox->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox3_TextChanged);
			// 
			// PitchBox
			// 
			this->PitchBox->Location = System::Drawing::Point(1082, 62);
			this->PitchBox->Name = L"PitchBox";
			this->PitchBox->Size = System::Drawing::Size(121, 20);
			this->PitchBox->TabIndex = 31;
			this->PitchBox->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox4_TextChanged);
			// 
			// label13
			// 
			this->label13->AutoSize = true;
			this->label13->Location = System::Drawing::Point(1032, 37);
			this->label13->Name = L"label13";
			this->label13->Size = System::Drawing::Size(26, 13);
			this->label13->TabIndex = 30;
			this->label13->Text = L"yaw";
			this->label13->Click += gcnew System::EventHandler(this, &MyForm::label13_Click);
			// 
			// label14
			// 
			this->label14->AutoSize = true;
			this->label14->Location = System::Drawing::Point(1032, 91);
			this->label14->Name = L"label14";
			this->label14->Size = System::Drawing::Size(25, 13);
			this->label14->TabIndex = 29;
			this->label14->Text = L"Roll";
			this->label14->Click += gcnew System::EventHandler(this, &MyForm::label14_Click);
			// 
			// label15
			// 
			this->label15->AutoSize = true;
			this->label15->Location = System::Drawing::Point(1032, 65);
			this->label15->Name = L"label15";
			this->label15->Size = System::Drawing::Size(31, 13);
			this->label15->TabIndex = 28;
			this->label15->Text = L"Pitch";
			this->label15->Click += gcnew System::EventHandler(this, &MyForm::label15_Click);
			// 
			// textBoxQ2
			// 
			this->textBoxQ2->Location = System::Drawing::Point(1082, 223);
			this->textBoxQ2->Name = L"textBoxQ2";
			this->textBoxQ2->Size = System::Drawing::Size(121, 20);
			this->textBoxQ2->TabIndex = 39;
			// 
			// textBoxQ1
			// 
			this->textBoxQ1->Location = System::Drawing::Point(1082, 197);
			this->textBoxQ1->Name = L"textBoxQ1";
			this->textBoxQ1->Size = System::Drawing::Size(121, 20);
			this->textBoxQ1->TabIndex = 38;
			// 
			// textBoxQ0
			// 
			this->textBoxQ0->Location = System::Drawing::Point(1082, 171);
			this->textBoxQ0->Name = L"textBoxQ0";
			this->textBoxQ0->Size = System::Drawing::Size(121, 20);
			this->textBoxQ0->TabIndex = 37;
			// 
			// label16
			// 
			this->label16->AutoSize = true;
			this->label16->Location = System::Drawing::Point(1032, 226);
			this->label16->Name = L"label16";
			this->label16->Size = System::Drawing::Size(21, 13);
			this->label16->TabIndex = 36;
			this->label16->Text = L"Q2";
			// 
			// label17
			// 
			this->label17->AutoSize = true;
			this->label17->Location = System::Drawing::Point(1032, 200);
			this->label17->Name = L"label17";
			this->label17->Size = System::Drawing::Size(21, 13);
			this->label17->TabIndex = 35;
			this->label17->Text = L"Q1";
			// 
			// label18
			// 
			this->label18->AutoSize = true;
			this->label18->Location = System::Drawing::Point(1032, 174);
			this->label18->Name = L"label18";
			this->label18->Size = System::Drawing::Size(21, 13);
			this->label18->TabIndex = 34;
			this->label18->Text = L"Q0";
			// 
			// textBoxQ3
			// 
			this->textBoxQ3->Location = System::Drawing::Point(1082, 249);
			this->textBoxQ3->Name = L"textBoxQ3";
			this->textBoxQ3->Size = System::Drawing::Size(121, 20);
			this->textBoxQ3->TabIndex = 41;
			// 
			// label19
			// 
			this->label19->AutoSize = true;
			this->label19->Location = System::Drawing::Point(1032, 252);
			this->label19->Name = L"label19";
			this->label19->Size = System::Drawing::Size(21, 13);
			this->label19->TabIndex = 40;
			this->label19->Text = L"Q3";
			// 
			// Calibrate_Button
			// 
			this->Calibrate_Button->Location = System::Drawing::Point(1082, 319);
			this->Calibrate_Button->Name = L"Calibrate_Button";
			this->Calibrate_Button->Size = System::Drawing::Size(121, 23);
			this->Calibrate_Button->TabIndex = 42;
			this->Calibrate_Button->Text = L"Calibrate";
			this->Calibrate_Button->UseVisualStyleBackColor = true;
			this->Calibrate_Button->Click += gcnew System::EventHandler(this, &MyForm::Calibrate_Button_Click);
			// 
			// calib_textbox
			// 
			this->calib_textbox->Location = System::Drawing::Point(1082, 403);
			this->calib_textbox->Name = L"calib_textbox";
			this->calib_textbox->Size = System::Drawing::Size(121, 20);
			this->calib_textbox->TabIndex = 43;
			// 
			// label20
			// 
			this->label20->AutoSize = true;
			this->label20->Location = System::Drawing::Point(991, 406);
			this->label20->Name = L"label20";
			this->label20->Size = System::Drawing::Size(85, 13);
			this->label20->TabIndex = 44;
			this->label20->Text = L"Calibration value";
			// 
			// textBoxX_zero
			// 
			this->textBoxX_zero->Location = System::Drawing::Point(1255, 34);
			this->textBoxX_zero->Name = L"textBoxX_zero";
			this->textBoxX_zero->Size = System::Drawing::Size(121, 20);
			this->textBoxX_zero->TabIndex = 45;
			// 
			// textBoxY_zero
			// 
			this->textBoxY_zero->Location = System::Drawing::Point(1255, 60);
			this->textBoxY_zero->Name = L"textBoxY_zero";
			this->textBoxY_zero->Size = System::Drawing::Size(121, 20);
			this->textBoxY_zero->TabIndex = 46;
			// 
			// textBoxZ_zero
			// 
			this->textBoxZ_zero->Location = System::Drawing::Point(1255, 86);
			this->textBoxZ_zero->Name = L"textBoxZ_zero";
			this->textBoxZ_zero->Size = System::Drawing::Size(121, 20);
			this->textBoxZ_zero->TabIndex = 47;
			// 
			// label21
			// 
			this->label21->AutoSize = true;
			this->label21->Location = System::Drawing::Point(1391, 37);
			this->label21->Name = L"label21";
			this->label21->Size = System::Drawing::Size(69, 13);
			this->label21->TabIndex = 48;
			this->label21->Text = L"X Accel Zero";
			// 
			// label22
			// 
			this->label22->AutoSize = true;
			this->label22->Location = System::Drawing::Point(1391, 65);
			this->label22->Name = L"label22";
			this->label22->Size = System::Drawing::Size(69, 13);
			this->label22->TabIndex = 49;
			this->label22->Text = L"Y Accel Zero";
			// 
			// label23
			// 
			this->label23->AutoSize = true;
			this->label23->Location = System::Drawing::Point(1391, 91);
			this->label23->Name = L"label23";
			this->label23->Size = System::Drawing::Size(69, 13);
			this->label23->TabIndex = 50;
			this->label23->Text = L"Z Accel Zero";
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1553, 725);
			this->Controls->Add(this->label23);
			this->Controls->Add(this->label22);
			this->Controls->Add(this->label21);
			this->Controls->Add(this->textBoxZ_zero);
			this->Controls->Add(this->textBoxY_zero);
			this->Controls->Add(this->textBoxX_zero);
			this->Controls->Add(this->label20);
			this->Controls->Add(this->calib_textbox);
			this->Controls->Add(this->Calibrate_Button);
			this->Controls->Add(this->textBoxQ3);
			this->Controls->Add(this->label19);
			this->Controls->Add(this->textBoxQ2);
			this->Controls->Add(this->textBoxQ1);
			this->Controls->Add(this->textBoxQ0);
			this->Controls->Add(this->label16);
			this->Controls->Add(this->label17);
			this->Controls->Add(this->label18);
			this->Controls->Add(this->YawBox);
			this->Controls->Add(this->RollBox);
			this->Controls->Add(this->PitchBox);
			this->Controls->Add(this->label13);
			this->Controls->Add(this->label14);
			this->Controls->Add(this->label15);
			this->Controls->Add(this->chart2);
			this->Controls->Add(this->chart1);
			this->Controls->Add(this->bTempTextBox);
			this->Controls->Add(this->label12);
			this->Controls->Add(this->zTempTextBox);
			this->Controls->Add(this->yTempTextBox);
			this->Controls->Add(this->xTempTextBox);
			this->Controls->Add(this->label9);
			this->Controls->Add(this->label10);
			this->Controls->Add(this->label11);
			this->Controls->Add(this->zGyroTextBox);
			this->Controls->Add(this->yGyroTextBox);
			this->Controls->Add(this->xGyroTextBox);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->label8);
			this->Controls->Add(this->zAccelTextBox);
			this->Controls->Add(this->yAccelTextBox);
			this->Controls->Add(this->xAccelTextBox);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->CLOSE);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->progressBar1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->OpenPortButton);
			this->Controls->Add(this->comboBox1);
			this->Name = L"MyForm";
			this->Text = L"GUIgyroAccel";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &MyForm::MyForm_FormClosing);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart2))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void comboBox1_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e) {

		array<String^>^ ports = SerialPort().GetPortNames();
		comboBox1->Items->Clear();
		for each (String ^ s in ports)
		{
			
			comboBox1->Items->Add(s->Clone());
		}
			
		
	}
	private: System::Void OpenPortButton_Click(System::Object^ sender, System::EventArgs^ e) {

		try
		{
			portName = msclr::interop::marshal_as<std::string>(comboBox1->Text);
			
			openClick = true;
		}
		catch (Exception ^ e)
		{

		}

			
	}
private: System::Void timer1_Tick(System::Object^ sender, System::EventArgs^ e) 
{
	label1->Text = counter.ToString();
	
	if (IsOpen)
	{
		progressBar1->Value = 1;
	}
	else
	{
		progressBar1->Value = 0;
	}

	xAccelTextBox->Text = myObj.X_Accel.ToString();
	yAccelTextBox->Text = myObj.Y_Accel.ToString();
	zAccelTextBox->Text = myObj.Z_Accel.ToString();

	xGyroTextBox->Text = myObj.X_Gyro.ToString();
	yGyroTextBox->Text = myObj.Y_Gyro.ToString();
	zGyroTextBox->Text = myObj.Z_Gyro.ToString();


	xTempTextBox->Text = myObj.X_Temp.ToString();
	yTempTextBox->Text = myObj.Y_Temp.ToString();
	zTempTextBox->Text = myObj.Z_Temp.ToString();
	bTempTextBox->Text = myObj.B_Temp.ToString();

	textBoxQ0->Text = myObj.Q_0.ToString();
	textBoxQ1->Text = myObj.Q_1.ToString();
	textBoxQ2->Text = myObj.Q_2.ToString();
	textBoxQ3->Text = myObj.Q_3.ToString();

	textBoxX_zero->Text = myObj.mFinish(0, 0).ToString();
	textBoxY_zero->Text = myObj.mFinish(1,0).ToString();
	textBoxZ_zero->Text = myObj.mFinish(2,0).ToString();
	
	PitchBox->Text = myObj.angles.pitch.ToString();
	RollBox->Text = myObj.angles.roll.ToString();
	YawBox->Text = myObj.angles.yaw.ToString();

	calib_textbox->Text = myObj.maxGyro.ToString();
	
	if (IsOpen)
	{
		chart1->Series["X"]->Points->AddXY(counter, myObj.X_Accel);
		chart1->Series["Y"]->Points->AddXY(counter, myObj.Y_Accel);
		chart1->Series["Z"]->Points->AddXY(counter, myObj.Z_Accel);

		chart2->Series["X"]->Points->AddXY(counter, myObj.X_Gyro);
		chart2->Series["Y"]->Points->AddXY(counter, myObj.Y_Gyro);
		chart2->Series["Z"]->Points->AddXY(counter, myObj.Z_Gyro);

		if (counter > maxChart)
		{
			chart1->ChartAreas[0]->AxisX->Maximum = counter;
			chart2->ChartAreas[0]->AxisX->Maximum = counter;

			chart1->ChartAreas[0]->AxisX->Minimum = counter - maxChart;
			chart2->ChartAreas[0]->AxisX->Minimum = counter - maxChart;
			//chart1->Series["Y"]->Points->RemoveAt(counter - maxChart);
		//	chart1->Series["Z"]->Points->RemoveAt(counter - maxChart);

		//	chart2->Series["X"]->Points->RemoveAt(counter - maxChart);
		//	chart2->Series["Y"]->Points->RemoveAt(counter - maxChart);
		//	chart2->Series["Z"]->Points->RemoveAt(counter - maxChart);
		}

	}
	


	
}
private: System::Void MyForm_FormClosing(System::Object^ sender, System::Windows::Forms::FormClosingEventArgs^ e)
{
	
		opened = false;
		IsOpen = false;
		openClick = false;

}
private: System::Void CLOSE_Click(System::Object^ sender, System::EventArgs^ e) 
{
	openClick = false;
	IsOpen = false;

}





private: System::Void textBox3_TextChanged(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void textBox2_TextChanged(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void label13_Click(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void label14_Click(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void textBox4_TextChanged(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void label15_Click(System::Object^ sender, System::EventArgs^ e) {
}

private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
}

private: System::Void Calibrate_Button_Click(System::Object^ sender, System::EventArgs^ e) {

	 to_count = counter + myObj.calibTime;
	 myObj.beginCalibration();



}
};



}


