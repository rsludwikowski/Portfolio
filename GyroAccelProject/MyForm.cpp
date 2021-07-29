#include "MyForm.h"

#include <iostream>
#include <Windows.h>
#include <string>
#include <iomanip>
#include <sstream>
#include <math.h>
#include <msclr\marshal_cppstd.h>

#include <thread>



using namespace System;
using namespace System::Windows::Forms;
using namespace System::IO::Ports;
using std::string;
using std::stringstream;














short int hex2dec(string hex)
{
	unsigned long result = 0;
	for (int i = 0; i < hex.length(); i++) {
		if (hex[i] >= 48 && hex[i] <= 57)
		{
			result += (hex[i] - 48) * pow(16, hex.length() - i - 1);
		}
		else if (hex[i] >= 65 && hex[i] <= 70) {
			result += (hex[i] - 55) * pow(16, hex.length() - i - 1);
		}
		else if (hex[i] >= 97 && hex[i] <= 102) {
			result += (hex[i] - 87) * pow(16, hex.length() - i - 1);
		}
	}
	return result;
}


inline string dec2hex(int decim)
{
	
	string s;
	stringstream ss;
	ss << std::hex << decim;
	s = ss.str();
	if (s.length() == 1) s = '0' + s;
	return s;
}




void fort()
{
	SerialPort^ gyroAcc;
	String^ answer;
	
	while (opened)
	{
		
		int baudRate = 57600;
		
		


		int prevbyte = 0;
		int bytes;

		
		myObj.mBase.setZero(3, 1);
		myObj.mFinish.setZero(3, 1);

		myObj.mBase(0, 0) = 0;
		myObj.mBase(1, 0) = 0;
		myObj.mBase(2, 0) = -1;

		if (openClick)
		{
			
			//
			String^ PortP = msclr::interop::marshal_as<String^>(portName);
			gyroAcc = gcnew SerialPort(PortP, baudRate);
			
			
			try
			{

				gyroAcc->Open();
				IsOpen = gyroAcc->IsOpen;
				do {
					

					try {
						


						bytes = gyroAcc->ReadByte();
						counter++;

						//std::cout <<  bytes << " ";
						std::cout.precision(2);

						if (bytes == prevbyte && bytes == 85)
						{
							std::cout << dec2hex(85) << " " << dec2hex(85) << " ";

							string Bt2Bt;
							bytes = gyroAcc->ReadByte();	std::cout << dec2hex(bytes);
							bytes = gyroAcc->ReadByte();	std::cout << dec2hex(bytes);
							bytes = gyroAcc->ReadByte();	std::cout << " " << dec2hex(bytes) << "\t";


							for (int z = 0; z < 3; z++)
							{

								string rate = "";
								bytes = gyroAcc->ReadByte();	rate += dec2hex(bytes);
								bytes = gyroAcc->ReadByte();	rate += dec2hex(bytes);

								std::cout << std::fixed << (20.0 / pow(2, 16) * hex2dec(rate)) << " g \t";

								switch (z) {
								case 0:
									myObj.X_Accel = -(20.0 / pow(2, 16) * hex2dec(rate));
									break;
								case 1:
									myObj.Y_Accel = (20.0 / pow(2, 16) * hex2dec(rate));
									break;
								case 2:
									myObj.Z_Accel = (20.0 / pow(2, 16) * hex2dec(rate));
									break;
								}


							}


							for (int z = 0; z < 3; z++)
							{

								string rate = "";
								bytes = gyroAcc->ReadByte();	rate += dec2hex(bytes);
								bytes = gyroAcc->ReadByte();	rate += dec2hex(bytes);

								std::cout << std::fixed << (1260.0 / pow(2, 16) * hex2dec(rate)) << " deg/s \t";

								switch (z) {
								case 0:
									if (abs(1260.0 / pow(2, 16) * hex2dec(rate)) >= myObj.maxGyro)
										myObj.X_Gyro = (1260.0 / pow(2, 16) * hex2dec(rate));
									else
										myObj.X_Gyro = 0.0;
									break;
								case 1:
									if (abs(1260.0 / pow(2, 16) * hex2dec(rate)) >= myObj.maxGyro)
										myObj.Y_Gyro = -(1260.0 / pow(2, 16) * hex2dec(rate));
									else
										myObj.Y_Gyro = 0.0;
									break;
								case 2:
									if (abs(1260.0 / pow(2, 16) * hex2dec(rate)) >= myObj.maxGyro)
										myObj.Z_Gyro = -(1260.0 / pow(2, 16) * hex2dec(rate));
									else
										myObj.Z_Gyro = 0.0;
									break;
								}

							}


							for (int z = 0; z < 4; z++)
							{

								string rate = "";
								bytes = gyroAcc->ReadByte();	rate += dec2hex(bytes);
								bytes = gyroAcc->ReadByte();	rate += dec2hex(bytes);

								std::cout << std::fixed << (200.0 / pow(2, 16) * hex2dec(rate)) << " deg. C \t";

								switch (z) {
								case 0:
									myObj.X_Temp = (200.0 / pow(2, 16) * hex2dec(rate));
									break;
								case 1:
									myObj.Y_Temp = (200.0 / pow(2, 16) * hex2dec(rate));
									break;
								case 2:
									myObj.Z_Temp = (200.0 / pow(2, 16) * hex2dec(rate));
									break;
								case 3:
									myObj.B_Temp = (200.0 / pow(2, 16) * hex2dec(rate));
									break;
								}
							}

							myObj.Calculate();

							if (myObj.isCalibrating())
							{
								if (myObj.X_Gyro > myObj.maxGyro) myObj.maxGyro = myObj.X_Gyro;
								if (myObj.Y_Gyro > myObj.maxGyro) myObj.maxGyro = myObj.Y_Gyro;
								if (myObj.Z_Gyro > myObj.maxGyro) myObj.maxGyro = myObj.Z_Gyro;
								if (counter >= to_count) myObj.endCalibration();
							}

							for (int z = 0; z < 6; z++)
							{
								gyroAcc->ReadByte();
							}







							
						}





						prevbyte = bytes;

					}
					catch (Exception ^ e)
					{
						
					}



					//answer = Console::ReadLine();





				} while (IsOpen);



			}
			catch (IO::IOException ^ e)
			{
				Console::WriteLine(e->GetType()->Name + ": Port nie gotowy!");
				counter = -1;
			}
			catch (ArgumentException ^ e)
			{
				Console::WriteLine(e->GetType()->Name + ": nie prawid³owa nazwa portu musi sie zaczynac od COM");
				counter = -2;
			}

			gyroAcc->Close();
		}
		
	}
	

}


[STAThreadAttribute]
int main(array <String^>^ args) {


	
	counter = 0 ;
	std::thread th1(fort);
	
    Application::EnableVisualStyles();
    Application::SetCompatibleTextRenderingDefault(false);
    GuiGyro::MyForm form;
    Application::Run(% form);

	


	
	
	
	


		
		
	th1.join();


	//tu

		
	
	


    return 0;
}

void GuiGyro::MyForm::openPorts()
{
	
}
