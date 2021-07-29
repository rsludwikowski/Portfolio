


#define M_PI 3.14159265358979323846
#define Gravity 9.80665

//using namespace Eigen;
//using namespace std;


#pragma once
//#include <Eigen/src/Core/Matrix.h>
#include <Eigen/Dense>

using namespace Eigen;

class MovingObj
{


private:
	bool calibration = 0 ;
public:
	
	bool isCalibrating() { return calibration; }

	void beginCalibration() { calibration = 1; }
	void endCalibration() { calibration = 0; }


	Matrix3f RotMatZ,RotMatY,RotMatX,RotMat;

	MatrixXf mBase,mFinish;
	
	

	typedef struct {
		double w, x, y, z;
	}Quaternion;

	typedef struct {
		double roll, pitch, yaw;
	}EulerAngles;



	typedef struct {
		double x, y, z;
	}AccelZero;

	AccelZero acc0 = { 0.0, 0.0, 0.0 };
	EulerAngles angles = { 0,0,0 };

	double X, Y, Z;

	double calibTime = 500;

	
	double maxGyro = 0;

	double X_Accel = 0;
	double Y_Accel = 0;
	double Z_Accel = 0;

	double X_Gyro = 0;
	double Y_Gyro = 0;
	double Z_Gyro = 0;


	double offset,max,min;

	double Q_0, Q_1, Q_2, Q_3;

	double X_Temp = 0;
	double Y_Temp = 0;
	double Z_Temp = 0;
	double B_Temp = 0;


	double pitch;
	double yaw;
	double roll;




	double timeDelay;
	double time;

	void Calculate();

	void Calibrate(double Gx_v, double Gy_v,double Gz_v);

	void AccelZero();

	MovingObj();

};

