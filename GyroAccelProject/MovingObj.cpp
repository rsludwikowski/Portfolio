#include "MovingObj.h"
#include "MadgwickAHRS.h"




#define _USE_MATH_DEFINES
#include <cmath>
#include <stdlib.h>

using namespace Eigen;
using namespace std;


MovingObj::EulerAngles setANGL(MovingObj::Quaternion q1) {

	MovingObj::EulerAngles ang;

	double sqw = q1.w * q1.w;
	double sqx = q1.x * q1.x;
	double sqy = q1.y * q1.y;
	double sqz = q1.z * q1.z;
	double unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
	double test = q1.x * q1.y + q1.z * q1.w;
	if (test > 0.49999999 * unit) { // singularity at north pole
		ang.yaw = 2 * atan2(q1.x, q1.w);
		ang.pitch = M_PI / 2;
		ang.roll = 0;
		
	}
	else if (test < -0.49999999 * unit) { // singularity at south pole
		ang.yaw = -2 * atan2(q1.x, q1.w);
		ang.pitch = -M_PI / 2;
		ang.roll = 0;
		
	}
	else {
		ang.yaw = atan2(2 * q1.y * q1.w - 2 * q1.x * q1.z, sqx - sqy - sqz + sqw);
		ang.pitch = asin(2 * test / unit);
		ang.roll = atan2(2 * q1.x * q1.w - 2 * q1.y * q1.z, -sqx + sqy - sqz + sqw);
	}

	ang.pitch = ang.pitch / M_PI * 180;
	ang.yaw = ang.yaw / M_PI * 180;
	ang.roll = ang.roll / M_PI * 180;

	return ang;
}

float toRad(float m)
{
	return m *(M_PI / 180.0);
}

MovingObj::EulerAngles ToEulerAngles(MovingObj::Quaternion q) {
    MovingObj::EulerAngles ang;

    // roll (x-axis rotation)
    double sinr_cosp = 2 * (q.w * q.x + q.y * q.z);
    double cosr_cosp = 1 - 2 * (q.x * q.x + q.y * q.y);
    ang.roll = std::atan2(sinr_cosp, cosr_cosp);

    // pitch (y-axis rotation)
    double sinp = 2 * (q.w * q.y - q.z * q.x);
    if (std::abs(sinp) >= 1)
        ang.pitch = std::copysign(M_PI / 2, sinp); // use 90 degrees if out of range
    else
        ang.pitch = std::asin(sinp);

    // yaw (z-axis rotation)
    double siny_cosp = 2 * (q.w * q.z + q.x * q.y);
    double cosy_cosp = 1 - 2 * (q.y * q.y + q.z * q.z);
    ang.yaw = std::atan2(siny_cosp, cosy_cosp);

	ang.pitch = ang.pitch / M_PI * 180;
	ang.yaw = ang.yaw / M_PI * 180;
	ang.roll = ang.roll / M_PI * 180;

   return ang;
}

void MovingObj::AccelZero()
{
	

	acc0.x = X_Accel + std::sin(angles.pitch* (M_PI / 180.0));
	acc0.y = Y_Accel - std::sin(angles.roll * (M_PI / 180.0));
	acc0.z = Z_Accel;
}

void MovingObj::Calculate()
{


	MadgwickAHRS_h::MadgwickAHRSupdateIMU((float)(X_Gyro * (M_PI / 180.0)), (float)(Y_Gyro * (M_PI / 180.0)), (float)(Z_Gyro * (M_PI / 180.0)),
		(float)X_Accel, (float)Y_Accel, (float) Z_Accel);
	Q_0 = MadgwickAHRS_h::q0;
	Q_1 = MadgwickAHRS_h::q1;
	Q_2 = MadgwickAHRS_h::q2;
	Q_3 = MadgwickAHRS_h::q3;

    Quaternion quat = { Q_0,Q_1,Q_2,Q_3 };


	AccelZero();
    
    angles = ToEulerAngles(quat);


	//Maciez obrotow Rz


	RotMatZ(0, 0) = cos(toRad(angles.yaw));
	RotMatZ(0, 1) = -sin(toRad(angles.yaw));
	RotMatZ(0, 2) = 0;

	RotMatZ(1, 0) = sin(toRad(angles.yaw));
	RotMatZ(1, 1) = cos(toRad(angles.yaw));
	RotMatZ(1, 2) = 0;

	RotMatZ(2, 0) = 0;
	RotMatZ(2, 1) = 0;
	RotMatZ(2, 2) = 1;

	//Maciez obrotow Ry

	RotMatY(0, 0) = cos(toRad(angles.pitch));
	RotMatY(0, 1) = 0;
	RotMatY(0, 2) = sin(toRad(angles.pitch));

	RotMatY(1, 0) = 0;
	RotMatY(1, 1) = 1;
	RotMatY(1, 2) = 0;

	RotMatY(2, 0) = -sin(toRad(angles.pitch));
	RotMatY(2, 1) = 0;
	RotMatY(2, 2) = cos(toRad(angles.pitch));
	

	//Maciez obrotow Rz


	RotMatX(0, 0) = 1;
	RotMatX(0, 1) = 0;
	RotMatX(0, 2) = 0;

	RotMatX(1, 0) = 0;
	RotMatX(1, 1) = cos(toRad(angles.roll));
	RotMatX(1, 2) = -sin(toRad(angles.roll));

	RotMatX(2, 0) = 0;
	RotMatX(2, 1) = sin(toRad(angles.roll));
	RotMatX(2, 2) = cos(toRad(angles.roll));

	RotMat = RotMatZ * RotMatY * RotMatX;

	mFinish = RotMat.inverse() * mBase;

	mFinish(0, 0) += X_Accel;
	mFinish(1, 0) += Y_Accel;
	mFinish(2, 0) += Z_Accel;
}

MovingObj::MovingObj()
{
	MovingObj::offset = 0;
	MovingObj::max = 0;
	MovingObj::min = 0;

}

void MovingObj::Calibrate(double Gx_v, double Gy_v, double Gz_v)
{


}

